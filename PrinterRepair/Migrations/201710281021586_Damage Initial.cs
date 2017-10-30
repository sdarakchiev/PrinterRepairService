namespace PrinterRepair.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DamageInitial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Damages",
                c => new
                    {
                        PrinterId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.PrinterId);
            
            AddColumn("dbo.Printers", "Damage_PrinterId", c => c.Int());
            CreateIndex("dbo.Printers", "Damage_PrinterId");
            AddForeignKey("dbo.Printers", "Damage_PrinterId", "dbo.Damages", "PrinterId");
            DropColumn("dbo.Printers", "Damage_Type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Printers", "Damage_Type", c => c.String());
            DropForeignKey("dbo.Printers", "Damage_PrinterId", "dbo.Damages");
            DropIndex("dbo.Printers", new[] { "Damage_PrinterId" });
            DropColumn("dbo.Printers", "Damage_PrinterId");
            DropTable("dbo.Damages");
        }
    }
}
