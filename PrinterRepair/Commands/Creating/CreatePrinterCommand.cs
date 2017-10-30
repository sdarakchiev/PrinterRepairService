using Bytes2you.Validation;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepair.Models.Enums;
using PrinterRepairService.Commands;
using System;
using System.Collections.Generic;

namespace PrinterRepair.Commands.Creating
{
    public class CreatePrinterCommand : ICommand
    {
        private readonly IPrinterServiceContext context;
        private readonly IModelFactory factory;

        public CreatePrinterCommand(IPrinterServiceContext context, IModelFactory factory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.factory = factory;
        }
        public string Execute(IList<string> parameters)
        {
            string make = parameters[0];
            string model = parameters[1];
            PrinterType type =(PrinterType)Enum.Parse(typeof(PrinterType), parameters[2]);

            var printer = this.factory.CreatePrinter();
            printer.Make = make;
            printer.Model = model;
            printer.Type = type;

            this.context.Printers.Add(printer);
            this.context.SaveChanges();

            return $"Printer with ID {printer.UserId} was created";
        }
    }
}
