namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TechnicianInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Technicians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "Technician_Id", c => c.Int());
            CreateIndex("dbo.Orders", "Technician_Id");
            AddForeignKey("dbo.Orders", "Technician_Id", "dbo.Technicians", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Technician_Id", "dbo.Technicians");
            DropIndex("dbo.Orders", new[] { "Technician_Id" });
            DropColumn("dbo.Orders", "Technician_Id");
            DropTable("dbo.Technicians");
        }
    }
}
