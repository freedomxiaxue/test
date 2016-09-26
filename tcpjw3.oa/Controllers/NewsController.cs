using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 新闻控制器
    /// </summary>
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult Index()
        {
            return View();
        }
    }
}