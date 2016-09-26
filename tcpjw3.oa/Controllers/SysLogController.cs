using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 日志控制器
    /// </summary>
    public class SysLogController : Controller
    {
        // GET: SysLog
        public ActionResult ShowSysLog()
        {
            return View();
        }
        
        //tcpjw3.oa.Models.TCPJW_LogEntities db = new tcpjw3.oa.Models.TCPJW_LogEntities();

       // [ValidateInput(false)]
        //public ActionResult S_SysLogPartial()
        //{
        //    var model = db.Log;
        //    return PartialView("_S_SysLogPartial", model.OrderByDescending(l=>l.Date).ToList());
        //}
    }

}