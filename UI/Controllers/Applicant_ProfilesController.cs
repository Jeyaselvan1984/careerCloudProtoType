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
    public class Applicant_ProfilesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Applicant_Profiles
        public ActionResult Index()
        {
            var applicant_Profiles = db.Applicant_Profiles.Include(a => a.Security_Logins).Include(a => a.System_Country_Codes);
            return View(applicant_Profiles.ToList());
        }

        // GET: Applicant_Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Profiles applicant_Profiles = db.Applicant_Profiles.Find(id);
            if (applicant_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Profiles);
        }

        // GET: Applicant_Profiles/Create
        public ActionResult Create()
        {
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login");
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name");
            return View();
        }

        // POST: Applicant_Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp")] Applicant_Profiles applicant_Profiles)
        {
            if (ModelState.IsValid)
            {
                applicant_Profiles.Id = Guid.NewGuid();
                db.Applicant_Profiles.Add(applicant_Profiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", applicant_Profiles.Login);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Profiles.Country_Code);
            return View(applicant_Profiles);
        }

        // GET: Applicant_Profiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Profiles applicant_Profiles = db.Applicant_Profiles.Find(id);
            if (applicant_Profiles == null)
            {
                return HttpNotFound();
            }
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", applicant_Profiles.Login);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Profiles.Country_Code);
            return View(applicant_Profiles);
        }

        // POST: Applicant_Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Login,Current_Salary,Current_Rate,Currency,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp")] Applicant_Profiles applicant_Profiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant_Profiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Login = new SelectList(db.Security_Logins, "Id", "Login", applicant_Profiles.Login);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Profiles.Country_Code);
            return View(applicant_Profiles);
        }

        // GET: Applicant_Profiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Profiles applicant_Profiles = db.Applicant_Profiles.Find(id);
            if (applicant_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Profiles);
        }

        // POST: Applicant_Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Applicant_Profiles applicant_Profiles = db.Applicant_Profiles.Find(id);
            db.Applicant_Profiles.Remove(applicant_Profiles);
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
