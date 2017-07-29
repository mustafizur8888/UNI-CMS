using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Models;
using DAL;

namespace CMS.Pages.Content
{
    public partial class ContentPublish : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetContentCategoryList();
                ddlContentCategory_OnSelectedIndexChanged(null, null);
                GetPortalList();
            }
        }

        private void GetContentCategoryList()
        {

            DataSet ds = _db.GetDataSet("SpGetContentCategory");
            ddlContentCategory.DataSource = ds;
            ddlContentCategory.DataValueField = "ContentCategoryId";
            ddlContentCategory.DataTextField = "ContentCategoryName";
            ddlContentCategory.DataBind();
        }
        private void GetContentSubCategoryList()
        {

            DataSet ds = _db.GetDataSet("SpGetContentCategoryList", new List<SqlParameter> { new SqlParameter { Value = ddlContentCategory.SelectedValue, ParameterName = "@catId" } });
            ddlContentSubCategory.DataSource = ds;
            ddlContentSubCategory.DataValueField = "ContentSubCatId";
            ddlContentSubCategory.DataTextField = "ConSubCatName";
            ddlContentSubCategory.DataBind();
        }
        protected void ddlContentCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetContentSubCategoryList();
        }

        private void GetPortalList()
        {

            DataSet ds = _db.GetDataSet("GetPortalList");
            ddlPortal.DataSource = ds;
            ddlPortal.DataValueField = "Id";
            ddlPortal.DataTextField = "PortalName";
            ddlPortal.DataBind();
        }
        private void ShowGrd()
        {
            DataSet ds;
            if (ddlFilter.SelectedValue == "P")
            {
                ds = _db.GetDataSet("spGetPublishContent", new List<SqlParameter>{new SqlParameter
                {
                    Value = true,
                    ParameterName = "@Filter"
                }});
                grdUnpublish.DataSource = ds;
                grdUnpublish.DataBind();
                grdUnpublish.Visible = true;
                grdPublish.Visible = false;
            }
            else
            {
                ds = _db.GetDataSet("spGetPublishContent", new List<SqlParameter>{new SqlParameter
                {
                    Value = false,
                    ParameterName = "@Filter"
                }});
                grdUnpublish.Visible = false;
                grdPublish.Visible = true;
                grdPublish.DataSource = ds;
                grdPublish.DataBind();
            }

        }
        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            ShowGrd();
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {

        }

        private bool Save(string id, bool check, string flag)
        {
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = flag,
                    ParameterName = "@Flag",
                },
                new SqlParameter
                {
                    Value = id,
                    ParameterName = "@Id"
                },
                new SqlParameter
                {
                    Value = check,
                    ParameterName = "@Check"
                },
                new SqlParameter
                {
                    Value = UserModel.UserId,
                    ParameterName = "@UserId"
                }

            };
            int r = _db.ExecuteNonQuery("SPContentPublishUnPublish", list);
            return r > 0;
        }
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                if (ddlFilter.SelectedValue == "P")
                {
                    foreach (GridViewRow row in grdUnpublish.Rows)
                    {
                        var check = ((CheckBox)row.FindControl("checkP")).Checked;
                        string id = ((HiddenField)row.FindControl("hidId")).Value;
                        Save(id, check, "Publsih");
                    }
                }
                else
                {
                    foreach (GridViewRow row in grdPublish.Rows)
                    {
                        var check = ((CheckBox)row.FindControl("checkP")).Checked;
                        string id = ((HiddenField)row.FindControl("hidId")).Value;
                        Save(id, check, "UNPublsih");
                    }
                }
                ShowGrd();
            }
        }

        private bool Validation()
        {

            bool flag = true;
            string msg = String.Empty;
            if (ddlPortal.Items.Count == 0)
            {
                msg += "Select a Portal" + "<br>";
            }

            if (!string.IsNullOrWhiteSpace(msg))
            {
                flag = false;
                ShowError(msg);
            }

            return flag;


        }

        private void ShowError(string msg)
        {
            divError.Visible = true;
            lblError.Text = msg;
        }
        private void ShowSucc(string msg)
        {
            divSucc.Visible = true;
            lblSucc.Text = msg;
        }
    }
}