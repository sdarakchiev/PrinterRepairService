using PrinterRepairService.Models;
using System.Data.Entity;

namespace PrinterRepair.Data
{
    public interface IPrinterServiceContext
    {
        IDbSet<User> Users { get; set; }
        IDbSet<Printer> Printers { get; set; }
        IDbSet<Damage> Damages { get; set; }
        IDbSet<Order> Orders { get; set; }
        IDbSet<Technician> Technicians { get; set; }

        int SaveChanges();
    }
}
