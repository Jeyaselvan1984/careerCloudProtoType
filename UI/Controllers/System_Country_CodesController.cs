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
    public class System_Country_CodesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: System_Country_Codes
        public ActionResult Index()
        {
            return View(db.System_Country_Codes.ToList());
        }

        // GET: System_Country_Codes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Country_Codes system_Country_Codes = db.System_Country_Codes.Find(id);
            if (system_Country_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Country_Codes);
        }

        // GET: System_Country_Codes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: System_Country_Codes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name")] System_Country_Codes system_Country_Codes)
        {
            if (ModelState.IsValid)
            {
                db.System_Country_Codes.Add(system_Country_Codes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(system_Country_Codes);
        }

        // GET: System_Country_Codes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Country_Codes system_Country_Codes = db.System_Country_Codes.Find(id);
            if (system_Country_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Country_Codes);
        }

        // POST: System_Country_Codes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name")] System_Country_Codes system_Country_Codes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(system_Country_Codes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(system_Country_Codes);
        }

        // GET: System_Country_Codes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            System_Country_Codes system_Country_Codes = db.System_Country_Codes.Find(id);
            if (system_Country_Codes == null)
            {
                return HttpNotFound();
            }
            return View(system_Country_Codes);
        }

        // POST: System_Country_Codes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            System_Country_Codes system_Country_Codes = db.System_Country_Codes.Find(id);
            db.System_Country_Codes.Remove(system_Country_Codes);
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
