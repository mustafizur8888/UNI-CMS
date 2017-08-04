using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CMS.Models;
using DAL;

namespace CMS.Pages.ServiceConfig
{
    public partial class ChargingType : System.Web.UI.Page
    {
        Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {


            }
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


        public bool Validation()
        {
            string msg = string.Empty;
            bool result = true;
            if (string.IsNullOrWhiteSpace(txtCType.Text))
            {
                msg += "Charging type is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(msg))
            {
                result = false;
                ShowError(msg);
            }
            return result;

        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (Validation())
            {
                SqlParameter Id = new SqlParameter
                {
                    Value = "",
                    ParameterName = "@Id"
                };
                SqlParameter Type = new SqlParameter
                {
                    Value = txtCType.Text,
                    ParameterName = "@Type"
                };
                SqlParameter Action = new SqlParameter
                {
                    Value = "",
                    ParameterName = "@Action"
                };

                List<SqlParameter> list = new List<SqlParameter>
                {
                    Id,
                    Type,
                    Action,
                    new SqlParameter
                    {
                        ParameterName = "@IsActive",
                        Value = chkActive.Checked
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Created_By",
                        Value = UserModel.UserId
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Updated_By",
                        Value = UserModel.UserId
                    }
                };

                _db.ExecuteNonQuery("SpChargingType", list);
            }
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {
            Initialization();
        }

        private void Initialization()
        {
            txtCType.Text = string.Empty;
            chkActive.Checked = false;
        }
    }
}