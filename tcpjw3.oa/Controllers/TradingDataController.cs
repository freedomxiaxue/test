﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tcpjw3.oa.Models;

namespace tcpjw3.oa.Controllers
{
    public class TradingDataController : Controller
    {
        private tcpjwEntities db = new tcpjwEntities();

        // GET: TradingData
        public ActionResult Index()
        {
            return View(db.BAT_TradingData.ToList());
        }

        // GET: TradingData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_TradingData bAT_TradingData = db.BAT_TradingData.Find(id);
            if (bAT_TradingData == null)
            {
                return HttpNotFound();
            }
            return View(bAT_TradingData);
        }

        // GET: TradingData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TradingData/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CountM,YesDayCountM,AvergeTime,OperTime,backup1,backup2,backup3")] BAT_TradingData bAT_TradingData)
        {
            if (ModelState.IsValid)
            {
                db.BAT_TradingData.Add(bAT_TradingData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bAT_TradingData);
        }

        // GET: TradingData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_TradingData bAT_TradingData = db.BAT_TradingData.Find(id);
            if (bAT_TradingData == null)
            {
                return HttpNotFound();
            }
            return View(bAT_TradingData);
        }

        // POST: TradingData/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CountM,YesDayCountM,AvergeTime,OperTime,backup1,backup2,backup3")] BAT_TradingData bAT_TradingData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bAT_TradingData).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bAT_TradingData);
        }

        // GET: TradingData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BAT_TradingData bAT_TradingData = db.BAT_TradingData.Find(id);
            if (bAT_TradingData == null)
            {
                return HttpNotFound();
            }
            return View(bAT_TradingData);
        }

        // POST: TradingData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BAT_TradingData bAT_TradingData = db.BAT_TradingData.Find(id);
            db.BAT_TradingData.Remove(bAT_TradingData);
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
