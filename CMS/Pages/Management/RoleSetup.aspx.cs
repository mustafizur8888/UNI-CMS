using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace AMAR.Web.Pages.CMS
{
    public partial class MasterMenu : System.Web.UI.Page
    {
        private Db _db = new Db();
       
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
              
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
            string RoleName = ((Label)gvr.FindControl("lblRoleName")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string type = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidRoleID.Value = type;
            if (Status == "True")
            {
                checkIsActive.Checked = true;
                
            }
            else
            {
                checkIsActive.Checked = false;
               
            }
            txtRoleName.Text = RoleName;
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
                count = _db.ExecuteNonQuery("sp_RoleManagement", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadRole();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtRoleName.Text=String.Empty;
            checkIsActive.Checked = false;
            hidRoleID.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {
               
               
                string Rolename = txtRoleName.Text;
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
                bool isActive =checkIsActive.Checked;
                string type = hidRoleID.Value;
                string idVal = hidRoleID.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = Rolename,ParameterName = "@RoleName"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                //to reset hidden field value
                hidRoleID.Value = "";
                int count = _db.ExecuteNonQuery("sp_RoleManagement", sqlParameters);
                if (count > 0)
                {
                    ShowSuccMsg(type == "update"? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadRole();

                }
            }
        }

        private void LoadRole()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},
                
            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_RoleManagement", sqlParameters);
            grdRole.DataSource = ds;
            grdRole.DataBind();
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

            if (string.IsNullOrWhiteSpace(txtRoleName.Text))
            {
                msg += "Role name is empty" + "<br>";
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
            LoadRole();
        }
    }
}