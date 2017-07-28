using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using DAL;

namespace CMS
{
    public class Menu
    {
        public int Id { get; set; }
        public string MenuText { get; set; }
        public string Url { get; set; }
        public int? ParentId { get; set; }
        public List<Menu> List { get; set; }
    }
    public class MenuHandler : IHttpHandler
    {
        private Db _db= new Db();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
          
            List<SqlParameter> sqlParameters = new List<SqlParameter>
            {
                new SqlParameter {Value = "1", ParameterName = "@RoleId"}
            };
            var listMenu = new List<Menu>();
            DataSet ds = _db.GetDataSet("RoleWiseMenu", sqlParameters);

            foreach (DataRow row in ds.Tables[0].Rows)
            {
                Menu menu = new Menu
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Url= row["Url"].ToString(),
                    MenuText = row["MenuText"].ToString(),
                    ParentId = row["ParentId"] != DBNull.Value
                        ? Convert.ToInt32(row["ParentId"])
                        : (int?) null
                };

                listMenu.Add(menu);
            }
            
            List<Menu> menuTree = GetMenuTree(listMenu, null);
            JavaScriptSerializer js = new JavaScriptSerializer();
            context.Response.Write(js.Serialize(menuTree.OrderBy(x => x.Id).ToList()));
        }
        public List<Menu> GetMenuTree(List<Menu> list, int? parent)
        {
            return list.Where(x => x.ParentId == parent).Select(x => new Menu
            {
                Id = x.Id,
                MenuText = x.MenuText,
                ParentId = x.ParentId,
                Url = x.Url,
                List = GetMenuTree(list, x.Id)
            }).ToList();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}