using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REM.Core.Domain;
using REM.Models;

namespace REM.ViewModels.Venue
{
    public class VenueViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public byte RoomNumber { get; set; }
        public string VenueName { get; set; }
        //
        public int VenueTypeId { get; set; }
        public int VenuePricesId { get; set; }
        public int VenueCapacityId { get; set; }

        public ICollection<VenueType> VenueTypes { get; set; }
        public ICollection<VenuePrice> VenuePrices { get; set; }
        public ICollection<VenueAttribute> VenueAttributes { get; set; }

    }
}