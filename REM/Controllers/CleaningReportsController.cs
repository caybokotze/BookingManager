using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using REM.Connections;
using REM.Core.Domain;
using REM.Models;

namespace REM.Controllers
{
    public class CleaningReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CleaningReports
        public ActionResult Index()
        {
            return View();
            var cleaningReports = db.CleaningReports.Include(c => c.ReportType);
            return View(cleaningReports.ToList());
        }

        // GET: CleaningReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleaningReport cleaningReport = db.CleaningReports.Find(id);
            if (cleaningReport == null)
            {
                return HttpNotFound();
            }
            return View(cleaningReport);
        }

        // GET: CleaningReports/Create
        public ActionResult Create()
        {
            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name");
            return View();
        }

        // POST: CleaningReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ReportTypeId")] CleaningReport cleaningReport)
        {
            if (ModelState.IsValid)
            {
                db.CleaningReports.Add(cleaningReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name", cleaningReport.ReportTypeId);
            return View(cleaningReport);
        }

        // GET: CleaningReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleaningReport cleaningReport = db.CleaningReports.Find(id);
            if (cleaningReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name", cleaningReport.ReportTypeId);
            return View(cleaningReport);
        }

        // POST: CleaningReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ReportTypeId")] CleaningReport cleaningReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cleaningReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name", cleaningReport.ReportTypeId);
            return View(cleaningReport);
        }

        // GET: CleaningReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CleaningReport cleaningReport = db.CleaningReports.Find(id);
            if (cleaningReport == null)
            {
                return HttpNotFound();
            }
            return View(cleaningReport);
        }

        // POST: CleaningReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CleaningReport cleaningReport = db.CleaningReports.Find(id);
            db.CleaningReports.Remove(cleaningReport);
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
