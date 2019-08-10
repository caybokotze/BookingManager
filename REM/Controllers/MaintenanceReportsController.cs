using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using REM.Connections;
using REM.Core.Domain;
using REM.Models;
using REM.ViewModels;

namespace REM.Controllers
{
    public class MaintenanceReportsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MaintenanceReports
        public ActionResult Index()
        {
            return View();
            //var maintenanceReports = db.MaintenanceReports.Include(m => m.ReportType);
            //return View(maintenanceReports.ToList());
        }

        // GET: MaintenanceReports/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceReport maintenanceReport = db.MaintenanceReports.Find(id);
            if (maintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceReport);
        }

        // GET: MaintenanceReports/Create
        public ActionResult Create()
        {
            MaintenanceReportViewModel mrvm = new MaintenanceReportViewModel()
            {
                ReportTypes = db.ReportTypes.ToList(),
                Venues = db.Venues.ToList()
            };
            return View(mrvm);
        }

        // POST: MaintenanceReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MaintenanceReportViewModel maintenanceReportVM)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in maintenanceReportVM.Venues)
                {
                    AccountMaintenanceLink ml = new AccountMaintenanceLink()
                    {
                        MaintenanceReportId = maintenanceReportVM.Id,
                        VenueId = item.Id
                    };
                }

                var maintenanceReport = Mapper.Map<MaintenanceReportViewModel, MaintenanceReport>(maintenanceReportVM);
                db.MaintenanceReports.Add(maintenanceReport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maintenanceReportVM);
        }

        // GET: MaintenanceReports/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceReport maintenanceReport = db.MaintenanceReports.Find(id);
            if (maintenanceReport == null)
            {
                return HttpNotFound();
            }
            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name", maintenanceReport.ReportTypeId);
            return View(maintenanceReport);
        }

        // POST: MaintenanceReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Details,ReportTypeId")] MaintenanceReport maintenanceReport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maintenanceReport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ReportTypeId = new SelectList(db.ReportTypes, "Id", "Name", maintenanceReport.ReportTypeId);
            return View(maintenanceReport);
        }

        // GET: MaintenanceReports/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaintenanceReport maintenanceReport = db.MaintenanceReports.Find(id);
            if (maintenanceReport == null)
            {
                return HttpNotFound();
            }
            return View(maintenanceReport);
        }

        // POST: MaintenanceReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaintenanceReport maintenanceReport = db.MaintenanceReports.Find(id);
            db.MaintenanceReports.Remove(maintenanceReport);
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
