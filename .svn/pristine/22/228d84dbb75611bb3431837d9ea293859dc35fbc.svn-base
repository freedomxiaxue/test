using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Views.GoldAccount
{
    public class GoldAccountController : Controller
    {
        // GET: GoldAccount
        public ActionResult Index()
        {
            return View();
        }

        tcpjw3.oa.Models.tcpjwEntities db = new tcpjw3.oa.Models.tcpjwEntities();

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            var model = db.BAT_GoldAccount;
            return PartialView("_GridView1Partial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew([Bind(Include = "Userid,CjrecvAccNo,RecvAccNm,CjsameBank,CjrecvTgfi,CjrecvBankNm")] tcpjw3.oa.Models.BAT_GoldAccount item)
        {
            var model = db.BAT_GoldAccount;
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
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(tcpjw3.oa.Models.BAT_GoldAccount item)
        {
            var model = db.BAT_GoldAccount;
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
            return PartialView("_GridView1Partial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 ID)
        {
            var model = db.BAT_GoldAccount;
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
            return PartialView("_GridView1Partial", model.ToList());
        }
    }
}