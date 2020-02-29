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
    public class Company_Job_EducationsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Job_Educations
        public ActionResult Index()
        {
            var company_Job_Educations = db.Company_Job_Educations.Include(c => c.Company_Jobs);
            return View(company_Job_Educations.ToList());
        }

        // GET: Company_Job_Educations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Job_Educations company_Job_Educations = db.Company_Job_Educations.Find(id);
            if (company_Job_Educations == null)
            {
                return HttpNotFound();
            }
            return View(company_Job_Educations);
        }

        // GET: Company_Job_Educations/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id");
            return View();
        }

        // POST: Company_Job_Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Major,Importance,Time_Stamp")] Company_Job_Educations company_Job_Educations)
        {
            if (ModelState.IsValid)
            {
                company_Job_Educations.Id = Guid.NewGuid();
                db.Company_Job_Educations.Add(company_Job_Educations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Job_Educations.Job);
            return View(company_Job_Educations);
        }

        // GET: Company_Job_Educations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Job_Educations company_Job_Educations = db.Company_Job_Educations.Find(id);
            if (company_Job_Educations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Job_Educations.Job);
            return View(company_Job_Educations);
        }

        // POST: Company_Job_Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Major,Importance,Time_Stamp")] Company_Job_Educations company_Job_Educations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Job_Educations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Job_Educations.Job);
            return View(company_Job_Educations);
        }

        // GET: Company_Job_Educations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Job_Educations company_Job_Educations = db.Company_Job_Educations.Find(id);
            if (company_Job_Educations == null)
            {
                return HttpNotFound();
            }
            return View(company_Job_Educations);
        }

        // POST: Company_Job_Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Job_Educations company_Job_Educations = db.Company_Job_Educations.Find(id);
            db.Company_Job_Educations.Remove(company_Job_Educations);
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
