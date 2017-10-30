namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrintersDamages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Damages", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Damages", new[] { "Printer_UserId" });
            CreateTable(
                "dbo.PrinterDamages",
                c => new
                    {
                        Printer_UserId = c.Int(nullable: false),
                        Damage_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Printer_UserId, t.Damage_Id })
                .ForeignKey("dbo.Printers", t => t.Printer_UserId, cascadeDelete: true)
                .ForeignKey("dbo.Damages", t => t.Damage_Id, cascadeDelete: true)
                .Index(t => t.Printer_UserId)
                .Index(t => t.Damage_Id);
            
            DropColumn("dbo.Damages", "Printer_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Damages", "Printer_UserId", c => c.Int());
            DropForeignKey("dbo.PrinterDamages", "Damage_Id", "dbo.Damages");
            DropForeignKey("dbo.PrinterDamages", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.PrinterDamages", new[] { "Damage_Id" });
            DropIndex("dbo.PrinterDamages", new[] { "Printer_UserId" });
            DropTable("dbo.PrinterDamages");
            CreateIndex("dbo.Damages", "Printer_UserId");
            AddForeignKey("dbo.Damages", "Printer_UserId", "dbo.Printers", "UserId");
        }
    }
}
