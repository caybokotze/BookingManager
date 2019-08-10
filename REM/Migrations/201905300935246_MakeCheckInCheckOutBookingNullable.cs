namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeCheckInCheckOutBookingNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bookings", "CheckInTime", c => c.DateTime());
            AlterColumn("dbo.Bookings", "CheckOutTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bookings", "CheckOutTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Bookings", "CheckInTime", c => c.DateTime(nullable: false));
        }
    }
}
