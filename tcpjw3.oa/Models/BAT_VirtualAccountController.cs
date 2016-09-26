using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace tcpjw3.oa.Models
{
    public class BAT_VirtualAccountController : Controller
    {
        private TCPJW3Entities db = new TCPJW3Entities();

        // GET: BAT_VirtualAccount
        public ActionResult Index()
        {
            return View(db.BAT_VirtualAccount.ToList());
        }

        // GET: BAT_VirtualAccount/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_VirtualAccount bAT_VirtualAccount = db.BAT_VirtualAccount.Find(id);
            if (bAT_VirtualAccount == null)
            {
                return HttpNotFound();
            }
            return View(bAT_VirtualAccount);
        }

        // GET: BAT_VirtualAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BAT_VirtualAccount/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "YHBH,QYMC,LXR,LXRDH,XNZH,SJR,SJRDH,YJDZ,JS,SQSJ,SHJD,SHSJ,SHR,BZ,KDGS,KDDH,BankUp1,BankUp2,BankUp3,BankUp4,BankUp5")] BAT_VirtualAccount bAT_VirtualAccount)
        {
            if (ModelState.IsValid)
            {
                db.BAT_VirtualAccount.Add(bAT_VirtualAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bAT_VirtualAccount);
        }

        // GET: BAT_VirtualAccount/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_VirtualAccount bAT_VirtualAccount = db.BAT_VirtualAccount.Find(id);
            if (bAT_VirtualAccount == null)
            {
                return HttpNotFound();
            }
            return View(bAT_VirtualAccount);
        }

        // POST: BAT_VirtualAccount/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "YHBH,QYMC,LXR,LXRDH,XNZH,SJR,SJRDH,YJDZ,JS,SQSJ,SHJD,SHSJ,SHR,BZ,KDGS,KDDH,BankUp1,BankUp2,BankUp3,BankUp4,BankUp5")] BAT_VirtualAccount bAT_VirtualAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAT_VirtualAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bAT_VirtualAccount);
        }

        // GET: BAT_VirtualAccount/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_VirtualAccount bAT_VirtualAccount = db.BAT_VirtualAccount.Find(id);
            if (bAT_VirtualAccount == null)
            {
                return HttpNotFound();
            }
            return View(bAT_VirtualAccount);
        }

        // POST: BAT_VirtualAccount/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAT_VirtualAccount bAT_VirtualAccount = db.BAT_VirtualAccount.Find(id);
            db.BAT_VirtualAccount.Remove(bAT_VirtualAccount);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
