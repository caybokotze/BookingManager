namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedIntoMultipleDropDownLists : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Rates ON");
            Sql("INSERT INTO Rates (Id, Vat, Tax) VALUES (1, 14, 28)");
            Sql("INSERT INTO Rates (Id, Vat, Tax) VALUES (2, 15, 28)");
            Sql("SET IDENTITY_INSERT Rates OFF");

            Sql("SET IDENTITY_INSERT VenueAttributes ON");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (1, 'Bed')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (2, 'Chair')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (3, 'Washing Machine')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (4, 'Room')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (5, 'Bathroom')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (6, 'Shower')");
            Sql("INSERT INTO VenueAttributes (Id, Name) VALUES (7, 'Bath')");
            Sql("SET IDENTITY_INSERT VenueAttributes OFF");

            Sql("SET IDENTITY_INSERT BookingTypes ON");
            Sql("INSERT INTO BookingTypes (Id, Name) VALUES (1, 'Group')");
            Sql("INSERT INTO BookingTypes (Id, Name) VALUES (2, 'Individual')");
            Sql("SET IDENTITY_INSERT BookingTypes OFF");

            Sql("SET IDENTITY_INSERT VenueTypes ON");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (1, 'Hall')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (2, 'Apartment')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (3, 'Single Room')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (4, 'Lounge')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (5, 'Lecture Theater')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (6, 'Cinema')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (7, 'Restaurant')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (8, 'Pavilion')");
            Sql("INSERT INTO VenueTypes (Id, Name) VALUES (9, 'Stadium')");
            Sql("SET IDENTITY_INSERT VenueTypes OFF");

            Sql("SET IDENTITY_INSERT ReportTypes ON");
            Sql("INSERT INTO ReportTypes (Id, Name) VALUES (1, 'Low Priority')");
            Sql("INSERT INTO ReportTypes (Id, Name) VALUES (2, 'Medium Priority')");
            Sql("INSERT INTO ReportTypes (Id, Name) VALUES (3, 'High Priority')");
            Sql("SET IDENTITY_INSERT ReportTypes OFF");
        }
        
        public override void Down()
        {
        }
    }
}
