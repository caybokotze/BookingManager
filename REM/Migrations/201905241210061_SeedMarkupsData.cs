namespace REM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedMarkupsData : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Markups ON");
            Sql("INSERT INTO Markups (Id, Value) VALUES (1, 0.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (2, 2.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (3, 5.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (4, 10.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (5, 15.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (6, 20.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (7, 30.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (8, 50.0)");
            Sql("INSERT INTO Markups (Id, Value) VALUES (9, 100.0)");
            Sql("SET IDENTITY_INSERT Markups OFF");
        }
        
        public override void Down()
        {
        }
    }
}
