namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookingInvoiceItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        BookingInvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingInvoices", t => t.BookingInvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.BookingInvoiceId);
            
            CreateTable(
                "dbo.BookingInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rates", t => t.RatesId, cascadeDelete: true)
                .Index(t => t.RatesId);
            
            CreateTable(
                "dbo.Rates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Vat = c.Double(nullable: false),
                        Tax = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Venues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        RoomNumber = c.Byte(nullable: false),
                        VenueName = c.String(),
                        VenueTypeId = c.Int(nullable: false),
                        VenuePricesId = c.Int(nullable: false),
                        VenueCapacityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VenueCapacities", t => t.VenueCapacityId, cascadeDelete: true)
                .ForeignKey("dbo.VenuePrices", t => t.VenuePricesId, cascadeDelete: true)
                .ForeignKey("dbo.VenueTypes", t => t.VenueTypeId, cascadeDelete: true)
                .Index(t => t.VenueTypeId)
                .Index(t => t.VenuePricesId)
                .Index(t => t.VenueCapacityId);
            
            CreateTable(
                "dbo.BookingVenueLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingFrom = c.DateTime(nullable: false),
                        BookingTo = c.DateTime(nullable: false),
                        CheckInTime = c.DateTime(nullable: false),
                        CheckOutTime = c.DateTime(nullable: false),
                        GuestsAmount = c.Int(nullable: false),
                        BookingInvoiceId = c.Int(nullable: false),
                        BookingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BookingInvoices", t => t.BookingInvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.BookingTypes", t => t.BookingTypeId, cascadeDelete: true)
                .Index(t => t.BookingInvoiceId)
                .Index(t => t.BookingTypeId);
            
            CreateTable(
                "dbo.BookingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BranchBookingLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookingId = c.Int(nullable: false),
                        BusinessBranchId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessBranches", t => t.BusinessBranchId, cascadeDelete: true)
                .Index(t => t.BookingId)
                .Index(t => t.BusinessBranchId);
            
            CreateTable(
                "dbo.BusinessBranches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BranchName = c.String(maxLength: 100),
                        TelNumber = c.String(maxLength: 14),
                        StreetAddress = c.String(maxLength: 255),
                        PostalAddress = c.String(maxLength: 255),
                        EmailAddress = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BusinessBranchLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BusinessBranchId = c.Int(nullable: false),
                        BusinessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Businesses", t => t.BusinessId, cascadeDelete: true)
                .ForeignKey("dbo.BusinessBranches", t => t.BusinessBranchId, cascadeDelete: true)
                .Index(t => t.BusinessBranchId)
                .Index(t => t.BusinessId);
            
            CreateTable(
                "dbo.Businesses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        EstablishedAt = c.DateTime(nullable: false),
                        TaxNumber = c.String(maxLength: 10),
                        VatNumber = c.String(maxLength: 15),
                        BusinessNumber = c.String(maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DirectorsLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonDetailsId = c.Int(nullable: false),
                        BusinessBranchId = c.Int(nullable: false),
                        PersonDetails_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BusinessBranches", t => t.BusinessBranchId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonDetails_Id)
                .Index(t => t.BusinessBranchId)
                .Index(t => t.PersonDetails_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        IdNumber = c.String(),
                        Address = c.String(),
                        CellPhoneNumber = c.String(),
                        PersonId = c.Int(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.CleaningLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CleaningReportId = c.Int(nullable: false),
                        PersonDetailsId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                        PersonDetails_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CleaningReports", t => t.CleaningReportId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonDetails_Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.CleaningReportId)
                .Index(t => t.VenueId)
                .Index(t => t.PersonDetails_Id);
            
            CreateTable(
                "dbo.CleaningReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportTypes", t => t.ReportTypeId, cascadeDelete: true)
                .Index(t => t.ReportTypeId);
            
            CreateTable(
                "dbo.ReportTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MaintenanceLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaintenanceReportId = c.Int(nullable: false),
                        PersonDetailsId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                        PersonDetails_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MaintenanceReports", t => t.MaintenanceReportId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonDetails_Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .Index(t => t.MaintenanceReportId)
                .Index(t => t.VenueId)
                .Index(t => t.PersonDetails_Id);
            
            CreateTable(
                "dbo.MaintenanceReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Details = c.String(),
                        ReportTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReportTypes", t => t.ReportTypeId, cascadeDelete: true)
                .Index(t => t.ReportTypeId);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        EmailAddress = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InvoicePersonLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonId = c.Int(nullable: false),
                        StockInvoiceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockInvoices", t => t.StockInvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.StockInvoiceId);
            
            CreateTable(
                "dbo.StockInvoices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RatesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rates", t => t.RatesId, cascadeDelete: true)
                .Index(t => t.RatesId);
            
            CreateTable(
                "dbo.StockInvoiceLists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockInvoiceId = c.Int(nullable: false),
                        StockItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockInvoices", t => t.StockInvoiceId, cascadeDelete: true)
                .ForeignKey("dbo.StockItems", t => t.StockItemId, cascadeDelete: true)
                .Index(t => t.StockInvoiceId)
                .Index(t => t.StockItemId);
            
            CreateTable(
                "dbo.StockItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                        Cost = c.Double(nullable: false),
                        MarkupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markups", t => t.MarkupId, cascadeDelete: true)
                .Index(t => t.MarkupId);
            
            CreateTable(
                "dbo.Markups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonBookingLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBooking = c.Boolean(nullable: false),
                        PersonId = c.Int(nullable: false),
                        BookingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bookings", t => t.BookingId, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.PersonId, cascadeDelete: true)
                .Index(t => t.PersonId)
                .Index(t => t.BookingId);
            
            CreateTable(
                "dbo.PersonDetailsBookingLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PersonDetailsId = c.Int(nullable: false),
                        PersonBookingLinkId = c.Int(nullable: false),
                        PersonDetails_Id = c.String(maxLength: 128),
                        Booking_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PersonBookingLinks", t => t.PersonBookingLinkId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.PersonDetails_Id)
                .ForeignKey("dbo.Bookings", t => t.Booking_Id)
                .Index(t => t.PersonBookingLinkId)
                .Index(t => t.PersonDetails_Id)
                .Index(t => t.Booking_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ImageLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueImageId = c.Int(nullable: false),
                        VenueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .ForeignKey("dbo.VenueImages", t => t.VenueImageId, cascadeDelete: true)
                .Index(t => t.VenueImageId)
                .Index(t => t.VenueId);
            
            CreateTable(
                "dbo.VenueImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FileDir = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenueAttributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Byte(nullable: false),
                        Name = c.String(),
                        Venue_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.Venue_Id)
                .Index(t => t.Venue_Id);
            
            CreateTable(
                "dbo.VenueAttributeLinks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VenueId = c.Int(nullable: false),
                        VenueAttributesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Venues", t => t.VenueId, cascadeDelete: true)
                .ForeignKey("dbo.VenueAttributes", t => t.VenueAttributesId, cascadeDelete: true)
                .Index(t => t.VenueId)
                .Index(t => t.VenueAttributesId);
            
            CreateTable(
                "dbo.VenueCapacities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VenuePrices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Double(nullable: false),
                        MarkupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Markups", t => t.MarkupId, cascadeDelete: true)
                .Index(t => t.MarkupId);
            
            CreateTable(
                "dbo.VenueTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Venues", "VenueTypeId", "dbo.VenueTypes");
            DropForeignKey("dbo.Venues", "VenuePricesId", "dbo.VenuePrices");
            DropForeignKey("dbo.VenuePrices", "MarkupId", "dbo.Markups");
            DropForeignKey("dbo.Venues", "VenueCapacityId", "dbo.VenueCapacities");
            DropForeignKey("dbo.VenueAttributes", "Venue_Id", "dbo.Venues");
            DropForeignKey("dbo.VenueAttributeLinks", "VenueAttributesId", "dbo.VenueAttributes");
            DropForeignKey("dbo.VenueAttributeLinks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.ImageLinks", "VenueImageId", "dbo.VenueImages");
            DropForeignKey("dbo.ImageLinks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.BookingVenueLinks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.PersonDetailsBookingLinks", "Booking_Id", "dbo.Bookings");
            DropForeignKey("dbo.DirectorsLinks", "PersonDetails_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonDetailsBookingLinks", "PersonDetails_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.PersonDetailsBookingLinks", "PersonBookingLinkId", "dbo.PersonBookingLinks");
            DropForeignKey("dbo.AspNetUsers", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonBookingLinks", "PersonId", "dbo.People");
            DropForeignKey("dbo.PersonBookingLinks", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.InvoicePersonLinks", "PersonId", "dbo.People");
            DropForeignKey("dbo.StockInvoiceLists", "StockItemId", "dbo.StockItems");
            DropForeignKey("dbo.StockItems", "MarkupId", "dbo.Markups");
            DropForeignKey("dbo.StockInvoiceLists", "StockInvoiceId", "dbo.StockInvoices");
            DropForeignKey("dbo.StockInvoices", "RatesId", "dbo.Rates");
            DropForeignKey("dbo.InvoicePersonLinks", "StockInvoiceId", "dbo.StockInvoices");
            DropForeignKey("dbo.MaintenanceLinks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.MaintenanceLinks", "PersonDetails_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.MaintenanceReports", "ReportTypeId", "dbo.ReportTypes");
            DropForeignKey("dbo.MaintenanceLinks", "MaintenanceReportId", "dbo.MaintenanceReports");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CleaningLinks", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.CleaningLinks", "PersonDetails_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CleaningReports", "ReportTypeId", "dbo.ReportTypes");
            DropForeignKey("dbo.CleaningLinks", "CleaningReportId", "dbo.CleaningReports");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.DirectorsLinks", "BusinessBranchId", "dbo.BusinessBranches");
            DropForeignKey("dbo.BusinessBranchLinks", "BusinessBranchId", "dbo.BusinessBranches");
            DropForeignKey("dbo.BusinessBranchLinks", "BusinessId", "dbo.Businesses");
            DropForeignKey("dbo.BranchBookingLinks", "BusinessBranchId", "dbo.BusinessBranches");
            DropForeignKey("dbo.BranchBookingLinks", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.BookingVenueLinks", "BookingId", "dbo.Bookings");
            DropForeignKey("dbo.Bookings", "BookingTypeId", "dbo.BookingTypes");
            DropForeignKey("dbo.Bookings", "BookingInvoiceId", "dbo.BookingInvoices");
            DropForeignKey("dbo.BookingInvoiceItems", "VenueId", "dbo.Venues");
            DropForeignKey("dbo.BookingInvoiceItems", "BookingInvoiceId", "dbo.BookingInvoices");
            DropForeignKey("dbo.BookingInvoices", "RatesId", "dbo.Rates");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.VenuePrices", new[] { "MarkupId" });
            DropIndex("dbo.VenueAttributeLinks", new[] { "VenueAttributesId" });
            DropIndex("dbo.VenueAttributeLinks", new[] { "VenueId" });
            DropIndex("dbo.VenueAttributes", new[] { "Venue_Id" });
            DropIndex("dbo.ImageLinks", new[] { "VenueId" });
            DropIndex("dbo.ImageLinks", new[] { "VenueImageId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.PersonDetailsBookingLinks", new[] { "Booking_Id" });
            DropIndex("dbo.PersonDetailsBookingLinks", new[] { "PersonDetails_Id" });
            DropIndex("dbo.PersonDetailsBookingLinks", new[] { "PersonBookingLinkId" });
            DropIndex("dbo.PersonBookingLinks", new[] { "BookingId" });
            DropIndex("dbo.PersonBookingLinks", new[] { "PersonId" });
            DropIndex("dbo.StockItems", new[] { "MarkupId" });
            DropIndex("dbo.StockInvoiceLists", new[] { "StockItemId" });
            DropIndex("dbo.StockInvoiceLists", new[] { "StockInvoiceId" });
            DropIndex("dbo.StockInvoices", new[] { "RatesId" });
            DropIndex("dbo.InvoicePersonLinks", new[] { "StockInvoiceId" });
            DropIndex("dbo.InvoicePersonLinks", new[] { "PersonId" });
            DropIndex("dbo.MaintenanceReports", new[] { "ReportTypeId" });
            DropIndex("dbo.MaintenanceLinks", new[] { "PersonDetails_Id" });
            DropIndex("dbo.MaintenanceLinks", new[] { "VenueId" });
            DropIndex("dbo.MaintenanceLinks", new[] { "MaintenanceReportId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.CleaningReports", new[] { "ReportTypeId" });
            DropIndex("dbo.CleaningLinks", new[] { "PersonDetails_Id" });
            DropIndex("dbo.CleaningLinks", new[] { "VenueId" });
            DropIndex("dbo.CleaningLinks", new[] { "CleaningReportId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUsers", new[] { "PersonId" });
            DropIndex("dbo.DirectorsLinks", new[] { "PersonDetails_Id" });
            DropIndex("dbo.DirectorsLinks", new[] { "BusinessBranchId" });
            DropIndex("dbo.BusinessBranchLinks", new[] { "BusinessId" });
            DropIndex("dbo.BusinessBranchLinks", new[] { "BusinessBranchId" });
            DropIndex("dbo.BranchBookingLinks", new[] { "BusinessBranchId" });
            DropIndex("dbo.BranchBookingLinks", new[] { "BookingId" });
            DropIndex("dbo.Bookings", new[] { "BookingTypeId" });
            DropIndex("dbo.Bookings", new[] { "BookingInvoiceId" });
            DropIndex("dbo.BookingVenueLinks", new[] { "VenueId" });
            DropIndex("dbo.BookingVenueLinks", new[] { "BookingId" });
            DropIndex("dbo.Venues", new[] { "VenueCapacityId" });
            DropIndex("dbo.Venues", new[] { "VenuePricesId" });
            DropIndex("dbo.Venues", new[] { "VenueTypeId" });
            DropIndex("dbo.BookingInvoices", new[] { "RatesId" });
            DropIndex("dbo.BookingInvoiceItems", new[] { "BookingInvoiceId" });
            DropIndex("dbo.BookingInvoiceItems", new[] { "VenueId" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.VenueTypes");
            DropTable("dbo.VenuePrices");
            DropTable("dbo.VenueCapacities");
            DropTable("dbo.VenueAttributeLinks");
            DropTable("dbo.VenueAttributes");
            DropTable("dbo.VenueImages");
            DropTable("dbo.ImageLinks");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.PersonDetailsBookingLinks");
            DropTable("dbo.PersonBookingLinks");
            DropTable("dbo.Markups");
            DropTable("dbo.StockItems");
            DropTable("dbo.StockInvoiceLists");
            DropTable("dbo.StockInvoices");
            DropTable("dbo.InvoicePersonLinks");
            DropTable("dbo.People");
            DropTable("dbo.MaintenanceReports");
            DropTable("dbo.MaintenanceLinks");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.ReportTypes");
            DropTable("dbo.CleaningReports");
            DropTable("dbo.CleaningLinks");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.DirectorsLinks");
            DropTable("dbo.Businesses");
            DropTable("dbo.BusinessBranchLinks");
            DropTable("dbo.BusinessBranches");
            DropTable("dbo.BranchBookingLinks");
            DropTable("dbo.BookingTypes");
            DropTable("dbo.Bookings");
            DropTable("dbo.BookingVenueLinks");
            DropTable("dbo.Venues");
            DropTable("dbo.Rates");
            DropTable("dbo.BookingInvoices");
            DropTable("dbo.BookingInvoiceItems");
        }
    }
}
