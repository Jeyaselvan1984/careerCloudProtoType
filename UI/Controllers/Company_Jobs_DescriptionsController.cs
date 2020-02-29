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
    public class Company_Jobs_DescriptionsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Jobs_Descriptions
        public ActionResult Index()
        {
            var company_Jobs_Descriptions = db.Company_Jobs_Descriptions.Include(c => c.Company_Jobs);
            return View(company_Jobs_Descriptions.ToList());
        }

        // GET: Company_Jobs_Descriptions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs_Descriptions company_Jobs_Descriptions = db.Company_Jobs_Descriptions.Find(id);
            if (company_Jobs_Descriptions == null)
            {
                return HttpNotFound();
            }
            return View(company_Jobs_Descriptions);
        }

        // GET: Company_Jobs_Descriptions/Create
        public ActionResult Create()
        {
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id");
            return View();
        }

        // POST: Company_Jobs_Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Job,Job_Name,Job_Descriptions,Time_Stamp")] Company_Jobs_Descriptions company_Jobs_Descriptions)
        {
            if (ModelState.IsValid)
            {
                company_Jobs_Descriptions.Id = Guid.NewGuid();
                db.Company_Jobs_Descriptions.Add(company_Jobs_Descriptions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Jobs_Descriptions.Job);
            return View(company_Jobs_Descriptions);
        }

        // GET: Company_Jobs_Descriptions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs_Descriptions company_Jobs_Descriptions = db.Company_Jobs_Descriptions.Find(id);
            if (company_Jobs_Descriptions == null)
            {
                return HttpNotFound();
            }
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Jobs_Descriptions.Job);
            return View(company_Jobs_Descriptions);
        }

        // POST: Company_Jobs_Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Job,Job_Name,Job_Descriptions,Time_Stamp")] Company_Jobs_Descriptions company_Jobs_Descriptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Jobs_Descriptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Job = new SelectList(db.Company_Jobs, "Id", "Id", company_Jobs_Descriptions.Job);
            return View(company_Jobs_Descriptions);
        }

        // GET: Company_Jobs_Descriptions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Jobs_Descriptions company_Jobs_Descriptions = db.Company_Jobs_Descriptions.Find(id);
            if (company_Jobs_Descriptions == null)
            {
                return HttpNotFound();
            }
            return View(company_Jobs_Descriptions);
        }

        // POST: Company_Jobs_Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Jobs_Descriptions company_Jobs_Descriptions = db.Company_Jobs_Descriptions.Find(id);
            db.Company_Jobs_Descriptions.Remove(company_Jobs_Descriptions);
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
