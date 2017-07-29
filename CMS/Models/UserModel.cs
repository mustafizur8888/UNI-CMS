using System.Collections.Generic;

namespace CMS.Models
{
    public static class UserModel
    {
        public static string UserName { get; set; }
        public static string UserId { get; set; }
        public static string UserRole { get; set; }

        public static List<Menu> Menus { get; set; }
    }
}