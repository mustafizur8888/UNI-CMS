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
    public partial class SubMenu : System.Web.UI.Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                MasterMenuLoad();
                ddlMasterMenu_OnSelectedIndexChanged(null, null);
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
            string SubMenuName = ((Label)gvr.FindControl("lblMenuName")).Text;
            string SubMenuOrder = ((Label)gvr.FindControl("lblMenuOrder")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string Url = ((Label)gvr.FindControl("lblUrl")).Text;
            string MasterId = ((HiddenField)gvr.FindControl("hiMasterId")).Value;
            string PrimaryId = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidMenuId.Value = MasterId;
            hidIdPrimary.Value = PrimaryId;
            checkIsActive.Checked = Status == "True";
            txtSubMenu.Text = SubMenuName;
            txtSubMenuOrder.Text = SubMenuOrder;
            txtUrl.Text = Url;
            ddlMenuName.SelectedValue = MasterId;
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
                count = _db.ExecuteNonQuery("sp_SubMenu", sqlParameters);
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
            txtSubMenu.Text = String.Empty;
            txtSubMenuOrder.Text = String.Empty;
            txtUrl.Text = String.Empty;
            checkIsActive.Checked = false;
            hidIdPrimary.Value = "";
            hidMenuId.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {


                string SubMenuName = txtSubMenu.Text;
                string url = txtUrl.Text;
                int MenuOrder = Convert.ToInt32(txtSubMenuOrder.Text);
                int MenuId = Convert.ToInt32(ddlMenuName.SelectedValue);
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
                    new SqlParameter{Value = SubMenuName,ParameterName = "@SubMenuName"},
                    new SqlParameter{Value = ddlMenuName.SelectedValue,ParameterName = "@MenuId"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@UpdatedBy"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@UpdateDate"},
                    new SqlParameter{Value = isActive,ParameterName = "@isActive"},
                    new SqlParameter{Value = MenuOrder,ParameterName = "@MenuOrder"},
                    new SqlParameter{Value = url,ParameterName = "@SubUrl"},
                    new SqlParameter{Value = id,ParameterName = "@id"},

                };
                int count = _db.ExecuteNonQuery("sp_SubMenu", sqlParameters);
                hidIdPrimary.Value = "";
                hidMenuId.Value = "";
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
                new SqlParameter{Value = ddlMenuName.SelectedValue,ParameterName = "@MenuId"},

            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_SubMenu", sqlParameters);
            grdSubMenu.DataSource = ds;
            grdSubMenu.DataBind();
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

           
            if (string.IsNullOrWhiteSpace(txtSubMenuOrder.Text))
            {
                msg += "Sub-Menu order is empty" + "<br>";
            }
            if (ddlMasterMenu.Items.Count == 0)
            {
                msg += "Please select Master menu" + "<br>";
            }
            if (ddlMenuName.Items.Count == 0)
            {
                msg += "Please select  menu" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                msg += "Sub-Menu order is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtSubMenu.Text))
            {
                msg += "Sub-Menu name is empty" + "<br>";
            }
            else if (btnSave.Text != "Update")
            {
                string query = "Select count(*) from [tbl_SubMenu] where SubMenuName='" + txtSubMenu.Text + "' and MenuId=" + ddlMenuName.SelectedValue + "";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "Sub-Menu name already exists for this  menu" + "<br/>";
                    }
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

       

        protected void ddlMasterMenu_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubMenu();
        }

        private void LoadSubMenu()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "menu",
                    ParameterName = "@type"
                },
                new SqlParameter
                {
                    Value = ddlMasterMenu.SelectedValue,
                    ParameterName = "@masterId"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetMenuNames", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlMenuName.DataSource = dsMenuDataSet;
                ddlMenuName.DataTextField = "MenuName";
                ddlMenuName.DataValueField = "id";
                ddlMenuName.DataBind();
            }
            else
            {
                ddlMenuName.Items.Clear();
            }
            LoadMenu();
        }
    }
}