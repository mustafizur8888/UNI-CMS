using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace CMS.Pages.Content
{
    public partial class CreateCategory : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                //PortalMenuLoad();
            }
        }

        private void PortalMenuLoad()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "portalName",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlPortalMenu.DataSource = dsMenuDataSet;
                ddlPortalMenu.DataTextField = "Name";
                ddlPortalMenu.DataValueField = "id";
                ddlPortalMenu.DataBind();
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
            string CategoryName = ((Label)gvr.FindControl("lblCategoryName")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string HasSubeMenu = ((Label)gvr.FindControl("lblHasSubManu")).Text;
            //string MasterId = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            string PrimaryId = ((HiddenField)gvr.FindControl("hidId")).Value;
            //hidMasterMenuId.Value = MasterId;
            hidIdPrimary.Value = PrimaryId;
            checkIsActive.Checked = Status == "True";
            checkHasSubMenu.Checked = HasSubeMenu == "True";
            //txtMasterMenu.Text = MasterMenu;
            txtCategory.Text = CategoryName;
            //ddlPortalMenu.SelectedValue = MasterId;
            btnSave.Text = "Update";
        }

        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string idVal = ((HiddenField)gvr.FindControl("hidId")).Value;
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
                count = _db.ExecuteNonQuery("sp_SetCategoryName", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadCategory();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtCategory.Text = String.Empty;
            checkIsActive.Checked = false;
            checkHasSubMenu.Checked = false;
            hidMasterMenuId.Value = "";
            hidIdPrimary.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {


                string CategoryName = txtCategory.Text;
         
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
                bool HasSubMenu = checkHasSubMenu.Checked;
                //string type = hidMasterMenuId.Value;
                string type = String.Empty;
                string idVal = hidIdPrimary.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                type = id == 0 ? String.Empty : "update";
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = CategoryName,ParameterName = "@CategoryName"},
                   
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = HasSubMenu,ParameterName = "@HasSubMenu"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                hidMasterMenuId.Value = "";
                hidIdPrimary.Value = "";
                int count = _db.ExecuteNonQuery("sp_SetCategoryName", sqlParameters);
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadCategory();

                }
            }
        }

        private void LoadCategory()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_SetCategoryName", sqlParameters);
            grdMenu.DataSource = ds;
            grdMenu.DataBind();
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

            if (string.IsNullOrWhiteSpace(txtCategory.Text))
            {
                msg += "Category name is empty" + "<br>";
            }
            
          
            else if (btnSave.Text != "Update")
            {

                string query = "Select count(*) from [tbl_CategoryName] where CategoryName='" + txtCategory.Text + "'";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "Category name already exists" + "<br/>";
                    }
                }

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
            LoadCategory();
        }

       
    }
}