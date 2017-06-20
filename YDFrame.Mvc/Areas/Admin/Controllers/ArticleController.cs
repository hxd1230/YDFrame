using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;
using YDFrame.Mvc.Areas.Admin.Models;
using YDFrame.Mvc.Models;

namespace YDFrame.Mvc.Areas.Admin.Controllers
{
    public class ArticleController : Controller
    {
        [Dependency]
        public IYD_ArticleService _articleService { get; set; }
        public ActionResult Articles()
        {
            return View();
        }
        public JsonResult GetArticles()
        {
            List<ArticleViewModel> articles = _articleService.LoadEntities(c => true).Select(c => new ArticleViewModel { Content = c.Content, CreateTime = (DateTime)c.CreateTime, Id = c.Id, See = "<a href='javascript:;' onclick='details(" + c.Id + ")'>查看</a>", Title = c.Title, UserId = c.UserId }).ToList();
            Notify<List<ArticleViewModel>> notify = new Notify<List<ArticleViewModel>>
            {
                Data = articles
            };
            int count = articles.Count;
            return Json(new { total = articles.Count, rows = articles.ToArray() }, JsonRequestBehavior.AllowGet);
        }
        [ValidateInput(false)]
        [HttpPost]
        public JsonResult AddArticle()
        {
            Notify<bool> notify = new Notify<bool>();
            string title = Request["title"];
            string content = Request["content"];
            YD_Article entity = new YD_Article
            {
                Content = content,
                Title = title,
                CreateTime = DateTime.Now,
                UserId = 1
            };
            if (_articleService.AddEntity(entity) != null)
            {
                notify.Data = true;
            }
            else
            {
                notify.Data = false;
            }
            return Json(notify, JsonRequestBehavior.AllowGet);
        }
    }
}
