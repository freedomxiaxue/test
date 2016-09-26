using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DevExpress.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 系统配置控制器
    /// </summary>
    public class SysConfigController : Controller
    {
        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();
        // GET: SysConfig
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SpliterMaster()
        {
            return PartialView();
        }
        [ValidateInput(false)]
        public ActionResult TreeListPartial()
        {
            var model = db.SysStatic;
            return PartialView("_TreeListPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialAddNew(tcpjw3.oa.Models.SysStatic item)
        {
            var model = db.SysStatic;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TreeListPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialUpdate(tcpjw3.oa.Models.SysStatic item)
        {
            var model = db.SysStatic;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_TreeListPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialDelete(System.Int32 ID)
        {
            var model = db.SysStatic;
            if (ID != null)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_TreeListPartial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult TreeListPartialMove(System.Int32 ID, System.Int32? PID)
        {
            var model = db.SysStatic;
            try
            {
                var item = model.FirstOrDefault(it => it.ID == ID);
                if (item != null)
                    item.PID = PID;
                db.SaveChanges();
            }
            catch (Exception e)
            {
                ViewData["EditError"] = e.Message;
            }
            return PartialView("_TreeListPartial", model);
        }
    }
}