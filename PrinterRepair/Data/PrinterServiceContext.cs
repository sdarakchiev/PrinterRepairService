using PrinterRepairService.Models;
using System.Data.Entity;

namespace PrinterRepair.Data
{
    public class PrinterServiceContext : DbContext, IPrinterServiceContext
    {
        public PrinterServiceContext():base("PrinterServiceDb")
        {

        }

        public IDbSet<User> Users { get; set; }
        public IDbSet<Printer> Printers { get; set; }
        public IDbSet<Damage> Damages { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<Technician> Technicians { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Printer>()
                        .HasMany<Damage>(p => p.Damages)
                        .WithMany(d => d.Printers)
                        .Map(x =>
                        {
                            x.MapLeftKey("Printer_Id");
                            x.MapRightKey("Damage_Id");
                            x.ToTable("PrinterDamages");
                        }); 
            base.OnModelCreating(modelBuilder);
        }

    }
}
