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
    public class Applicant_Work_HistoryController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Applicant_Work_History
        public ActionResult Index()
        {
            var applicant_Work_History = db.Applicant_Work_History.Include(a => a.Applicant_Profiles).Include(a => a.System_Country_Codes);
            return View(applicant_Work_History.ToList());
        }

        // GET: Applicant_Work_History/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Work_History applicant_Work_History = db.Applicant_Work_History.Find(id);
            if (applicant_Work_History == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Work_History);
        }

        // GET: Applicant_Work_History/Create
        public ActionResult Create()
        {
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency");
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name");
            return View();
        }

        // POST: Applicant_Work_History/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Applicant,Company_Name,Country_Code,Location,Job_Title,Job_Description,Start_Month,Start_Year,End_Month,End_Year,Time_Stamp")] Applicant_Work_History applicant_Work_History)
        {
            if (ModelState.IsValid)
            {
                applicant_Work_History.Id = Guid.NewGuid();
                db.Applicant_Work_History.Add(applicant_Work_History);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Work_History.Applicant);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Work_History.Country_Code);
            return View(applicant_Work_History);
        }

        // GET: Applicant_Work_History/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Work_History applicant_Work_History = db.Applicant_Work_History.Find(id);
            if (applicant_Work_History == null)
            {
                return HttpNotFound();
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Work_History.Applicant);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Work_History.Country_Code);
            return View(applicant_Work_History);
        }

        // POST: Applicant_Work_History/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Applicant,Company_Name,Country_Code,Location,Job_Title,Job_Description,Start_Month,Start_Year,End_Month,End_Year,Time_Stamp")] Applicant_Work_History applicant_Work_History)
        {
            if (ModelState.IsValid)
            {
                db.Entry(applicant_Work_History).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Applicant = new SelectList(db.Applicant_Profiles, "Id", "Currency", applicant_Work_History.Applicant);
            ViewBag.Country_Code = new SelectList(db.System_Country_Codes, "Code", "Name", applicant_Work_History.Country_Code);
            return View(applicant_Work_History);
        }

        // GET: Applicant_Work_History/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Applicant_Work_History applicant_Work_History = db.Applicant_Work_History.Find(id);
            if (applicant_Work_History == null)
            {
                return HttpNotFound();
            }
            return View(applicant_Work_History);
        }

        // POST: Applicant_Work_History/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Applicant_Work_History applicant_Work_History = db.Applicant_Work_History.Find(id);
            db.Applicant_Work_History.Remove(applicant_Work_History);
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
