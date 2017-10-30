using Ninject;
using PrinterRepair.Data;
using PrinterRepair.Migrations;
using PrinterRepair.Ninject;
using PrinterRepairService.Core;
using System.Data.Entity;

namespace PrinterRepairService
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PrinterServiceContext, Configuration>());

            IKernel kernel = new StandardKernel(new PrinterServiceModule());
            IEngine engine = kernel.Get<IEngine>();
            engine.Start();
        }
    }
}
