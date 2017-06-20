using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace YDFrame.Mvc.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreateTime { get; set; }

        public Nullable<int> UserId { get; set; }
        public string See { get; set; }
    }
}