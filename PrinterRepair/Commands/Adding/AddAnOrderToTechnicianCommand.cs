using Bytes2you.Validation;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System.Collections.Generic;
using System.Linq;

namespace PrinterRepair.Commands.Adding
{
    public class AddAnOrderToTechnicianCommand : ICommand
    {
        private readonly IPrinterServiceContext context;

        public AddAnOrderToTechnicianCommand (IPrinterServiceContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var orderId = int.Parse(parameters[0]);
            var technicianName = parameters[1];

            var order = this.context.Orders.Single(o => o.Id == orderId);

            this.context.Technicians.Single(t => t.Name == technicianName).Orders.Add(order);
            this.context.SaveChanges();

            return $"Order with ID {orderId} was add to technician {technicianName}";

        }
    }
}
