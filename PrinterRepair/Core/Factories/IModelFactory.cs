using PrinterRepairService.Models;

namespace PrinterRepair.Core.Factories
{
    public interface IModelFactory
    {
        User CreateUser();

        Printer CreatePrinter();

        Order CreateOrder();
    }
}
