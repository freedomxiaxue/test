using DevExpress.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;
using tcpjw3.oa.Models;
using DevExpress.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    /// <summary>
    /// 价格走势控制器
    /// </summary>
    public class QuoteStatisticController : Controller
    {
        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        // GET: QuoteStatistic
        public ActionResult Index()
        {
            //return View(dataContext.QuoteStatistic);
            return View();
        }

        public ActionResult SpliterMaster()
        {
            return PartialView();
        }

        [ValidateInput(false)]
        public ActionResult IndexPartial()
        {
            var model = db.QuoteStatistic.OrderByDescending(i=>i.Date);
            return PartialView("_IndexPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult IndexPartialAddNew([Bind(Include = "GG,DS,QT,Date")]tcpjw3.oa.Models.QuoteStatistic item)
        {
            var model = db.QuoteStatistic;
            item.XS = item.DS;
            item.Type = 1;
            var fixItem = model.FirstOrDefault(it => it.Date.CompareTo(item.Date.ToString("yyyy-MM-dd")) >= 0 && it.Date.CompareTo(item.Date.AddDays(1).ToString("yyyy-MM-dd")) <= 0);
            if (fixItem == null)
            {
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
                {
                    ViewData["EditError"] = "Please, correct all errors.";
                }

            }
            else
            {
                ViewData["EditError"] = "该日期已经添加过了.";

            }


            return PartialView("_IndexPartial", model.OrderByDescending(i => i.Date));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult IndexPartialUpdate([Bind(Include = "ID,GG,DS,QT,Date")]tcpjw3.oa.Models.QuoteStatistic item)
        {

                var model = db.QuoteStatistic;
                item.XS = item.DS;
                item.Type = 1;

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
                {
                    ViewData["EditError"] = "Please, correct all errors.";
                }


          //return  IndexPartial();
            return PartialView("_IndexPartial", model.OrderByDescending(i => i.Date));
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult IndexPartialDelete(System.Int32 ID)
        {
            var model = db.QuoteStatistic;
            if (ID >= 0)
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
            return PartialView("_IndexPartial", model);
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }


}