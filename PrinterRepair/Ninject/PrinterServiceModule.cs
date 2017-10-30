using Ninject.Modules;
using PrinterRepair.Commands.Adding;
using PrinterRepair.Commands.Creating;
using PrinterRepair.Commands.Deleting;
using PrinterRepair.Commands.Listing;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using PrinterRepairService.Core;
using PrinterRepairService.Core.Factories;
using PrinterRepairService.Core.Providers;
using PrinterRepairService.Providers;

namespace PrinterRepair.Ninject
{
    public class PrinterServiceModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IEngine>().To<Engine>().InSingletonScope();

            this.Bind<IPrinterServiceContext>().To<PrinterServiceContext>();

            this.Bind<IReader>().To<ConsoleReader>();
            this.Bind<IWriter>().To<ConsoleWriter>();
            this.Bind<IParser>().To<CommandParser>();

            this.Bind<IModelFactory>().To<ModelFactory>();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();
            this.Bind<ICommand>().To<CreateUserCommand>().Named("createuser");
            this.Bind<ICommand>().To<CreatePrinterCommand>().Named("createprinter");
            this.Bind<ICommand>().To<DeletePrinterCommand>().Named("deleteprinter");
            this.Bind<ICommand>().To<DeleteUserCommand>().Named("deleteuser");
            this.Bind<ICommand>().To<ListUserCommand>().Named("listusers");
            this.Bind<ICommand>().To<CreateOrderCommand>().Named("createorder");
            this.Bind<ICommand>().To<AddAnOrderToTechnicianCommand>().Named("addordertotechnician");
        }
    }
}
