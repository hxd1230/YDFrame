using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YDFrame.Mvc.Models
{
    public class MenuBase
    {
        public int id { get; set; }
        public string icon { get; set; }
        public string text { get; set; }
    }
    public class ParentMenu : MenuBase
    {


        public List<ChildrenMenu> children { get; set; }
        //public string icon { get; set; }
    }
    public class ChildrenMenu : MenuBase
    {
        //public string text { get; set; }
        public string url { get; set; }

    }
    public class PowerParentMenu
    {
        public int isHide { get; set; }
        public int id { get; set; }
        public string text { get; set; }
        public string desc { get; set; }
        public List<PowerChildrenMenu> children { get; set; }
        public string icon { get; set; }
    }
    public class PowerChildrenMenu
    {
        public int isHide { get; set; }
        public int id { get; set; }
        public string text { get; set; }
        public string url { get; set; }
        public string desc { get; set; }
        public string icon { get; set; }
    }
}