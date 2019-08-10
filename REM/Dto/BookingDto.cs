using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REM.Dto
{
    public class BookingDto
    {
        public int Id { get; set; }

        //Foreign Key
        public int UserId { get; set; }
        // Map to Identity.

        public DateTime CreatedAt { get => DateTime.Now; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
    }
}