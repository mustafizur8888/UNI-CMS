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
    public partial class CreateSubCategory : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                PortalMenuLoad();
                ddlMasterMenu_OnSelectedIndexChanged(null, null);
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
            string SubMenuName = ((Label)gvr.FindControl("lblSubCategoryName")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string MasterId = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            string PrimaryId = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidMenuId.Value = MasterId;
            hidIdPrimary.Value = PrimaryId;
            checkIsActive.Checked = Status == "True";
            txtSubCategory.Text = SubMenuName;
            ddlCategoryName.SelectedValue = MasterId;
            ddlPortalMenu.SelectedValue = PrimaryId;
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
                count = _db.ExecuteNonQuery("sp_SetSubCategory", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadSubCategory();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtSubCategory.Text = String.Empty;
            checkIsActive.Checked = false;
            hidIdPrimary.Value = "";
            hidMenuId.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {


                string SubCategoryName = txtSubCategory.Text;
                int PortalId = Convert.ToInt32(ddlPortalMenu.SelectedValue);
                int CatId = Convert.ToInt32(ddlCategoryName.SelectedValue);
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
                string type = hidMenuId.Value;
                string idVal = hidIdPrimary.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = SubCategoryName,ParameterName = "@SubCategoryName"},
                    new SqlParameter{Value = PortalId,ParameterName = "@PortalId"},
                    new SqlParameter{Value = CatId,ParameterName = "@CategoryId"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                int count = _db.ExecuteNonQuery("sp_SetSubCategory", sqlParameters);
                hidIdPrimary.Value = "";
                hidMenuId.Value = "";
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadSubCategory();

                }
            }
        }

        private void LoadSubCategory()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},
                new SqlParameter{Value = ddlPortalMenu.SelectedValue,ParameterName = "@PortalId"},
                new SqlParameter{Value = ddlCategoryName.SelectedValue,ParameterName = "@CategoryId"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_SetSubCategory", sqlParameters);
            grdSubCategory.DataSource = ds;
            grdSubCategory.DataBind();
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

            if (string.IsNullOrWhiteSpace(txtSubCategory.Text))
            {
                msg += "Sub-Category name is empty" + "<br>";
            }
           
            if (ddlPortalMenu.Items.Count == 0)
            {
                msg += "Please select Portal menu" + "<br>";
            }
            if (ddlCategoryName.Items.Count == 0)
            {
                msg += "Please select  category menu" + "<br>";
            }


            else if (btnSave.Text != "Update")
            {

                string query = "Select count(*) from [tbl_SubCategory] where SubCategoryName='" + txtSubCategory.Text + "' and PortalId="

                    + ddlPortalMenu.SelectedValue+ " and CategoryId="+ddlCategoryName.SelectedValue+"";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "Sub-Category name already exists for this portal menu" + "<br/>";
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
            LoadSubCategory();
        }



        protected void ddlMasterMenu_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCategory();
        }

        private void LoadCategory()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "catName",
                    ParameterName = "@type"
                },
                new SqlParameter
                {
                    Value = ddlPortalMenu.SelectedValue,
                    ParameterName = "@masterId"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlCategoryName.DataSource = dsMenuDataSet;
                ddlCategoryName.DataTextField = "CategoryName";
                ddlCategoryName.DataValueField = "id";
                ddlCategoryName.DataBind();
            }
            else
            {
                ddlCategoryName.Items.Clear();
            }
            LoadSubCategory();
        }
    }
}