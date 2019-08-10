namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSetterToBookingCreatedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bookings", "CreatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bookings", "CreatedAt");
        }
    }
}
