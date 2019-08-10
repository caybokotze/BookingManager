using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Newtonsoft.Json;
using REM.Connections;
using REM.Core.Domain;
using REM.Interfaces;
using REM.Logic;
using REM.Models;
using REM.ViewModels.Booking;

namespace REM.Controllers
{
    public class BookingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public static string IndexAction = "Index";

        // GET: Bookings
        public ActionResult Index()
        {
            return View();
            //var bookings = db.Bookings.Include(b => b.BookingInvoice).Include(b => b.BookingType);
            //return View(bookings.ToList());
        }

        // GET: Bookings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Bookings/Create
        public ActionResult Create()
        {
            BookingViewModel bvm = new BookingViewModel
            {
                Venues = db.Venues.ToList()
            };

            return View(bvm);
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[Bind(Include = "Id,BookingFrom,BookingTo,CheckInTime,CheckOutTime,GuestsAmount,BookingInvoiceId,BookingTypeId")] 
        public async Task<ActionResult> Create(BookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                    BookingInvoice bi = new BookingInvoice()
                    {
                        RateId = 1
                    };
                    db.BookingInvoices.Add(bi);
                    await db.SaveChangesAsync();
                    //Note: Receive the ID from the Scope Identity Callback.
                    int bookingInvoiceId = bi.Id;
                
                    BookingVenueLink bvl = new BookingVenueLink()
                    {
                        BookingId = bookingInvoiceId,
                        VenueId = booking.VenueId
                    };
                    db.BookingVenueLinks.Add(bvl);

                    //IWebCookie wc = new HttpWebCookie();
                    //wc.AddSession(bvl);

                    //string output = JsonConvert.SerializeObject(bvl);
                    //BookingVenueLink deserializedProduct = JsonConvert.DeserializeObject<BookingVenueLink>(output);


                BookingInvoiceItem bit = new BookingInvoiceItem()
                    {
                        BookingInvoiceId = bi.Id,
                        VenueId = booking.VenueId
                    };
                    db.BookingInvoiceItems.Add(bit);
                
                var bk = Mapper.Map<BookingViewModel, Booking>(booking);
                bk.CreatedAt = DateTime.Now;
                bk.BookingInvoiceId = bi.Id;
                db.Bookings.Add(bk);
                db.SaveChanges();


                
                return RedirectToAction(IndexAction);
            }
            
            return View(booking);
        }

        public class SendToNoSqlDataLayer
        {
            //Define A Delegate.
            // Define a event based on that delegate.
            //Raise the event.

            public delegate void ObjectSentAsNoSqlEventHandler(object source, EventArgs e);

            public event ObjectSentAsNoSqlEventHandler ObjectSent;



            public void Send(Booking booking)
            {
                OnObjectSentAsNoSql();
            }

            protected virtual void OnObjectSentAsNoSql()
            {
                ObjectSent?.Invoke(this, EventArgs.Empty);
            }
        }

        public class MailService
        {
            public void OnObjectSent(object sourse, EventArgs e)
            {
                
            }
        }

        // GET: Bookings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingInvoiceId = new SelectList(db.BookingInvoices, "Id", "Id", booking.BookingInvoiceId);
            
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BookingFrom,BookingTo,CheckInTime,CheckOutTime,GuestsAmount,BookingInvoiceId,BookingTypeId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingInvoiceId = new SelectList(db.BookingInvoices, "Id", "Id", booking.BookingInvoiceId);
            
            return View(booking);
        }

        public ActionResult RoomView()
        {
            return View("RoomView");
        }

        // GET: Bookings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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
