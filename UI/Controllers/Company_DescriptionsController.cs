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
    public class Company_DescriptionsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Descriptions
        public ActionResult Index()
        {
            var company_Descriptions = db.Company_Descriptions.Include(c => c.Company_Profiles).Include(c => c.System_Language_Codes);
            return View(company_Descriptions.ToList());
        }

        // GET: Company_Descriptions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Descriptions company_Descriptions = db.Company_Descriptions.Find(id);
            if (company_Descriptions == null)
            {
                return HttpNotFound();
            }
            return View(company_Descriptions);
        }

        // GET: Company_Descriptions/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website");
            ViewBag.LanguageID = new SelectList(db.System_Language_Codes, "LanguageID", "Name");
            return View();
        }

        // POST: Company_Descriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,LanguageID,Company_Name,Company_Description,Time_Stamp")] Company_Descriptions company_Descriptions)
        {
            if (ModelState.IsValid)
            {
                company_Descriptions.Id = Guid.NewGuid();
                db.Company_Descriptions.Add(company_Descriptions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Descriptions.Company);
            ViewBag.LanguageID = new SelectList(db.System_Language_Codes, "LanguageID", "Name", company_Descriptions.LanguageID);
            return View(company_Descriptions);
        }

        // GET: Company_Descriptions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Descriptions company_Descriptions = db.Company_Descriptions.Find(id);
            if (company_Descriptions == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Descriptions.Company);
            ViewBag.LanguageID = new SelectList(db.System_Language_Codes, "LanguageID", "Name", company_Descriptions.LanguageID);
            return View(company_Descriptions);
        }

        // POST: Company_Descriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,LanguageID,Company_Name,Company_Description,Time_Stamp")] Company_Descriptions company_Descriptions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Descriptions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Descriptions.Company);
            ViewBag.LanguageID = new SelectList(db.System_Language_Codes, "LanguageID", "Name", company_Descriptions.LanguageID);
            return View(company_Descriptions);
        }

        // GET: Company_Descriptions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Descriptions company_Descriptions = db.Company_Descriptions.Find(id);
            if (company_Descriptions == null)
            {
                return HttpNotFound();
            }
            return View(company_Descriptions);
        }

        // POST: Company_Descriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Descriptions company_Descriptions = db.Company_Descriptions.Find(id);
            db.Company_Descriptions.Remove(company_Descriptions);
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
