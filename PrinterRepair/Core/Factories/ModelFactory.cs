using PrinterRepairService.Models;

namespace PrinterRepair.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Printer CreatePrinter()
        {
            return new Printer();
        }

        public User CreateUser()
        {
            return new User();
        }

        public Order CreateOrder()
        {
            return new Order();
        }
    }
}
