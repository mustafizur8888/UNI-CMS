﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using  System.Data;
using CMS.Models;
using DAL;

namespace CMS.Pages.Management
{
    public partial class Login : System.Web.UI.Page
    {
        private Db _db = new Db();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBeforeOk_OnServerClick(object sender, EventArgs e)
        {
           // throw new NotImplementedException();
           Response.Write("hi");
        }

        protected void btnSubmit_OnClick(object sender, EventArgs e)

        {
            string UserName = txtUserName.Value;
            string Password = txtPassword.Value;

            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter{Value = UserName,ParameterName = "@Name"},
                new SqlParameter{Value = Password,ParameterName = "@password"},
            };
           
            DataSet ds = _db.GetDataSet("sp_userLoginAuthentication", sqlParameters);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string tt = ds.Tables[0].Rows[0]["Retvalue"].ToString();
                if (tt == "Exists")
                {
                    Session["User"] = ds.Tables[0].Rows[0]["Name"].ToString();
                    UserModel.UserRole = ds.Tables[0].Rows[0]["roleid"].ToString();
                    UserModel.UserId = ds.Tables[0].Rows[0]["UserId"].ToString();
                    UserModel.UserName = ds.Tables[0].Rows[0]["Name"].ToString();
                    Response.Redirect("~/Pages/Home.aspx");
                }
                else
                {
                    //failed.Visible = true;
                }
                
            }


           
        }
    }
}