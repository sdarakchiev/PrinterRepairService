namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrinterDamagesUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.PrinterDamages", name: "Printer_UserId", newName: "Printer_Id");
            RenameIndex(table: "dbo.PrinterDamages", name: "IX_Printer_UserId", newName: "IX_Printer_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.PrinterDamages", name: "IX_Printer_Id", newName: "IX_Printer_UserId");
            RenameColumn(table: "dbo.PrinterDamages", name: "Printer_Id", newName: "Printer_UserId");
        }
    }
}
