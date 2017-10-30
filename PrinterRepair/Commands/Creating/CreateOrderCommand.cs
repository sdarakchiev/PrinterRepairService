using Bytes2you.Validation;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System.Collections.Generic;

namespace PrinterRepair.Commands.Creating
{
    public class CreateOrderCommand : ICommand
    {

        private readonly IPrinterServiceContext context;
        private readonly IModelFactory factory;

        public CreateOrderCommand (IPrinterServiceContext context, IModelFactory factory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            var printerId = int.Parse(parameters[0]);
            var technicianName = parameters[1];

            var order = this.factory.CreateOrder();
            order.PrinterId = printerId;
            order.Technician.Name = technicianName;

            this.context.Orders.Add(order);
            this.context.SaveChanges();

            return $"New order was created";
        }
    }
}
