using System;
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
    public class Security_Logins_RolesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Security_Logins_Roles
        public ActionResult Index()
        {
            var security_Logins_Roles = db.Security_Logins_Roles.Include(s => s.Security_Logins).Include(s => s.Security_Roles);
            return View(security_Logins_Roles.ToList());
        }

        // GET: Security_Logins_Roles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins_Roles security_Logins_Roles = db.Security_Logins_Roles.Find(id);
            if (security_Logins_Roles == null)
            {
                return HttpNotFound();
            }
            return View(security_Logins_Roles);
        }

        // GET: Security_Logins_Roles/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login");
            ViewBag.Role = new SelectList(db.Security_Roles, "Id", "Role");
            return View();
        }

        // POST: Security_Logins_Roles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Role,Time_Stamp")] Security_Logins_Roles security_Logins_Roles)
        {
            if (ModelState.IsValid)
            {
                security_Logins_Roles.Id = Guid.NewGuid();
                db.Security_Logins_Roles.Add(security_Logins_Roles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", security_Logins_Roles.Login);
            ViewBag.Role = new SelectList(db.Security_Roles, "Id", "Role", security_Logins_Roles.Role);
            return View(security_Logins_Roles);
        }

        // GET: Security_Logins_Roles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins_Roles security_Logins_Roles = db.Security_Logins_Roles.Find(id);
            if (security_Logins_Roles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", security_Logins_Roles.Login);
            ViewBag.Role = new SelectList(db.Security_Roles, "Id", "Role", security_Logins_Roles.Role);
            return View(security_Logins_Roles);
        }

        // POST: Security_Logins_Roles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Role,Time_Stamp")] Security_Logins_Roles security_Logins_Roles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(security_Logins_Roles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", security_Logins_Roles.Login);
            ViewBag.Role = new SelectList(db.Security_Roles, "Id", "Role", security_Logins_Roles.Role);
            return View(security_Logins_Roles);
        }

        // GET: Security_Logins_Roles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins_Roles security_Logins_Roles = db.Security_Logins_Roles.Find(id);
            if (security_Logins_Roles == null)
            {
                return HttpNotFound();
            }
            return View(security_Logins_Roles);
        }

        // POST: Security_Logins_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Security_Logins_Roles security_Logins_Roles = db.Security_Logins_Roles.Find(id);
            db.Security_Logins_Roles.Remove(security_Logins_Roles);
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
