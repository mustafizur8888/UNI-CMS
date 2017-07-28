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
                grdPublish.DataSource = ds;
                grdUnpublish.DataBind();
                grdUnpublish.Visible = false;
                grdPublish.Visible = true;
            }
            else
            {
                ds = _db.GetDataSet("spGetPublishContent", new List<SqlParameter>{new SqlParameter
                {
                    Value = false,
                    ParameterName = "@Filter"
                }});
                grdUnpublish.Visible = true;
                grdPublish.Visible = false;
                grdUnpublish.DataSource = ds;
                grdUnpublish.DataBind();
            }

        }
        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            ShowGrd();
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {

        }


        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (ddlPortal.Items.Count > 0)
            {

            }
        }
    }
}