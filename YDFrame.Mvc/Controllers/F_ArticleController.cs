using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YDFrame.IBLL;
using YDFrame.Models;

namespace YDFrame.Mvc.Controllers
{
    public class F_ArticleController : Controller
    {
        [Dependency]
        public IYD_ArticleService _articleService { get; set; }
        public ActionResult Articles()
        {
            List<YD_Article> articles = _articleService.LoadEntities(c => true).OrderByDescending(c => c.CreateTime).ToList();
            return View(articles);
        }
        public ActionResult Details(int id)
        {
            YD_Article entity = _articleService.LoadEntities(c => c.Id == id).SingleOrDefault();
            return View(entity);
        }
    }
}
