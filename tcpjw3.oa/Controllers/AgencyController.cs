using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Controllers
{
    public class AgencyController : Controller
    {
        // GET: Agency
        public ActionResult ShowAgencyList()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult AgencyListPartial()
        {
            var model = db.UserMap;
            return PartialView("_AgencyListPartial", model.OrderByDescending(um => um.ID).ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AgencyListPartialAddNew([Bind(Include = "AgencyId,UserId,Note")]tcpjw3.oa.Models.UserMap item)
        {
            var model = db.UserMap;
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
            return PartialView("_AgencyListPartial", model.OrderByDescending(um => um.ID).ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult AgencyListPartialUpdate(tcpjw3.oa.Models.UserMap item)
        {
            var model = db.UserMap;
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
            return PartialView("_AgencyListPartial", model.OrderByDescending(um => um.ID).ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult AgencyListPartialDelete(System.Int32 ID)
        {
            var model = db.UserMap;
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
            return PartialView("_AgencyListPartial", model.OrderByDescending(um => um.ID).ToList());
        }
    }
}