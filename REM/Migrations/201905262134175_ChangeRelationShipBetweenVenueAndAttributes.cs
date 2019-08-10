namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeRelationShipBetweenVenueAndAttributes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.VenueAttributes", "Venue_Id", "dbo.Venues");
            DropIndex("dbo.VenueAttributes", new[] { "Venue_Id" });
            RenameColumn(table: "dbo.VenueAttributeLinks", name: "VenueAttributesId", newName: "VenueAttributeId");
            RenameIndex(table: "dbo.VenueAttributeLinks", name: "IX_VenueAttributesId", newName: "IX_VenueAttributeId");
            DropColumn("dbo.VenueAttributes", "Venue_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VenueAttributes", "Venue_Id", c => c.Int());
            RenameIndex(table: "dbo.VenueAttributeLinks", name: "IX_VenueAttributeId", newName: "IX_VenueAttributesId");
            RenameColumn(table: "dbo.VenueAttributeLinks", name: "VenueAttributeId", newName: "VenueAttributesId");
            CreateIndex("dbo.VenueAttributes", "Venue_Id");
            AddForeignKey("dbo.VenueAttributes", "Venue_Id", "dbo.Venues", "Id");
        }
    }
}
