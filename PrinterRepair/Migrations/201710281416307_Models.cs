namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Models : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Orders", new[] { "Printer_UserId" });
            AddColumn("dbo.Damages", "DamageType", c => c.String(nullable: false));
            AddColumn("dbo.Orders", "PrinterId", c => c.Int(nullable: false));
            AddColumn("dbo.Technicians", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Orders", "Printer_UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Printers", "Make", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Printers", "Model", c => c.String(nullable: false, maxLength: 20));
            CreateIndex("dbo.Orders", "Printer_UserId");
            AddForeignKey("dbo.Orders", "Printer_UserId", "dbo.Printers", "UserId", cascadeDelete: true);
            DropColumn("dbo.Damages", "Type");
            DropColumn("dbo.Users", "Username");
            DropColumn("dbo.Users", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Username", c => c.String());
            AddColumn("dbo.Damages", "Type", c => c.String());
            DropForeignKey("dbo.Orders", "Printer_UserId", "dbo.Printers");
            DropIndex("dbo.Orders", new[] { "Printer_UserId" });
            AlterColumn("dbo.Printers", "Model", c => c.String());
            AlterColumn("dbo.Printers", "Make", c => c.String());
            AlterColumn("dbo.Orders", "Printer_UserId", c => c.Int());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
            DropColumn("dbo.Technicians", "Name");
            DropColumn("dbo.Orders", "PrinterId");
            DropColumn("dbo.Damages", "DamageType");
            CreateIndex("dbo.Orders", "Printer_UserId");
            AddForeignKey("dbo.Orders", "Printer_UserId", "dbo.Printers", "UserId");
        }
    }
}
