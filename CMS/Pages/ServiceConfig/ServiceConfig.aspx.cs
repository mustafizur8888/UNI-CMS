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
    public partial class ServiceConfig : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {
            divError.Visible = false;
            divSucc.Visible = false;
            if (!IsPostBack)
            {
                LoadChargingType();
            }
        }

        private bool Validation()
        {
            bool result = true;

            string msg = string.Empty;

            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                msg += "Service name is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtServiceIdTelco.Text))
            {
                msg += "Service id telco is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtKeWord.Text))
            {
                msg += "Key word is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtTypeOfService.Text))
            {
                msg += "Type of service is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtTypeOfService.Text))
            {
                msg += "Type of service is empty" + "<br>";
            }
            if (string.IsNullOrWhiteSpace(txtDailySms.Text))
            {
                msg += "Number of Daily sms is empty" + "<br>";
            }
            if (!string.IsNullOrWhiteSpace(txtDailySms.Text))
            {
                if (!txtDailySms.Text.All(Char.IsDigit))
                {
                    msg += "Number of Daily sms is not valid number" + "<br>";
                }
            }
            if (string.IsNullOrWhiteSpace(txtSMSScripts.Text))
            {
                msg += "SMS scripst is empty" + "<br>";
            }
            if (!string.IsNullOrWhiteSpace(msg))
            {
                ShowError(msg);
                result = false;
            }


            return result;
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


        protected void btnSave_OnClick(object sender, EventArgs e)
        {

            if (Validation())
            {
                List<SqlParameter> list = new List<SqlParameter>
                {
                    new SqlParameter
                    {
                        Value = string.IsNullOrWhiteSpace(hidId.Value)?"0":hidId.Value,
                        ParameterName = "@Id"
                    },
                    new SqlParameter
                    {
                        Value = txtServiceName.Text,
                        ParameterName = "@ServiceName"
                    },
                    new SqlParameter
                    {
                        Value = txtServiceIdTelco.Text,
                        ParameterName = "@ServiceIdTelco"
                    },
                    new SqlParameter
                    {
                        Value = txtKeWord.Text,
                        ParameterName = "@KeyWord"
                    },
                    new SqlParameter
                    {
                        Value = txtTypeOfService.Text,
                        ParameterName = "@TypeOfService"
                    },
                    new SqlParameter
                    {
                        Value = ddlChargingType.SelectedValue,
                        ParameterName = "@ChargingType"
                    },
                    new SqlParameter
                    {
                        Value = txtDailySms.Text,
                        ParameterName = "@DailySMS"
                    },
                    new SqlParameter
                    {
                        Value = txtSMSScripts.Text,
                        ParameterName = "@SMSScripts"
                    },
                    new SqlParameter
                    {
                        Value = chkActive.Checked,
                        ParameterName = "@IsActive"
                    },
                    new SqlParameter
                    {
                        Value = UserModel.UserId,
                        ParameterName = "@Created_By"
                    },
                    new SqlParameter
                    {
                        Value = UserModel.UserId,
                        ParameterName = "@Updated_By"
                    }
                };

                int c = _db.ExecuteNonQuery("SPtServiceConfigInsertUpdate", list);
                if (c > 0)
                {
                    ShowSucc(string.IsNullOrWhiteSpace(hidId.Value) ? "Saved Successfully" : "Update Successfully");
                    Initialization();
                    ShowGrd();
                }
                else
                {
                    ShowError(string.IsNullOrWhiteSpace(hidId.Value) ? "Faield to saved" : "Faield to update");

                }
            }
        }

        protected void btnCanel_OnClick(object sender, EventArgs e)
        {
            Initialization();
        }

        private void LoadChargingType()
        {
            DataSet dataSet = _db.GetDataSet("SpDdlGetChargingType");
            ddlChargingType.DataSource = dataSet;
            ddlChargingType.DataValueField = "Id";
            ddlChargingType.DataTextField = "Type";
            ddlChargingType.DataBind();

        }

        private void Initialization()
        {
            txtDailySms.Text = string.Empty;
            txtKeWord.Text = string.Empty;
            txtSMSScripts.Text = String.Empty;
            hidId.Value = String.Empty;
            txtServiceIdTelco.Text = string.Empty;
            txtServiceName.Text = string.Empty;
            txtTypeOfService.Text = string.Empty;
            ddlChargingType.SelectedIndex = 0;
            chkActive.Checked = false;
        }

        private void ShowGrd()
        {
            DataSet ds = _db.GetDataSet("SPtbl_ServiceConfig");
            grdServiceConfig.DataSource = ds;
            grdServiceConfig.DataBind();
        }

        protected void btnLoad_OnClick(object sender, EventArgs e)
        {
            ShowGrd();
        }

        protected void grdDelete_OnClick(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            GridViewRow gvr = (GridViewRow)btn.NamingContainer;
            string id = ((HiddenField)gvr.FindControl("hidId")).Value;
            List<SqlParameter> list = new List<SqlParameter>
            {
                new SqlParameter
                {
                    Value = id,
                    ParameterName = "@Id"
                }
            };
            int executeNonQuery = _db.ExecuteNonQuery("SPServiceConfigDelete", list);
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
            string query = @"Select * from tbl_ServiceConfig
            where id ='" + id + "'";
            DataSet ds = _db.GetDataSet(query);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                hidId.Value = id;
                txtDailySms.Text = dr["DailySMS"].ToString();
                txtSMSScripts.Text = dr["SMSScripts"].ToString();
                ddlChargingType.SelectedValue = dr["ChargingType"].ToString();
                txtTypeOfService.Text = dr["TypeOfService"].ToString();
                txtKeWord.Text = dr["KeyWord"].ToString();
                txtServiceIdTelco.Text = dr["ServiceIdTelco"].ToString();
                txtServiceName.Text = dr["ServiceName"].ToString();
                chkActive.Checked = Convert.ToBoolean(dr["IsActive"]);
            }

        }
    }
}