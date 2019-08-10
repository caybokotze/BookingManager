using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace REM.Core.Domain
{
    //Pure and Display Model.
    public class Booking
    {
        public Booking()
        {
            this.Id = 0;
        }
        //
        [Key]
        public int Id { get; set; }
        //
        public DateTime CreatedAt { get; set; }
        //
        [Required(ErrorMessage = "Please select the starting date for the booking.")]
        [Display(Name = "Booking From")]
        //[CheckDateDeviation]
        public DateTime BookingFrom { get; set; }
        //
        [Required(ErrorMessage = "Please select the ending date.")]
        [Display(Name = "Booking To")]
        //[CheckDateDeviation]
        public DateTime BookingTo { get; set; }
        //
        //Note: Nullable because the check in/out time is unknown until the customer pitches up.
        //[CheckDateDeviation]
        [DataType(DataType.Time)]
        public DateTime? CheckInTime { get; set; }
        //
        //[CheckDateDeviation]
        [DataType(DataType.Time)]
        public DateTime? CheckOutTime { get; set; }
        //
        [Required(ErrorMessage = "Please specify how many guests are coming.")]
        [Display(Name = "Amount Of Guests")]
        [Range(1, 1000, ErrorMessage = "The amount of guests specified does not fall within the specified range.")]
        public int GuestsAmount { get; set; }
        //
        public int BookingInvoiceId { get; set; }
        


        #region Entity Framework Mappings
        //Linked: One or more instances of PersonBookingLink.
        //Note: This is done in order to relate a single booking to more than one customer. (In the same way airbnb does.)
        public ICollection<AccountBookingLink> AccountBookingLinks { get; set; }
        //Linked: One or more instances of a venue for any one booking.
        public ICollection<BookingVenueLink> BookingVenueLinks { get; set; }
        //Linked: One or more branches.
        public ICollection<BranchBookingLink> BranchBookingLinks { get; set; }
        //Linked: To a single invoice.
        [ForeignKey("BookingInvoice")]
        public BookingInvoice BookingInvoice { get; set; }
        //Linked: One multiple instances of PersonDetailsBookingLinks
        public ICollection<PersonDetailsBookingLink> PersonDetailsBookingLinks { get; set; }
        #endregion

    }

    

    public class BookingInvoice
    {
        public int Id { get; set; }
        public int RateId { get; set; }


        #region Entity Framework

        public Rate Rate { get; set; }
        public ICollection<BookingInvoiceItem> VenueInvoiceItems { get; set; }

        #endregion
    }

    public class BookingInvoiceItem
    {
        public int Id { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        public int BookingInvoiceId { get; set; }
        public BookingInvoice BookingInvoice { get; set; }
    }

    public class BookingVenueLink
    {
        public int Id { get; set; }

        #region Entity Framework Mappings
        //linked to single instance of booking.
        public int BookingId { get; set; }
        public Booking Booking { get; set; }
        //linked to single instance of venue.
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        #endregion
    }



}