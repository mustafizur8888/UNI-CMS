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
    public partial class CreateOwner : System.Web.UI.Page
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
            string OwnerName = ((Label)gvr.FindControl("lblOwnerName")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string type = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidPortalId.Value = type;
            if (Status == "True")
            {
                checkIsActive.Checked = true;

            }
            else
            {
                checkIsActive.Checked = false;

            }
            txtOwnerName.Text = OwnerName;
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
                count = _db.ExecuteNonQuery("sp_SetOwnerName", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadPortalName();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtOwnerName.Text = String.Empty;
            checkIsActive.Checked = false;
            hidPortalId.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {


                string PortalName = txtOwnerName.Text;
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
                string type = hidPortalId.Value;
                string idVal = hidPortalId.Value;
                int id = 0;
                if (idVal != "")
                {
                    id = Convert.ToInt32(idVal);
                }
                else
                {
                    id = 0;
                }
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = PortalName,ParameterName = "@OwnerName"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                hidPortalId.Value = "";
                int count = _db.ExecuteNonQuery("sp_SetOwnerName", sqlParameters);
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadPortalName();

                }
            }
        }

        private void LoadPortalName()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_SetOwnerName", sqlParameters);
            grdArtistName.DataSource = ds;
            grdArtistName.DataBind();
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

            if (string.IsNullOrWhiteSpace(txtOwnerName.Text))
            {
                msg += "Owner name is empty" + "<br>";
            }

            else if (btnSave.Text != "Update")
            {

                string query = "Select count(*) from [tbl_Owner] where Name='" + txtOwnerName.Text + "'";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "Owner name already exists" + "<br/>";
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
            LoadPortalName();
        }
    }
}