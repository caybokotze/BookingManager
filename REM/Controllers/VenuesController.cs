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
using REM.ViewModels.Venue;

namespace REM.Controllers
{
    public class VenuesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Venues
        public ActionResult Index()
        {
            var venues = db.Venues.Include(v => v.VenuePrices).Include(v => v.VenueType);
            return View(venues.ToList());
        }

        // GET: Venues/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // GET: Venues/Create
        public ActionResult Create()
        {
            VenueViewModel vvm = new VenueViewModel()
            {
                VenueAttributes = db.VenueAttributes.ToList(),
                VenueTypes = db.VenueTypes.ToList(),
                VenuePrices = db.VenuePrices.ToList()
            };
            return View(vvm);
        }

        // POST: Venues/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VenueViewModel venueVm)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in venueVm.VenueAttributes)
                {
                    VenueAttributeLink val = new VenueAttributeLink()
                    {
                        //Note: how do we establish a link to a ID when it doesn't exist in the db yet?
                        VenueId = venueVm.Id,
                        VenueAttributeId = item.Id
                    };
                }

                var venue = Mapper.Map<VenueViewModel, Venue>(venueVm);
                db.Venues.Add(venue);
                //Can we access the venue object id from the database at this point?

                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(venueVm);
        }

        // GET: Venues/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Venues/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Address,RoomNumber,VenueName,VenueTypeId,VenuePricesId,VenueCapacityId")] Venue venue)
        {
            if (ModelState.IsValid)
            {
                db.Entry(venue).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(venue);
        }

        // GET: Venues/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Venue venue = db.Venues.Find(id);
            if (venue == null)
            {
                return HttpNotFound();
            }
            return View(venue);
        }

        // POST: Venues/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Venue venue = db.Venues.Find(id);
            db.Venues.Remove(venue);
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
