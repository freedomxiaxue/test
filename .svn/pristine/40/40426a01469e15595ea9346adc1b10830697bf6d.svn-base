using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    public class ShowCodeController : Controller
    {
        // GET: ShowCode
        public ActionResult ShowCodeList()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult CodeListPartial()
        {
            var model = db.UserRegistCode;
            return PartialView("_CodeListPartial", model.OrderByDescending(cl=>cl.ExecTime).ToList());
        }
    }
}