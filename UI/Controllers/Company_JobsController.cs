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
    public class Company_JobsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Jobs
        public ActionResult Index()
        {
            var company_Jobs = db.Company_Jobs.Include(c => c.Company_Profiles);
            return View(company_Jobs.ToList());
        }

        // GET: Company_Jobs/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs company_Jobs = db.Company_Jobs.Find(id);
            if (company_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(company_Jobs);
        }

        // GET: Company_Jobs/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website");
            return View();
        }

        // POST: Company_Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden,Time_Stamp")] Company_Jobs company_Jobs)
        {
            if (ModelState.IsValid)
            {
                company_Jobs.Id = Guid.NewGuid();
                db.Company_Jobs.Add(company_Jobs);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Jobs.Company);
            return View(company_Jobs);
        }

        // GET: Company_Jobs/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs company_Jobs = db.Company_Jobs.Find(id);
            if (company_Jobs == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Jobs.Company);
            return View(company_Jobs);
        }

        // POST: Company_Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,Profile_Created,Is_Inactive,Is_Company_Hidden,Time_Stamp")] Company_Jobs company_Jobs)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Jobs).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Jobs.Company);
            return View(company_Jobs);
        }

        // GET: Company_Jobs/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs company_Jobs = db.Company_Jobs.Find(id);
            if (company_Jobs == null)
            {
                return HttpNotFound();
            }
            return View(company_Jobs);
        }

        // POST: Company_Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Jobs company_Jobs = db.Company_Jobs.Find(id);
            db.Company_Jobs.Remove(company_Jobs);
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
