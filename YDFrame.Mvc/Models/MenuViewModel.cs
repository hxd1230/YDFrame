using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YDFrame.Mvc.Models
{
    public class ParentMenu
    {
        public int id { get; set; }
        public string name { get; set; }
        //public int id { get; set; }
        public string text { get; set; }
        //public List<ChildrenMenu> cMenu { get; set; }
        public List<ChildrenMenu> children { get; set; }
    }
    public class ChildrenMenu
    {
        //public int id { get; set; }
        public string text { get; set; }
        public string name { get; set; }
        //public string Name { get; set; }
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