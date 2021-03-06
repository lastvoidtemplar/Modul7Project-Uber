namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DriverProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.DriverId);
            
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        CountOrders = c.Int(nullable: false),
                        Rating = c.Single(nullable: false),
                        VehicleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vehicles", t => t.VehicleId, cascadeDelete: true)
                .Index(t => t.VehicleId);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(nullable: false, maxLength: 50),
                        HorsePower = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserProfileId = c.Int(nullable: false),
                        DriverProfileId = c.Int(nullable: false),
                        TownId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DriverProfiles", t => t.DriverProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Towns", t => t.TownId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserProfileId, cascadeDelete: true)
                .Index(t => t.UserProfileId)
                .Index(t => t.DriverProfileId)
                .Index(t => t.TownId);
            
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Country = c.String(nullable: false, maxLength: 50),
                        ZipCode = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Age = c.Int(nullable: false),
                        CountOrders = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserProfileId", "dbo.UserProfiles");
            DropForeignKey("dbo.UserProfiles", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "TownId", "dbo.Towns");
            DropForeignKey("dbo.Orders", "DriverProfileId", "dbo.DriverProfiles");
            DropForeignKey("dbo.DriverProfiles", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Drivers", "VehicleId", "dbo.Vehicles");
            DropIndex("dbo.UserProfiles", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "TownId" });
            DropIndex("dbo.Orders", new[] { "DriverProfileId" });
            DropIndex("dbo.Orders", new[] { "UserProfileId" });
            DropIndex("dbo.Drivers", new[] { "VehicleId" });
            DropIndex("dbo.DriverProfiles", new[] { "DriverId" });
            DropTable("dbo.Users");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.Towns");
            DropTable("dbo.Orders");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Drivers");
            DropTable("dbo.DriverProfiles");
        }
    }
}
