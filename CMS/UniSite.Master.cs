using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using CMS.Models;

namespace CMS
{
    public partial class UniSite : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User"] == null)
            {
                Response.Redirect("~/Pages/Management/Login.aspx");
            }
            string SOURCE_URL = System.Web.HttpContext.Current.Request.Url.AbsolutePath;
            bool hasAccess = false;
            if (UserModel.Menus != null)
            {
                //bool test = false;
                foreach (var VARIABLE in UserModel.Menus.SelectMany(x => x.List))
                {
                    hasAccess = VARIABLE.Url.Contains(SOURCE_URL.Substring(1, SOURCE_URL.Length - 1));
                    if (hasAccess == true)
                    {
                        break;
                    }
                }
                if (!hasAccess)
                {
                 //   Response.Redirect("~/Pages/Home.aspx");
                }
                //var any = UserModel.Menus.Any(x => x.Url.Contains(SOURCE_URL.Substring(1,SOURCE_URL.Length-1)));
            }
            lblUserName.Text = UserModel.UserName;



        }

    }
}