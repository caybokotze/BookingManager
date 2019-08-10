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
    public class BookingInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingInvoices
        public ActionResult Index()
        {
            return View();
            //var bookingInvoices = db.BookingInvoices.Include(b => b.Rates);
            //return View(bookingInvoices.ToList());
        }

        // GET: BookingInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInvoice bookingInvoice = db.BookingInvoices.Find(id);
            if (bookingInvoice == null)
            {
                return HttpNotFound();
            }
            return View(bookingInvoice);
        }

        // GET: BookingInvoices/Create
        public ActionResult Create()
        {
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id");
            return View();
        }

        // POST: BookingInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RatesId")] BookingInvoice bookingInvoice)
        {
            if (ModelState.IsValid)
            {
                db.BookingInvoices.Add(bookingInvoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", bookingInvoice.RateId);
            return View(bookingInvoice);
        }

        // GET: BookingInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInvoice bookingInvoice = db.BookingInvoices.Find(id);
            if (bookingInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", bookingInvoice.RateId);
            return View(bookingInvoice);
        }

        // POST: BookingInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RatesId")] BookingInvoice bookingInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RatesId = new SelectList(db.Rates, "Id", "Id", bookingInvoice.RateId);
            return View(bookingInvoice);
        }

        // GET: BookingInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInvoice bookingInvoice = db.BookingInvoices.Find(id);
            if (bookingInvoice == null)
            {
                return HttpNotFound();
            }
            return View(bookingInvoice);
        }

        // POST: BookingInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingInvoice bookingInvoice = db.BookingInvoices.Find(id);
            db.BookingInvoices.Remove(bookingInvoice);
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
