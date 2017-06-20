using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YDFrame.Mvc.Models
{
    public class UserRoleViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string NickName { get; set; }
        public bool IsLock { get; set; }
        public DateTime CreateTime { get; set; }
        public string RoleName { get; set; }
    }
}