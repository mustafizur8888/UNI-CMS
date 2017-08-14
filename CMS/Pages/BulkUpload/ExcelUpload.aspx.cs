using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClosedXML.Excel;
using DAL;
using LinqToExcel;

namespace CMS.Pages.BulkUpload
{
    public partial class ExcelUpload : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            btnSync.Visible = false;
            if (!IsPostBack)
            {
                LoadServiceId();
            }
        }

        private void LoadServiceId()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            DataSet ds = _db.GetDataSet("sp_getServiceName", sqlParameters);
            ddlServiceId.DataSource = ds;
            ddlServiceId.DataValueField = "ServiceId";
            ddlServiceId.DataTextField = "ServiceId";
            ddlServiceId.DataBind();
        }

        public IEnumerable<string> getWorkSheets(string pathToExcelFile)
        {
            string pathToExcelFile1 = ""
                                     + @"D:\UploadExcel\" + pathToExcelFile;

            // This is an expensive operation - Do this only once if possible:
            var excelFile = new ExcelQueryFactory(pathToExcelFile1);
            var worksheetsList = excelFile.GetWorksheetNames();
            return excelFile.GetWorksheetNames();
        }

        protected void btnUpload_OnClick(object sender, EventArgs e)
        {
            if (fuExcel.HasFiles)
            {
                string fileName = System.IO.Path.GetFileName(fuExcel.PostedFile.FileName);
                fuExcel.PostedFile.SaveAs(Server.MapPath("~/UploadExcel/" + fileName));
                string path = "~/UploadExcel/" + fileName;
                var sheetNames = getWorkSheets(fileName);
                string pathToExcelFile1 = ""
                                          + @"D:\UploadExcel\" + fileName;
                foreach (var VARIABLE in sheetNames)
                {
                    var book = new LinqToExcel.ExcelQueryFactory(pathToExcelFile1);

                    var query =
                        from row in book.Worksheet(VARIABLE)
                        let item = new
                        {
                            ContentDate = row["Date"].Cast<string>(),
                            ServiceId = row["ServiceId"].Cast<string>(),
                            Content = row["Content"].Cast<string>(),

                        }

                        select item;
                    // Console.WriteLine(query.Count().ToString());
                    foreach (var excel in query)
                    {
                        if (string.IsNullOrEmpty(excel.ServiceId))
                        {

                        }
                        else
                        {
                            List<SqlParameter> sqlParameters = new List<SqlParameter>
                            {
                                new SqlParameter{Value = Convert.ToDateTime(excel.ContentDate),ParameterName = "@contentdate"},
                                new SqlParameter{Value = excel.ServiceId.ToString(),ParameterName = "@serviceid"},
                                new SqlParameter{Value = excel.Content,ParameterName = "@content"},


                            };
                            int count = _db.ExecuteNonQuery("sp_InsertIntoBaseUpload", sqlParameters);
                        }


                    }
                }

            }
        }

        protected void btnShow_OnClick(object sender, EventArgs e)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = ddlYear.SelectedValue,ParameterName = "@year"},
                new SqlParameter{Value = ddlServiceId.SelectedValue,ParameterName = "@service"},
                new SqlParameter{Value = ddlMonth.SelectedValue,ParameterName = "@month"},
            };
            DataSet ds = _db.GetDataSet("sp_ShowUploadData", sqlParameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                grdData.DataSource = ds;
                grdData.DataBind();
            }
            btnSync.Visible = true;
        }

        protected void btnSync_OnClick(object sender, EventArgs e)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = ddlYear.SelectedValue,ParameterName = "@year"},
                new SqlParameter{Value = ddlServiceId.SelectedValue,ParameterName = "@service"},
                new SqlParameter{Value = ddlMonth.SelectedValue,ParameterName = "@month"},
            };
            DataSet ds = _db.GetDataSet("sp_SelectDataForMainTable", sqlParameters);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {

                List<SqlParameter> sqlParametersInsert = new List<SqlParameter>
                {
                    new SqlParameter{Value = Convert.ToDateTime(dr["ContentDate"]),ParameterName = "@Contentdate"},
                    new SqlParameter{Value = dr["ServiceId"],ParameterName = "@serviceid"},
                    new SqlParameter{Value = dr["Content"],ParameterName = "@Content"},
                };
                int count = _db.ExecuteNonQuery("sp_InsertIntoMainTable", sqlParametersInsert);
            }
            btnShow_OnClick(null, null);
        }
    }
}