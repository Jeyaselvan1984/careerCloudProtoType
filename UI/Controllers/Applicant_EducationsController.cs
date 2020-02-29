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
    public class Applicant_EducationsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Applicant_Educations
        public ActionResult Index()
        {
            var applicant_Educations = db.Applicant_Educations.Include(a => a.Applicant_Profiles);
            return View(applicant_Educations.ToList());
        }

        // GET: Applicant_Educations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Educations applicant_Educations = db.Applicant_Educations.Find(id);
            if (applicant_Educations == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Educations);
        }

        // GET: Applicant_Educations/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency");
            return View();
        }

        // POST: Applicant_Educations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent,Time_Stamp")] Applicant_Educations applicant_Educations)
        {
            if (ModelState.IsValid)
            {
                applicant_Educations.Id = Guid.NewGuid();
                db.Applicant_Educations.Add(applicant_Educations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Educations.Applicant);
            return View(applicant_Educations);
        }

        // GET: Applicant_Educations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Educations applicant_Educations = db.Applicant_Educations.Find(id);
            if (applicant_Educations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Educations.Applicant);
            return View(applicant_Educations);
        }

        // POST: Applicant_Educations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Major,Certificate_Diploma,Start_Date,Completion_Date,Completion_Percent,Time_Stamp")] Applicant_Educations applicant_Educations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant_Educations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Educations.Applicant);
            return View(applicant_Educations);
        }

        // GET: Applicant_Educations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Educations applicant_Educations = db.Applicant_Educations.Find(id);
            if (applicant_Educations == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Educations);
        }

        // POST: Applicant_Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Applicant_Educations applicant_Educations = db.Applicant_Educations.Find(id);
            db.Applicant_Educations.Remove(applicant_Educations);
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
