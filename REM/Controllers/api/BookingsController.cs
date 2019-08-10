using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using REM.Connections;
using REM.Core.Domain;
using REM.Dto;
using REM.Models;

namespace REM.Controllers.api
{
    public class BookingsController : ApiController
    {
        public ApplicationDbContext _db;

        public BookingsController()
        {
            _db = new ApplicationDbContext();
        }
        // GET: api/Bookings
        public IHttpActionResult GetBooking()
        {
            var bookingDto = _db.Bookings
                .ToList()
                .Select(Mapper.Map<Booking, BookingDto>);

            return Ok(bookingDto);
        }

        public IHttpActionResult GetBooking(int id)
        {
            var booking = _db.Bookings.SingleOrDefault(b => b.Id == id);
            if (booking == null)
            {
                return NotFound();
            }
            else return Ok(Mapper.Map<Booking, BookingDto>(booking));
        }

        [HttpPost]
        public IHttpActionResult CreateBooking(BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var booking = Mapper.Map<BookingDto, Booking>(bookingDto);
            _db.Bookings.Add(booking);
            _db.SaveChanges();

            bookingDto.Id = booking.Id;

            return Created(new Uri(Request.RequestUri + "/" + booking.Id), bookingDto);
        }

        [HttpPut]
        public void UpdateCustomer(int id, BookingDto bookingDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var bookingInDb = _db.Bookings.SingleOrDefault(b => b.Id == id);

            if (bookingInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            Mapper.Map<BookingDto, Booking>(bookingDto, bookingInDb);

            _db.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            var bookingInDb = _db.Bookings.SingleOrDefault(b => b.Id == id);

            if (bookingInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _db.Bookings.Remove(bookingInDb);
            _db.SaveChanges();
        }
    }
}
