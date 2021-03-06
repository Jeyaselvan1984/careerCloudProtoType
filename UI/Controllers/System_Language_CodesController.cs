﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace UI.Controllers
{
    public class System_Language_CodesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: System_Language_Codes
        public ActionResult Index()
        {
            return View(db.System_Language_Codes.ToList());
        }

        // GET: System_Language_Codes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Language_Codes system_Language_Codes = db.System_Language_Codes.Find(id);
            if (system_Language_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Language_Codes);
        }

        // GET: System_Language_Codes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System_Language_Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LanguageID,Name,Native_Name")] System_Language_Codes system_Language_Codes)
        {
            if (ModelState.IsValid)
            {
                db.System_Language_Codes.Add(system_Language_Codes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(system_Language_Codes);
        }

        // GET: System_Language_Codes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Language_Codes system_Language_Codes = db.System_Language_Codes.Find(id);
            if (system_Language_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Language_Codes);
        }

        // POST: System_Language_Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LanguageID,Name,Native_Name")] System_Language_Codes system_Language_Codes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(system_Language_Codes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(system_Language_Codes);
        }

        // GET: System_Language_Codes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Language_Codes system_Language_Codes = db.System_Language_Codes.Find(id);
            if (system_Language_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Language_Codes);
        }

        // POST: System_Language_Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            System_Language_Codes system_Language_Codes = db.System_Language_Codes.Find(id);
            db.System_Language_Codes.Remove(system_Language_Codes);
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
