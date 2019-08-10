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
    public class VenueAttributesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VenueAttributes
        public ActionResult Index()
        {
            return View(db.VenueAttributes.ToList());
        }

        // GET: VenueAttributes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueAttribute venueAttribute = db.VenueAttributes.Find(id);
            if (venueAttribute == null)
            {
                return HttpNotFound();
            }
            return View(venueAttribute);
        }

        // GET: VenueAttributes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueAttributes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Amount,Name")] VenueAttribute venueAttribute)
        {
            if (ModelState.IsValid)
            {
                db.VenueAttributes.Add(venueAttribute);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venueAttribute);
        }

        // GET: VenueAttributes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueAttribute venueAttribute = db.VenueAttributes.Find(id);
            if (venueAttribute == null)
            {
                return HttpNotFound();
            }
            return View(venueAttribute);
        }

        // POST: VenueAttributes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Amount,Name")] VenueAttribute venueAttribute)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueAttribute).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venueAttribute);
        }

        // GET: VenueAttributes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueAttribute venueAttribute = db.VenueAttributes.Find(id);
            if (venueAttribute == null)
            {
                return HttpNotFound();
            }
            return View(venueAttribute);
        }

        // POST: VenueAttributes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VenueAttribute venueAttribute = db.VenueAttributes.Find(id);
            db.VenueAttributes.Remove(venueAttribute);
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
