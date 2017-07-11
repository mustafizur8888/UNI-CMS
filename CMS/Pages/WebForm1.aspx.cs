using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CMS.Pages
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProcessRequest();
            }
        }


        public void ProcessRequest()
        {
           
            Db db = new Db();
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter {Value = "1", ParameterName = "@RoleId"}
            };
            var listMenu = new List<Menu>();
            DataSet ds = db.GetDataSet("RoleWiseMenu", sqlParameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Menu menu = new Menu
                {
                    Id = Convert.ToInt32(row["Id"]),
                    MenuText = row["MenuText"].ToString(),
                    ParentId = row["ParentId"] != DBNull.Value
                        ? Convert.ToInt32(row["ParentId"])
                        : (int?)null
                };

                listMenu.Add(menu);
            }

            List<Menu> menuTree = GetMenuTree(listMenu, null);
            JavaScriptSerializer js = new JavaScriptSerializer();
            Response.Write(js.Serialize(menuTree.OrderBy(x => x.Id).ToList()));
        }
        public List<Menu> GetMenuTree(List<Menu> list, int? parent)
        {
            return list.Where(x => x.ParentId == parent).Select(x => new Menu
            {
                Id = x.Id,
                MenuText = x.MenuText,
                ParentId = x.ParentId,
                List = GetMenuTree(list, x.Id)
            }).ToList();
        }
    }
}