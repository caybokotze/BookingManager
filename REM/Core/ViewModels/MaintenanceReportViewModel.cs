using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using REM.Core.Domain;
using REM.Models;

namespace REM.ViewModels
{
    public class MaintenanceReportViewModel
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public int ReportTypeId { get; set; }

        public ICollection<ReportType> ReportTypes { get; set; }
        public ICollection<Core.Domain.Venue> Venues { get; set; }
    }
}