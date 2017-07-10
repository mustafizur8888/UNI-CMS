using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS
{
    public partial class UniSite : System.Web.UI.MasterPage
    {
       

        DataTable allCategories = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {



            //if (Session[KeyConstant.session_username] == null)
            //{
            //    Response.Redirect("~/logon.aspx");
            //}
            //else
            //{
            //    if (Session[KeyConstant.session_username].ToString() == "unifon")
            //    {

            //              DataTable dt = new DataTable();
            //    CDA obj = new CDA();
            //    dt = obj.GetDataTable("EXEC spMenu 222, " + Session[KeyConstant.session_roleid] + "", ConnectionString.CN_CP);

            //    allCategories = obj.GetDataTable("EXEC spMenu 333, " + Session[KeyConstant.session_roleid] + "", ConnectionString.CN_CP);
            //    //allCategories = obj.GetDataTable("EXEC spMenu 0, " + Session[KeyConstant.session_userid] + "", ConnectionString.CN_CP);
            //    rptSlider.DataSource = dt;
            //    rptSlider.DataBind();

            //    UserDetailsLoad();
            //    }
            //    else{
            //          DataTable dt = new DataTable();
            //    CDA obj = new CDA();
            //    dt = obj.GetDataTable("EXEC spMenu 1, " + Session[KeyConstant.session_roleid] + "", ConnectionString.CN_CP);

            //    allCategories = obj.GetDataTable("EXEC spMenu 0, " + Session[KeyConstant.session_roleid] + "", ConnectionString.CN_CP);
            //    //allCategories = obj.GetDataTable("EXEC spMenu 0, " + Session[KeyConstant.session_userid] + "", ConnectionString.CN_CP);
            //    rptSlider.DataSource = dt;
            //    rptSlider.DataBind();

            //    UserDetailsLoad();
            //    }
              
            //}
        }

        protected void rptSlider_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            //if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            //{
            //    if (allCategories != null)
            //    {
            //        DataRowView drv = e.Item.DataItem as DataRowView;
            //        string ID = drv["menu_id"].ToString();
            //        DataRow[] rows = allCategories.Select("menu_parentid=" + ID, "menu_name");
            //        if (rows.Length > 0)
            //        {
            //            //StringBuilder sb = new StringBuilder();
            //            //sb.Append("<ul>");
            //            //foreach (var item in rows)
            //            //{
            //            //    //sb.Append("<li><a href=" + item["menu_url"] + ">" + "<i class=" + item["icon"] + "></i>  " + item["menu_name"] + "");
            //            //    sb.Append("<li><a href=" + item["menu_url"] + "class=" + "sidebar-nav-menu" + ">" +
            //            //        "< i class=" + "fa fa-angle-left sidebar-nav-indicator sidebar-nav-mini-hide" + ">" + "</i>" +
            //            //        "< i class=" + "gi gi-shopping_cart sidebar-nav-icon" + "></i><span class=" + "sidebar-nav-mini-hide>" + item["menu_name"] + "</span>");

            //            //       //"<i class=" + item["icon"] + "></i>  " + item["menu_name"] + "");
            //            //    //sb.Append("<li><a href='#'><i class=" + item["icon"] + " </i>" + item["menu_name"] + "</a></li>");
            //            //}
            //            //sb.Append("</a></li></ul>");
            //            //(e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
            //            //=======================================================
            //            StringBuilder sb = new StringBuilder();
            //            sb.Append("<ul>");
            //            foreach (var item in rows)
            //            {
            //                sb.Append("<li><a href=" + item["menu_url"] + ">" + item["menu_name"] + "");
            //                //sb.Append("<li><a href='#'><i class=" + item["icon"] + " </i>" + item["menu_name"] + "</a></li>");
            //            }
            //            sb.Append("</a></li></ul>");
            //            (e.Item.FindControl("ltrlSubMenu") as Literal).Text = sb.ToString();
            //        }
            //    }
            
        }

        private void UserDetailsLoad()
        {
        //    DataTable dt = new DataTable();
        //    CDA obj = new CDA();

        //    dt = obj.GetDataTable("EXEC spUser 4,'','" + Session[KeyConstant.session_username] + "'", ConnectionString.CN_CP);
        //    //profileImg.Src = !string.IsNullOrEmpty(dt.Rows[0]["ProfileImage"].ToString()) ? dt.Rows[0]["ProfileImage"].ToString() : "~/img/placeholders/avatars/avatar2.jpg";
        //    usrName.InnerText = dt.Rows[0]["UserName"].ToString();

        //    //spnUserName.InnerText = dt.Rows[0]["name"].ToString();
        }

        protected void btnLogOut_OnClick(object sender, EventArgs e)
        {
            
            //Session.Abandon();
            //Session.RemoveAll();
            //Response.Redirect("LogOn.aspx");
        }
    }
}