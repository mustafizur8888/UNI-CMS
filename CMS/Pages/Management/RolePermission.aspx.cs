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

                foreach (GridViewRow row in grdRole.Rows)
                {
                    flag = ((CheckBox)row.FindControl("Permission")).Checked;
                    string menuid = ((Label)row.FindControl("mid")).Text;
                    string submenuid = ((Label)row.FindControl("sid")).Text;
                    string roleid = ddlRoleName.SelectedValue.ToString();

                    if (flag)
                    {

                    }
                    else
                    {
                        
                    }


                }
              
               
             
              
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