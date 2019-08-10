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
    public class StockInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: StockInvoices
        public ActionResult Index()
        {
            var stockInvoices = db.StockInvoices.Include(s => s.Rates);
            return View(stockInvoices.ToList());
        }

        // GET: StockInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInvoice stockInvoice = db.StockInvoices.Find(id);
            if (stockInvoice == null)
            {
                return HttpNotFound();
            }
            return View(stockInvoice);
        }

        // GET: StockInvoices/Create
        public ActionResult Create()
        {
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id");
            return View();
        }

        // POST: StockInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RatesId")] StockInvoice stockInvoice)
        {
            if (ModelState.IsValid)
            {
                db.StockInvoices.Add(stockInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", stockInvoice.RatesId);
            return View(stockInvoice);
        }

        // GET: StockInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInvoice stockInvoice = db.StockInvoices.Find(id);
            if (stockInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", stockInvoice.RatesId);
            return View(stockInvoice);
        }

        // POST: StockInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RatesId")] StockInvoice stockInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stockInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", stockInvoice.RatesId);
            return View(stockInvoice);
        }

        // GET: StockInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StockInvoice stockInvoice = db.StockInvoices.Find(id);
            if (stockInvoice == null)
            {
                return HttpNotFound();
            }
            return View(stockInvoice);
        }

        // POST: StockInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            StockInvoice stockInvoice = db.StockInvoices.Find(id);
            db.StockInvoices.Remove(stockInvoice);
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
