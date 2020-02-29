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
    public class Security_LoginsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Security_Logins
        public ActionResult Index()
        {
            return View(db.Security_Logins.ToList());
        }

        // GET: Security_Logins/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins security_Logins = db.Security_Logins.Find(id);
            if (security_Logins == null)
            {
                return HttpNotFound();
            }
            return View(security_Logins);
        }

        // GET: Security_Logins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Security_Logins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language,Time_Stamp")] Security_Logins security_Logins)
        {
            if (ModelState.IsValid)
            {
                security_Logins.Id = Guid.NewGuid();
                db.Security_Logins.Add(security_Logins);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(security_Logins);
        }

        // GET: Security_Logins/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins security_Logins = db.Security_Logins.Find(id);
            if (security_Logins == null)
            {
                return HttpNotFound();
            }
            return View(security_Logins);
        }

        // POST: Security_Logins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Password,Created_Date,Password_Update_Date,Agreement_Accepted_Date,Is_Locked,Is_Inactive,Email_Address,Phone_Number,Full_Name,Force_Change_Password,Prefferred_Language,Time_Stamp")] Security_Logins security_Logins)
        {
            if (ModelState.IsValid)
            {
                db.Entry(security_Logins).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(security_Logins);
        }

        // GET: Security_Logins/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Security_Logins security_Logins = db.Security_Logins.Find(id);
            if (security_Logins == null)
            {
                return HttpNotFound();
            }
            return View(security_Logins);
        }

        // POST: Security_Logins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Security_Logins security_Logins = db.Security_Logins.Find(id);
            db.Security_Logins.Remove(security_Logins);
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
