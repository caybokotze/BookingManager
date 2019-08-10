using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace REM.Core.Domain
{
    public class CleaningReport
    {
        public CleaningReport()
        {
            CreatedAt = DateTime.Now;
        }
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ReportTypeId { get; set; }
        public int ReportStatusId { get; set; }
        public int ReportPriorityId { get; set; }

        #region Entity Framework Mappings.
        
        public ReportType ReportType { get; set; }
        public ICollection<AccountCleaningLink> AccountCleaningLinks { get; set; }

        #endregion
    }

    public class AccountCleaningLink
    {
        public int Id { get; set; }

        #region Entity Framework Mappings
        //Linked: To one instance of each of these.
        public int CleaningReportId { get; set; }
        public CleaningReport CleaningReport { get; set; }
        //
        public int PersonDetailsId { get; set; }
        public PersonDetail PersonDetail { get; set; }
        //
        public int VenueId { get; set; }
        public Venue Venue { get; set; }
        //

        #endregion

    }

}