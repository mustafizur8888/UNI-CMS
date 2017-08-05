using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.UI.WebControls;
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
                ShowGrd();
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
            if (string.IsNullOrWhiteSpace(txtDayDuration.Text))
            {
                msg += "Day Duration is empty" + "<br>";
            }
            if (!string.IsNullOrWhiteSpace(txtDayDuration.Text))
            {
                if (!txtDayDuration.Text.All(Char.IsDigit))
                {
                    msg += "Day Duration is not valid number" + "<br>";
                }

            }
            if (!string.IsNullOrWhiteSpace(msg))
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
                SqlParameter id = new SqlParameter
                {
                    Value = string.IsNullOrWhiteSpace(hidId.Value) ? "0" : hidId.Value,
                    ParameterName = "@Id"
                };
                SqlParameter action = new SqlParameter
                {
                    Value = string.IsNullOrWhiteSpace(hidId.Value) ? "Insert" : "Update",
                    ParameterName = "@Action"
                };

                List<SqlParameter> list = new List<SqlParameter>
                {
                    id,
                    action,
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
                    },
                    new SqlParameter
                    {
                        ParameterName = "@DayDuration",
                        Value = txtDayDuration.Text
                    },new  SqlParameter
                    {
                        Value = txtCType.Text,
                        ParameterName = "@Type"
                    }
            };
                int c = _db.ExecuteNonQuery("SpChargingType", list);
                if (c > 0)
                {
                    ShowSucc(string.IsNullOrWhiteSpace(hidId.Value) ? "Saved Successfully" : "Update Successfully");

                    ShowGrd();
                    Initialization();
                }
                else
                {
                    ShowError(string.IsNullOrWhiteSpace(hidId.Value) ? "Faield to saved" : "Faield to update");
                }
            }
        }

        private void ShowGrd()
        {
            DataSet ds = _db.GetDataSet("SpGetChargingType");

            grdServiceType.DataSource = ds;
            grdServiceType.DataBind();
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {
            Initialization();
        }

        private void Initialization()
        {
            txtCType.Text = string.Empty;
            chkActive.Checked = false;
            txtDayDuration.Text = String.Empty;
            hidId.Value = String.Empty;
        }

        protected void grdDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidId")).Value;
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = id,ParameterName = "@Id"},
                new SqlParameter{Value = "Delete",ParameterName = "@Action"}
            };
            int executeNonQuery = _db.ExecuteNonQuery("SpChargingType", sqlParameters);
            if (executeNonQuery > 0)
            {
                ShowSucc("Successfully Deleted");
                ShowGrd();
            }
            else
            {
                ShowError("Failed To Delete");
            }
        }

        protected void grdEdit_OnClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidId")).Value;
            string type = ((Label)gvr.FindControl("lblType")).Text;
            string dayDuration = ((Label)gvr.FindControl("lblDayDuration")).Text;
            string active = ((Label)gvr.FindControl("lblIsActive")).Text;

            txtDayDuration.Text = dayDuration;
            txtCType.Text = type;
            chkActive.Checked = active == "True";
            hidId.Value = id;

        }
    }
}