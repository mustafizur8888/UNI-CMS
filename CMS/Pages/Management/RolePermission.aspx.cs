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

namespace CMS.Pages.Management
{
    public partial class RolePermission : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                LoadRole();
                ddlRoleName_OnSelectedIndexChanged(null, null);
            }
        }

        private void LoadRole()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "Role",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_getRole", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlRoleName.DataSource = dsMenuDataSet;
                ddlRoleName.DataTextField = "RoleName";
                ddlRoleName.DataValueField = "id";
                ddlRoleName.DataBind();
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Clear();
            //throw new NotImplementedException();
        }


        private void Clear()
        {
            LoadRole();
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {

                bool flag = false;
                string CreatedBy = String.Empty;
                foreach (GridViewRow row in grdRole.Rows)
                {
                    try
                    {
                        CreatedBy = Session["User"].ToString();
                    }
                    catch
                    {
                        CreatedBy = String.Empty;
                    }

                    flag = ((CheckBox)row.FindControl("Permission")).Checked;
                    string menuid = ((Label)row.FindControl("lblMenuid")).Text;
                    string submenuid = ((Label)row.FindControl("lblSubmenuid")).Text;
                    string Rpid = ((HiddenField)row.FindControl("rpId")).Value;
                    string roleid = ddlRoleName.SelectedValue.ToString();
                    string UpdatedBy = CreatedBy;
                    DateTime CreateDate = DateTime.Now;
                    if (flag)
                    {
                        List<SqlParameter> sqlParameterss = new List<SqlParameter>
                        {
                            new SqlParameter{Value = 1,ParameterName = "@flag"},
                            new SqlParameter{Value = menuid,ParameterName = "@menuid"},
                            new SqlParameter{Value = string.IsNullOrWhiteSpace(submenuid)?null:submenuid,ParameterName = "@submenuid"},
                            new SqlParameter{Value = roleid,ParameterName = "@roleid"},
                            new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                            new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                            new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                            new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                            new SqlParameter{Value = Rpid,ParameterName = "@rpid"},
                        };
                        int counts = _db.ExecuteNonQuery("sp_ManageRolePermission", sqlParameterss);
                        if (counts > 0)
                        {
                            ShowSuccMsg("Saved Successfully");
                        }
                    }
                    else
                    {
                        List<SqlParameter> sqlParameterss = new List<SqlParameter>
                        {
                            new SqlParameter{Value = 0,ParameterName = "@flag"},
                            new SqlParameter{Value = menuid,ParameterName = "@menuid"},
                            new SqlParameter{Value = string.IsNullOrWhiteSpace(submenuid)?DBNull.Value:(object)submenuid,ParameterName = "@submenuid"},
                            new SqlParameter{Value = roleid,ParameterName = "@roleid"},
                            new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                            new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                            new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                            new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                            new SqlParameter{Value = Rpid,ParameterName = "@rpid"},
                        };
                        int counts = _db.ExecuteNonQuery("sp_ManageRolePermission", sqlParameterss);
                        if (counts > 0)
                        {
                            ShowSuccMsg("Updated Successfully");
                        }
                    }
                }
                LoadRoleGrid();
            }
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
            LoadRoleGrid();
        }

        protected void ddlRoleName_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRoleGrid();
        }

        private void LoadRoleGrid()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {

                new SqlParameter{Value = ddlRoleName.SelectedValue,ParameterName = "@RoleId"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_RolePermission", sqlParameters);
            grdRole.DataSource = ds;
            grdRole.DataBind();
        }
    }
}