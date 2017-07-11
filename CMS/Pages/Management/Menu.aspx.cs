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
    public partial class Menu : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                MasterMenuLoad();
            }
        }

        private void MasterMenuLoad()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "master",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlMasterMenu.DataSource = dsMenuDataSet;
                ddlMasterMenu.DataTextField = "Name";
                ddlMasterMenu.DataValueField = "id";
                ddlMasterMenu.DataBind();
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
            string MenuName = ((Label)gvr.FindControl("lblMenuName")).Text;
            string MenuOrder = ((Label)gvr.FindControl("lblMenuOrder")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string Url = ((Label)gvr.FindControl("lblUrl")).Text;
            string HasSubeMenu = ((Label)gvr.FindControl("lblHasSubManu")).Text;
            string MasterId = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            string PrimaryId = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidMasterMenuId.Value = MasterId;
            hidIdPrimary.Value = PrimaryId;
            checkIsActive.Checked = Status == "True";
            checkHasSubMenu.Checked = HasSubeMenu == "True";
            //txtMasterMenu.Text = MasterMenu;
            txtMenuOrder.Text = MenuOrder;
            txtMenu.Text = MenuName;
            ddlMasterMenu.SelectedValue = MasterId;
            if (Url == "")
            {
                divUrl.Visible = false;
            }
            else
            {
                txtUrl.Text = Url;
                divUrl.Visible = true;
            }
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
                count = _db.ExecuteNonQuery("sp_Menu", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadMenu();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtMenu.Text = String.Empty;
            txtMenuOrder.Text = String.Empty;
            txtUrl.Text = String.Empty;
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


                string MenuName = txtMenu.Text;
                string url = txtUrl.Text;
                int MenuOrder = Convert.ToInt32(txtMenuOrder.Text);
                int MasterMenuId = Convert.ToInt32(ddlMasterMenu.SelectedValue);
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
                string type = hidMasterMenuId.Value;
                string idVal = hidIdPrimary.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = MenuName,ParameterName = "@MenuName"},
                    new SqlParameter{Value = ddlMasterMenu.SelectedValue,ParameterName = "@MasterMenuId"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = HasSubMenu,ParameterName = "@HasSubMenu"},
                    new SqlParameter{Value = MenuOrder,ParameterName = "@MenuOrder"},
                    new SqlParameter{Value = url,ParameterName = "@Url"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                hidMasterMenuId.Value = "";
                hidIdPrimary.Value = "";
                int count = _db.ExecuteNonQuery("sp_Menu", sqlParameters);
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadMenu();

                }
            }
        }

        private void LoadMenu()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_Menu", sqlParameters);
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

            if (string.IsNullOrWhiteSpace(txtMenu.Text))
            {
                msg += "Menu name is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtMenuOrder.Text))
            {
                msg += "Menu order is empty" + "<br>";
            }
            if (ddlMasterMenu.Items.Count == 0)
            {
                msg += "Please select Master menu" + "<br>";
            }
            if (!checkHasSubMenu.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtUrl.Text))
                {
                    msg += "Url is empty" + "<br>";
                }
            }
            //else
            //{

            //    string query = "Select count(*) from [tbl_MasterMenu] where MenuOrder='" + txtMenuOrder.Text + "'";
            //    string value = _db.GetSingelValue(query);
            //    if (!string.IsNullOrEmpty(value))
            //    {
            //        if (value != "0")
            //        {
            //            msg += "Menu order already exists" + "<br/>";
            //        }
            //    }

            //}

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
            LoadMenu();
        }

        protected void checkHasSubMenu_OnCheckedChanged(object sender, EventArgs e)
        {
            divUrl.Visible = !checkHasSubMenu.Checked;
        }
    }
}