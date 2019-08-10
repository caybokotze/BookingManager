
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using REM.Core.Domain;


namespace REM.Connections
{
    public class ApplicationDbContext : IdentityDbContext<Account>
    {

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PersonDetailsBookingLink> PersonDetailsBookingLinks { get; set; }
        public DbSet<BookingVenueLink> BookingVenueLinks { get; set; }
        public DbSet<BookingInvoice> BookingInvoices { get; set; }
        public DbSet<BookingInvoiceItem> BookingInvoiceItems { get; set; }
        public DbSet<AccountBookingLink> AccountBookingLinks { get; set; }
        public DbSet<Venue> Venues { get; set; }
        public DbSet<VenueAttributeLink> VenueAttributeLinks { get; set; }
        public DbSet<VenueType> VenueTypes { get; set; }
        public DbSet<VenuePrice> VenuePrices { get; set; }
        public DbSet<VenueAttribute> VenueAttributes { get; set; }
        public DbSet<AccountMaintenanceLink> AccountMaintenanceLinks { get; set; }
        public DbSet<MaintenanceReport> MaintenanceReports { get; set; }
        public DbSet<AccountCleaningLink> AccountCleaningLinks { get; set; }
        public DbSet<CleaningReport> CleaningReports { get; set; }
        public DbSet<ReportType> ReportTypes { get; set; }
        public DbSet<VenueImage> VenueImages { get; set; }
        public DbSet<ImageLink> ImageLinks { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<StockInvoice> StockInvoices { get; set; }
        public DbSet<StockInvoiceList> StockInvoiceLists { get; set; }
        public DbSet<StockItem> StockItems { get; set; }
        public DbSet<InvoicePersonLink> InvoicePersonLinks { get; set; }
        public DbSet<DirectorsLink> DirectorsLinks { get; set; }
        public DbSet<BusinessBranch> BusinessBranches { get; set; }
        public DbSet<BranchBookingLink> BranchBookingLinks { get; set; }
        public DbSet<Business> Businesses { get; set; }
        public DbSet<BusinessBranchLink> BusinessBranchLinks { get; set; }
        public System.Data.Entity.DbSet<Markup> Markups { get; set; }



        



        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


    }
}