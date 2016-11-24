namespace StampCollectorManager.INF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StampCollectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stamps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        CreationYear = c.Int(nullable: false),
                        Circulation = c.Int(nullable: false),
                        Features = c.String(),
                        PhotoUrl = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        StampCollector_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StampCollectors", t => t.StampCollector_Id)
                .Index(t => t.StampCollector_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stamps", "StampCollector_Id", "dbo.StampCollectors");
            DropIndex("dbo.Stamps", new[] { "StampCollector_Id" });
            DropTable("dbo.Stamps");
            DropTable("dbo.StampCollectors");
        }
    }
}
