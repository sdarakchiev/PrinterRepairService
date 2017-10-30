namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Printer_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Printers", t => t.Printer_UserId)
                .Index(t => t.Printer_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Orders", new[] { "Printer_UserId" });
            DropTable("dbo.Orders");
        }
    }
}
