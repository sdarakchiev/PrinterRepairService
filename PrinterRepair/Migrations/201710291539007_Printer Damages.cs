namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PrinterDamages : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Printers", "Damage_PrinterId", "dbo.Damages");
            DropIndex("dbo.Printers", new[] { "Damage_PrinterId" });
            DropPrimaryKey("dbo.Damages");
            DropColumn("dbo.Damages", "PrinterId");
            DropColumn("dbo.Printers", "Damage_PrinterId");
            AddColumn("dbo.Damages", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Damages", "Printer_UserId", c => c.Int());
            AlterColumn("dbo.Damages", "DamageType", c => c.String());
            AddPrimaryKey("dbo.Damages", "Id");
            CreateIndex("dbo.Damages", "Printer_UserId");
            AddForeignKey("dbo.Damages", "Printer_UserId", "dbo.Printers", "UserId");
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Printers", "Damage_PrinterId", c => c.Int());
            AddColumn("dbo.Damages", "PrinterId", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Damages", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Damages", new[] { "Printer_UserId" });
            DropPrimaryKey("dbo.Damages");
            AlterColumn("dbo.Damages", "DamageType", c => c.String(nullable: false));
            DropColumn("dbo.Damages", "Printer_UserId");
            DropColumn("dbo.Damages", "Id");
            AddPrimaryKey("dbo.Damages", "PrinterId");
            CreateIndex("dbo.Printers", "Damage_PrinterId");
            AddForeignKey("dbo.Printers", "Damage_PrinterId", "dbo.Damages", "PrinterId");
        }
    }
}
