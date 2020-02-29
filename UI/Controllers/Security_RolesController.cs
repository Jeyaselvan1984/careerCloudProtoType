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
    public class Security_RolesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Security_Roles
        public ActionResult Index()
        {
            return View(db.Security_Roles.ToList());
        }

        // GET: Security_Roles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Roles security_Roles = db.Security_Roles.Find(id);
            if (security_Roles == null)
            {
                return HttpNotFound();
            }
            return View(security_Roles);
        }

        // GET: Security_Roles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Security_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Role,Is_Inactive")] Security_Roles security_Roles)
        {
            if (ModelState.IsValid)
            {
                security_Roles.Id = Guid.NewGuid();
                db.Security_Roles.Add(security_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(security_Roles);
        }

        // GET: Security_Roles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Roles security_Roles = db.Security_Roles.Find(id);
            if (security_Roles == null)
            {
                return HttpNotFound();
            }
            return View(security_Roles);
        }

        // POST: Security_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Role,Is_Inactive")] Security_Roles security_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(security_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(security_Roles);
        }

        // GET: Security_Roles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Roles security_Roles = db.Security_Roles.Find(id);
            if (security_Roles == null)
            {
                return HttpNotFound();
            }
            return View(security_Roles);
        }

        // POST: Security_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Security_Roles security_Roles = db.Security_Roles.Find(id);
            db.Security_Roles.Remove(security_Roles);
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
