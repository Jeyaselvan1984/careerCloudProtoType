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
    public class Company_LocationsController : Controller
    {
        private JOB_PORTAL_DBEntities db = new JOB_PORTAL_DBEntities();

        // GET: Company_Locations
        public ActionResult Index()
        {
            var company_Locations = db.Company_Locations.Include(c => c.Company_Profiles);
            return View(company_Locations.ToList());
        }

        // GET: Company_Locations/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Locations company_Locations = db.Company_Locations.Find(id);
            if (company_Locations == null)
            {
                return HttpNotFound();
            }
            return View(company_Locations);
        }

        // GET: Company_Locations/Create
        public ActionResult Create()
        {
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website");
            return View();
        }

        // POST: Company_Locations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp")] Company_Locations company_Locations)
        {
            if (ModelState.IsValid)
            {
                company_Locations.Id = Guid.NewGuid();
                db.Company_Locations.Add(company_Locations);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Locations.Company);
            return View(company_Locations);
        }

        // GET: Company_Locations/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Locations company_Locations = db.Company_Locations.Find(id);
            if (company_Locations == null)
            {
                return HttpNotFound();
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Locations.Company);
            return View(company_Locations);
        }

        // POST: Company_Locations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Company,Country_Code,State_Province_Code,Street_Address,City_Town,Zip_Postal_Code,Time_Stamp")] Company_Locations company_Locations)
        {
            if (ModelState.IsValid)
            {
                db.Entry(company_Locations).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Company = new SelectList(db.Company_Profiles, "Id", "Company_Website", company_Locations.Company);
            return View(company_Locations);
        }

        // GET: Company_Locations/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Company_Locations company_Locations = db.Company_Locations.Find(id);
            if (company_Locations == null)
            {
                return HttpNotFound();
            }
            return View(company_Locations);
        }

        // POST: Company_Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Company_Locations company_Locations = db.Company_Locations.Find(id);
            db.Company_Locations.Remove(company_Locations);
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
