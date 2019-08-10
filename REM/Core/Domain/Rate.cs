using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace REM.Core.Domain
{
    public class Rate
    {
        public int Id { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        public double Vat { get; set; }
        public double Tax { get; set; }

    }
}