namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAmountPropertyFromVenueAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Venues", "CreatedAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.VenueAttributeLinks", "Amount", c => c.Int(nullable: false));
            DropColumn("dbo.VenueAttributes", "Amount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VenueAttributes", "Amount", c => c.Byte(nullable: false));
            DropColumn("dbo.VenueAttributeLinks", "Amount");
            DropColumn("dbo.Venues", "CreatedAt");
        }
    }
}
