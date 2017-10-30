namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Technician : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Technicians", "Order_Id", c => c.Int());
            CreateIndex("dbo.Technicians", "Order_Id");
            AddForeignKey("dbo.Technicians", "Order_Id", "dbo.Orders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Technicians", "Order_Id", "dbo.Orders");
            DropIndex("dbo.Technicians", new[] { "Order_Id" });
            DropColumn("dbo.Technicians", "Order_Id");
        }
    }
}
