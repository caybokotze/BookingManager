namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCapacityTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Venues", "VenueCapacityId", "dbo.VenueCapacities");
            DropIndex("dbo.Venues", new[] { "VenueCapacityId" });
            AddColumn("dbo.Venues", "Capacity", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "Name", c => c.String());
            AddColumn("dbo.AspNetUsers", "Surname", c => c.String());
            DropColumn("dbo.Venues", "VenueCapacityId");
            DropTable("dbo.VenueCapacities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VenueCapacities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Venues", "VenueCapacityId", c => c.Int(nullable: false));
            DropColumn("dbo.AspNetUsers", "Surname");
            DropColumn("dbo.AspNetUsers", "Name");
            DropColumn("dbo.Venues", "Capacity");
            CreateIndex("dbo.Venues", "VenueCapacityId");
            AddForeignKey("dbo.Venues", "VenueCapacityId", "dbo.VenueCapacities", "Id", cascadeDelete: true);
        }
    }
}
