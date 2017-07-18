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
    public partial class ContentUpload : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetPortalList();
                GetContentCategoryList();
                ddlContentCategory_OnSelectedIndexChanged(null, null);
            }
        }

        private void GetPortalList()
        {

            DataSet ds = _db.GetDataSet("GetPortalList");
            ddlPortal.DataSource = ds;
            ddlPortal.DataValueField = "Id";
            ddlPortal.DataTextField = "PortalName";
            ddlPortal.DataBind();
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

            DataSet ds = _db.GetDataSet("SpGetContentCategoryList", new List<SqlParameter>() { new SqlParameter { Value = ddlContentCategory.SelectedValue, ParameterName = "@catId" } });
            ddlContentSubCategory.DataSource = ds;
            ddlContentSubCategory.DataValueField = "ContentSubCatId";
            ddlContentSubCategory.DataTextField = "ConSubCatName";
            ddlContentSubCategory.DataBind();
        }

        protected void ddlContentCategory_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            GetContentSubCategoryList();
        }
    }
}