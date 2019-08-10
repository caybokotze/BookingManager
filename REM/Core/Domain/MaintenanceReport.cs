using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using REM.Logic;

namespace REM.Core.Domain
{
    public class MaintenanceReport
    {
        public int Id { get; set; }
        public string Details { get; set; }
        public DateTime CreatedAt => DateTime.Now;
        public int ReportTypeId { get; set; }
        public int ReportStatusId { get; set; }
        public int ReportPriorityId { get; set; }

        #region Entity Framework Mappings
        public ReportType ReportType { get; set; }
        public ReportStatus ReportStatus { get; set; }
        public ReportPriority ReportPriority { get; set; }
        public ICollection<AccountMaintenanceLink> AccountMaintenanceLinks { get; set; }
        public ICollection<MaintenanceReportComment> MaintenanceReportComments { get; set; }
        //public ICollection<//ReportImageLink> AccountMaintenanceLinks { get; set; }
        #endregion
    }

    public class AccountMaintenanceLink
    {
        [Key]
        public int Id { get; set; }
        //Linked: To one instance of the following:
        [ForeignKey("MaintenanceReport")]
        public int MaintenanceReportId { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        [ForeignKey("Venue")]
        public int VenueId { get; set; }

        #region Entity Framework
        public MaintenanceReport MaintenanceReport { get; set; }
        public Account Account { get; set; }
        public Venue Venue { get; set; }
        #endregion

    }

    public class ReportType
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(PConstants.ShortNameLength)]
        [Display(Name = "Report Type Name")]
        public string Name { get; set; }
    }

    public class ReportStatus
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(PConstants.ShortNameLength)]
        [Display(Name = "Report Type Name")]
        public string Name { get; set; }
    }

    public class ReportPriority
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(PConstants.ShortNameLength)]
        [Display(Name = "Report Type Name")]
        public string Name { get; set; }
    }

    
}