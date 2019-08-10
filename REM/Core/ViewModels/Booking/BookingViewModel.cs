using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using REM.Models;

namespace REM.ViewModels.Booking
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        //
        [Required(ErrorMessage = "Please select the starting date for the booking.")]
        [Display(Name = "Booking From")]
        public DateTime BookingFrom { get; set; }
        //
        [Required(ErrorMessage = "Please select the ending date.")]
        [Display(Name = "Booking To")]
        public DateTime BookingTo { get; set; }
        //
        
        public int GuestsAmount { get; set; }

        public int BookingTypeId { get; set; }

        public int VenueId { get; set; }

        
        public ICollection<Core.Domain.Venue> Venues { get; set; }

    }
}