using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace CMS.Pages.Content
{
    public partial class Album : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                LoadOwnerName();
                LoadGenreName();
               
            }
        }

        private void LoadGenreName()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "genreName",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlGenre.DataSource = dsMenuDataSet;
                ddlGenre.DataTextField = "Name";
                ddlGenre.DataValueField = "id";
                ddlGenre.DataBind();
            }
        }

        private void LoadOwnerName()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "ownerName",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlOwnerName.DataSource = dsMenuDataSet;
                ddlOwnerName.DataTextField = "Name";
                ddlOwnerName.DataValueField = "id";
                ddlOwnerName.DataBind();
            }
        }

       

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Clear();
            //throw new NotImplementedException();
        }

        protected void btnEdit_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string SubMenuName = ((Label)gvr.FindControl("lblAlbumName")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string MasterId = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            string OwnerId = ((HiddenField)gvr.FindControl("hidOwnerId")).Value;
            string GenreId = ((HiddenField)gvr.FindControl("hidGenreId")).Value;
          
            hidIdPrimary.Value = MasterId;
            hidGenreIdPrimary.Value = GenreId;
            hidOwnerIdPrimary.Value = OwnerId;
            checkIsActive.Checked = Status == "True";
            txtAlbumName.Text = SubMenuName;
            ddlOwnerName.SelectedValue = MasterId;
            ddlGenre.SelectedValue = GenreId;
            ddlOwnerName.SelectedValue = OwnerId;
            btnSave.Text = "Update";
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string idVal = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            int id = 0;
            id = idVal != "" ? Convert.ToInt32(idVal) : 0;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "delete",ParameterName = "@type"},
                new SqlParameter{Value = id,ParameterName = "@id"}
            };

            int count = 0;
            try
            {
                count = _db.ExecuteNonQuery("sp_SetAlbumInfo", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadAlbumInfo();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtAlbumName.Text = String.Empty;
            checkIsActive.Checked = false;
            hidIdPrimary.Value = "";
            hidOwnerIdPrimary.Value = "";
            hidGenreIdPrimary.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {

                string AlbumUrl = null;
                if (fuImg.HasFile)
                {
                    AlbumUrl = "~/UplodedFile/Album/" + DateTime.Now.ToString("yyyyMdHHMMSS") + new FileInfo(fuImg.FileName).Extension;
                    fuImg.SaveAs(Server.MapPath(AlbumUrl));
                }
                else
                {
                    AlbumUrl = "~/UplodedFile/Album/" + "avatar2.jpg";
                }
             

                string AlbumName = txtAlbumName.Text;
                int OwnerId = Convert.ToInt32(ddlOwnerName.SelectedValue);
                int GenreId = Convert.ToInt32(ddlGenre.SelectedValue);
                string CreatedBy = String.Empty;
                try
                {
                    CreatedBy = Session["User"].ToString();
                }
                catch
                {
                    CreatedBy = String.Empty;
                }
                // string CreatedBy = String.Empty;
                string UpdatedBy = CreatedBy;
                DateTime CreateDate = DateTime.Now;
                bool isActive = checkIsActive.Checked;
                string type = hidIdPrimary.Value;
                string idVal = hidIdPrimary.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = AlbumName,ParameterName = "@AlbumName"},
                    new SqlParameter{Value = OwnerId,ParameterName = "@OwnerId"},
                    new SqlParameter{Value = GenreId,ParameterName = "@GenreId"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = id,ParameterName = "@id"},
                    new SqlParameter{Value = AlbumUrl,ParameterName = "@ImgPreviewLink"},

                };
                int count = _db.ExecuteNonQuery("sp_SetAlbumInfo", sqlParameters);
                hidIdPrimary.Value = "";
                hidOwnerIdPrimary.Value = "";
                hidGenreIdPrimary.Value = "";
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadAlbumInfo();

                }
            }
        }

        private void LoadAlbumInfo()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},
               

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_SetAlbumInfo", sqlParameters);
            grdAlbumInfo.DataSource = ds;
            grdAlbumInfo.DataBind();
        }

        private void ShowSuccMsg(string msg)
        {
            lblSuccess.Text = msg;
            divSucc.Visible = true;
        }

        private bool Validation()
        {
            bool result = true;
            string msg = string.Empty;

            if (string.IsNullOrWhiteSpace(txtAlbumName.Text))
            {
                msg += "Album name is empty" + "<br>";
            }
            else if (btnSave.Text != "Update")
            {

                string query = "Select count(*) from [tblAlbum] where AlbumName='" + txtAlbumName.Text + "'";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "Album name already exists" + "<br/>";
                    }
                }
            }

            if (ddlOwnerName.Items.Count == 0)
            {
                msg += "Please select owner name" + "<br>";
            }
            if (ddlGenre.Items.Count == 0)
            {
                msg += "Please select  genre" + "<br>";
            }



            if (!string.IsNullOrWhiteSpace(msg))
            {
                result = false;
                ShowErrorMsg(msg);
            }


            return result;
        }
        private void ShowErrorMsg(string msg)
        {
            lblError.Text = msg;
            divError.Visible = true;
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            LoadAlbumInfo();
        }
       
    }
}