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
    public class Applicant_SkillsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Applicant_Skills
        public ActionResult Index(Guid? id)
        {
             if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var applicant_Skills = db.Applicant_Skills.Where(a => a.Applicant==id);
            if ( applicant_Skills.Count() == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            return View(applicant_Skills.ToList());
        }

        // GET: Applicant_Skills/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Skills applicant_Skills = db.Applicant_Skills.Find(id);
            if (applicant_Skills == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Skills);
        }

        // GET: Applicant_Skills/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency");
            return View();
        }

        // POST: Applicant_Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year,Time_Stamp")] Applicant_Skills applicant_Skills)
        {
            if (ModelState.IsValid)
            {
                applicant_Skills.Id = Guid.NewGuid();
                db.Applicant_Skills.Add(applicant_Skills);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Skills.Applicant);
            return View(applicant_Skills);
        }

        // GET: Applicant_Skills/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Skills applicant_Skills = db.Applicant_Skills.Find(id);
            if (applicant_Skills == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Skills.Applicant);
            return View(applicant_Skills);
        }

        // POST: Applicant_Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Skill,Skill_Level,Start_Month,Start_Year,End_Month,End_Year,Time_Stamp")] Applicant_Skills applicant_Skills)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant_Skills).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Skills.Applicant);
            return View(applicant_Skills);
        }

        // GET: Applicant_Skills/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Skills applicant_Skills = db.Applicant_Skills.Find(id);
            if (applicant_Skills == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Skills);
        }

        // POST: Applicant_Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Applicant_Skills applicant_Skills = db.Applicant_Skills.Find(id);
            db.Applicant_Skills.Remove(applicant_Skills);
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
