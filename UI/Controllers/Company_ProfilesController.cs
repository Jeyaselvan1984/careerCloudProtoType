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
    public class Company_ProfilesController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Profiles
        public ActionResult Index()
        {
            return View(db.Company_Profiles.ToList());
        }

        // GET: Company_Profiles/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Profiles company_Profiles = db.Company_Profiles.Find(id);
            if (company_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(company_Profiles);
        }

        // GET: Company_Profiles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company_Profiles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,Company_Logo,Time_Stamp")] Company_Profiles company_Profiles)
        {
            if (ModelState.IsValid)
            {
                company_Profiles.Id = Guid.NewGuid();
                db.Company_Profiles.Add(company_Profiles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(company_Profiles);
        }

        // GET: Company_Profiles/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Profiles company_Profiles = db.Company_Profiles.Find(id);
            if (company_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(company_Profiles);
        }

        // POST: Company_Profiles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Registration_Date,Company_Website,Contact_Phone,Contact_Name,Company_Logo,Time_Stamp")] Company_Profiles company_Profiles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Profiles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(company_Profiles);
        }

        // GET: Company_Profiles/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Profiles company_Profiles = db.Company_Profiles.Find(id);
            if (company_Profiles == null)
            {
                return HttpNotFound();
            }
            return View(company_Profiles);
        }

        // POST: Company_Profiles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Profiles company_Profiles = db.Company_Profiles.Find(id);
            db.Company_Profiles.Remove(company_Profiles);
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
