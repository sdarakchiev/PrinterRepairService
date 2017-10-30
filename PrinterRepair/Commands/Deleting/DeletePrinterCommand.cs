using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System.Collections.Generic;
using System.Linq;

namespace PrinterRepair.Commands.Deleting
{
    public class DeletePrinterCommand : ICommand
    {
        private readonly IPrinterServiceContext context;

        public DeletePrinterCommand(IPrinterServiceContext context)
        {
            //Guard.WhenArgument(context, "context").IsNull().Throw();

            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var printerId = int.Parse(parameters[0]);
            var printerToRemove = this.context.Printers.FirstOrDefault(p => p.UserId == printerId);

            this.context.Printers.Remove(printerToRemove);
            this.context.SaveChanges();

            return $"Printer with ID {printerToRemove.UserId} was removed successfully";
        }
    }
}
