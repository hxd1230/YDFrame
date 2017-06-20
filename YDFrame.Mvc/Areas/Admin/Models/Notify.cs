using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YDFrame.Mvc.Areas.Admin.Models
{
    public class Notify<T>
    {
        public Notify()
        {
            Status = StatusCode.Normal;
            Message = "成功";
        }
        public T Data { get; set; }
        public StatusCode Status { get; set; }
        public string Message { get; set; }
    }
    public enum StatusCode
    {
        Normal = 200,
        Error = 201,
    }
}