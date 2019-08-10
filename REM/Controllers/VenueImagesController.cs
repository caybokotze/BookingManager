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
    public class VenueImagesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: VenueImages
        public ActionResult Index()
        {
            return View("~/Views/VenueImages/Index.cshtml");
        }

        // GET: VenueImages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueImage venueImage = db.VenueImages.Find(id);
            if (venueImage == null)
            {
                return HttpNotFound();
            }
            return View(venueImage);
        }

        // GET: VenueImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VenueImages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,FileDir")] VenueImage venueImage)
        {
            if (ModelState.IsValid)
            {
                db.VenueImages.Add(venueImage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venueImage);
        }

        // GET: VenueImages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueImage venueImage = db.VenueImages.Find(id);
            if (venueImage == null)
            {
                return HttpNotFound();
            }
            return View(venueImage);
        }

        // POST: VenueImages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,FileDir")] VenueImage venueImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venueImage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(venueImage);
        }

        // GET: VenueImages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VenueImage venueImage = db.VenueImages.Find(id);
            if (venueImage == null)
            {
                return HttpNotFound();
            }
            return View(venueImage);
        }

        // POST: VenueImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VenueImage venueImage = db.VenueImages.Find(id);
            db.VenueImages.Remove(venueImage);
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
