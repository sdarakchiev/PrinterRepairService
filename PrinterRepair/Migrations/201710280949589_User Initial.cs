namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Printers",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Damage_Type = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        Printer_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Printers", t => t.Printer_UserId)
                .Index(t => t.Printer_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Users", new[] { "Printer_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Printers");
        }
    }
}
