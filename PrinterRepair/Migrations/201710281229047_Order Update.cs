namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Technicians", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "Technician_Id", "dbo.Technicians");
            DropIndex("dbo.Orders", new[] { "Technician_Id" });
            DropIndex("dbo.Technicians", new[] { "Order_Id" });
            RenameColumn(table: "dbo.Orders", name: "Technician_Id", newName: "TechnicianId");
            AlterColumn("dbo.Orders", "TechnicianId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "TechnicianId");
            AddForeignKey("dbo.Orders", "TechnicianId", "dbo.Technicians", "Id", cascadeDelete: true);
            DropColumn("dbo.Technicians", "Order_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Technicians", "Order_Id", c => c.Int());
            DropForeignKey("dbo.Orders", "TechnicianId", "dbo.Technicians");
            DropIndex("dbo.Orders", new[] { "TechnicianId" });
            AlterColumn("dbo.Orders", "TechnicianId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "TechnicianId", newName: "Technician_Id");
            CreateIndex("dbo.Technicians", "Order_Id");
            CreateIndex("dbo.Orders", "Technician_Id");
            AddForeignKey("dbo.Orders", "Technician_Id", "dbo.Technicians", "Id");
            AddForeignKey("dbo.Technicians", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
