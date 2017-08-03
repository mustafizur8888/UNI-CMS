using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Models;
using DAL;

namespace AMAR.Web.Pages.CMS
{
    public partial class User : Page
    {
        private Db _db = new Db();

        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                MasterRoleLoad();
            }
        }

        private void MasterRoleLoad()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = "master",
                    ParameterName = "@type"
                },

            };
            DataSet dsMenuDataSet = _db.GetDataSet("sp_GetRoles", sqlParameters);
            if (dsMenuDataSet != null && dsMenuDataSet.Tables[0].Rows.Count > 0)
            {
                ddlRole.DataSource = dsMenuDataSet;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "id";
                ddlRole.DataBind();
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
            string UserName = ((Label)gvr.FindControl("lblUserName")).Text;
            string FullName = ((Label)gvr.FindControl("lblName")).Text;
            string RoleId = ((Label)gvr.FindControl("lblRoleId")).Text;
            string Email = ((Label)gvr.FindControl("lblEmail")).Text;
            string Phone = ((Label)gvr.FindControl("lblPhone")).Text;
            string Password = ((Label)gvr.FindControl("lblPassword")).Text;
            string Designation = ((Label)gvr.FindControl("lblDesignation")).Text;
            string Company = ((Label)gvr.FindControl("lblCompany")).Text;
            string Status = ((Label)gvr.FindControl("lblIsActive")).Text;
            string PrimaryId = ((HiddenField)gvr.FindControl("hidId")).Value;
            hidIdPrimary.Value = PrimaryId;
            checkIsActive.Checked = Status == "True";
            txtUserName.Text = UserName;
            txtFullName.Text = FullName;
            ddlRole.SelectedValue = RoleId;
            txtEmail.Text = Email;
            txtPhoneNumber.Text = Phone;
            txtDesignation.Text = Designation;
            txtCompany.Text = Company;
            txtPassword.Text = Password;
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
                count = _db.ExecuteNonQuery("sp_UserManagement", sqlParameters);
            }
            catch (Exception exception)
            {
                ShowErrorMsg(exception.Message);
            }

            if (count > 0)
            {
                ShowSuccMsg("Delete Successfully");
                LoadUsers();
            }
            else
            {
                ShowErrorMsg("Failed To Delete");
            }
        }

        private void Clear()
        {
            txtUserName.Text = String.Empty;
            txtFullName.Text = String.Empty;
            txtCompany.Text = String.Empty;
            txtDesignation.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtPhoneNumber.Text = String.Empty;
            txtPassword.Text = String.Empty;
            checkIsActive.Checked = false;
            hidIdPrimary.Value = "";
            btnSave.Text = "Save";
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {


                string UserName = txtUserName.Text;
                string FullName = txtFullName.Text;
                string Company = txtCompany.Text;
                string Designation = txtDesignation.Text;
                string Email = txtEmail.Text;
                string PhoneNumber = txtPhoneNumber.Text;

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
                string Password = txtPassword.Text;
                string encryptedstring = HelperEncription.StringCipher.Encrypt(Password, Password);
                string decryptedstring = HelperEncription.StringCipher.Decrypt(encryptedstring, Password);
                DateTime CreateDate = DateTime.Now;
                bool isActive = checkIsActive.Checked;
                string type = hidIdPrimary.Value;
                string idVal = hidIdPrimary.Value;
                int id = 0;
                id = idVal != "" ? Convert.ToInt32(idVal) : 0;
                bool status = checkIsActive.Checked;
                type = type == "" ? "insert" : "update";
                List<SqlParameter> sqlParameters = new List<SqlParameter>
                {
                    new SqlParameter{Value = type,ParameterName = "@type"},
                    new SqlParameter{Value = txtUserName.Text,ParameterName = "@UserName"},
                    new SqlParameter{Value = txtFullName.Text,ParameterName = "@Name"},
                    new SqlParameter{Value = ddlRole.SelectedValue,ParameterName = "@roleid"},
                    new SqlParameter{Value = encryptedstring,ParameterName = "@Password"},
                    new SqlParameter{Value = CreatedBy,ParameterName = "@CreatedBy"},
                    new SqlParameter{Value = UpdatedBy,ParameterName = "@Update_By"},
                    new SqlParameter{Value =CreateDate,ParameterName = "@CreateDate"},
                    new SqlParameter{Value = CreateDate,ParameterName = "@Update_Date"},
                    new SqlParameter{Value = txtEmail.Text,ParameterName = "@Email"},
                    new SqlParameter{Value = txtPhoneNumber.Text,ParameterName = "@Phone"},
                    new SqlParameter{Value = txtDesignation.Text,ParameterName = "@Designation"},
                    new SqlParameter{Value = txtCompany.Text,ParameterName = "@Company"},
                    new SqlParameter{Value = status,ParameterName = "@IsActive"},
                    new SqlParameter{Value = id,ParameterName = "@id"},
                    new SqlParameter{Value = txtPassword.Text,ParameterName = "@PasswordRaw"},

                };
                hidIdPrimary.Value = "";
                int count = _db.ExecuteNonQuery("sp_UserManagement", sqlParameters);
                if (count > 0)
                {
                    ShowSuccMsg(type == "update" ? "Updated Successfully" : "Saved Successfully");
                    Clear();
                    LoadUsers();

                }
            }
        }

        private void LoadUsers()
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = "select",ParameterName = "@type"},
            };
            DataSet ds = null;
            ds = _db.GetDataSet("sp_UserManagement", sqlParameters);
            grdUser.DataSource = ds;
            grdUser.DataBind();
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

            if (string.IsNullOrWhiteSpace(txtUserName.Text))
            {
                msg += "User name is empty" + "<br>";
            }
            else if(btnSave.Text != "Update")
            {

                string query = "Select count(*) from [tbl_User] where [UserName]='" + txtUserName.Text + "'";
                string value = _db.GetSingelValue(query);
                if (!string.IsNullOrEmpty(value))
                {
                    if (value != "0")
                    {
                        msg += "User Name already exists" + "<br/>";
                    }
                }

            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                msg += "Full name is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtCompany.Text))
            {
                msg += "Company name is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtDesignation.Text))
            {
                msg += "Designation is empty" + "<br>";
            }
            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                if (!IsEmail(txtEmail.Text))
                {
                    msg += "Email address is not valid" + "<br>";

                }
            }
            else
            {
                msg += "Email address is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtPhoneNumber.Text))
            {
                msg += "Phone number is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                msg += "Password is empty" + "<br>";
            }
            if (ddlRole.Items.Count == 0)
            {
                msg += "Please select role" + "<br>";
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
            LoadUsers();
        }







        protected void ddlRole_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            //
        }
        public static bool IsEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }





    }
}