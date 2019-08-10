using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Owin.Security.Provider;

namespace REM.Core.Domain
{
    public class Venue
    {
        [Key]
        public int Id { get; set; }
        public string Address { get; set; }
        public byte RoomNumber{ get; set; }
        public string VenueName { get; set; }
        public int Capacity { get; set; }
        public int VenueTypeId { get; set; }
        public int VenuePricesId { get; set; }
        public DateTime CreatedAt { get; set; }

        #region Entity Framework Mappings.
        //Linked: Single Instance of venue type.
        public VenueType VenueType { get; set; }
        //linked: to single instance of venue price.
        public VenuePrice VenuePrices { get; set; }
        //Linked: to many instances of the following entities.
        public ICollection<BookingVenueLink> BookingVenueLinks { get; set; }
        public ICollection<AccountCleaningLink> AccountCleaningLinks { get; set; }
        public ICollection<AccountMaintenanceLink> AccountMaintenanceLinks { get; set; }
        public ICollection<VenueAttributeLink> VenueAttributeLinks { get; set; }
        public ICollection<ImageLink> ImageLinks { get; set; }
        public ICollection<BookingInvoiceItem> BookingInvoiceItems { get; set; }

        #endregion
    }


    public class VenueType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [Display(Name = "Venue Type Name")]
        public string Name { get; set; }
    }

    public class VenueAttributeLink
    {
        //Can be created as a fluent API mapping.
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }

        #region Entity Framework Mappings
        //linked: To single instance of venue.
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        //
        public int VenueAttributeId { get; set; }
        public VenueAttribute VenueAttributes { get; set; }
        #endregion
    }

    public class VenueAttribute
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        #region Entity Framework Mappings

        //Linked: Single instance of Venue.
        public ICollection<VenueAttributeLink> VenueAttributesLinks { get; set; }
        #endregion
    }

    public class VenueImage
    {
        [Key]
        public int Id { get; set; }

        public string FileName { get; set; }
        public string FileDir { get; set; }
        public DateTime DateAdded => DateTime.Now;

        #region Entity Framework Mappings
        public ICollection<ImageLink> ImageLinks { get; set; }
        #endregion
    }

    public class VenuePrice
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }

        #region Entity Framework

        public int MarkupId { get; set; }
        public Markup Markup { get; set; }

        #endregion
    }

    public class ImageLink
    {
        [Key]
        public int Id { get; set; }

        #region Entity Framework
        public int VenueImageId { get; set; }
        public VenueImage VenueImage { get; set; }
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        #endregion

    }



}