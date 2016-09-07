namespace ServiceStation.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Autoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        VIN = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        DateOfBirth = c.String(),
                        Address = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        OrderAmount = c.Double(nullable: false),
                        Status = c.String(),
                        OrderAuto_Id = c.Int(),
                        OrderClient_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Autoes", t => t.OrderAuto_Id)
                .ForeignKey("dbo.Clients", t => t.OrderClient_Id)
                .Index(t => t.OrderAuto_Id)
                .Index(t => t.OrderClient_Id);
            
            CreateTable(
                "dbo.ClientAutoes",
                c => new
                    {
                        Client_Id = c.Int(nullable: false),
                        Auto_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Client_Id, t.Auto_Id })
                .ForeignKey("dbo.Clients", t => t.Client_Id, cascadeDelete: true)
                .ForeignKey("dbo.Autoes", t => t.Auto_Id, cascadeDelete: true)
                .Index(t => t.Client_Id)
                .Index(t => t.Auto_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "OrderClient_Id", "dbo.Clients");
            DropForeignKey("dbo.Orders", "OrderAuto_Id", "dbo.Autoes");
            DropForeignKey("dbo.ClientAutoes", "Auto_Id", "dbo.Autoes");
            DropForeignKey("dbo.ClientAutoes", "Client_Id", "dbo.Clients");
            DropIndex("dbo.ClientAutoes", new[] { "Auto_Id" });
            DropIndex("dbo.ClientAutoes", new[] { "Client_Id" });
            DropIndex("dbo.Orders", new[] { "OrderClient_Id" });
            DropIndex("dbo.Orders", new[] { "OrderAuto_Id" });
            DropTable("dbo.ClientAutoes");
            DropTable("dbo.Orders");
            DropTable("dbo.Clients");
            DropTable("dbo.Autoes");
        }
    }
}
