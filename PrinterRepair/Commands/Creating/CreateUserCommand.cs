using Bytes2you.Validation;
using PrinterRepair.Core.Factories;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System.Collections.Generic;

namespace PrinterRepair.Commands.Creating
{
    public class CreateUserCommand : ICommand
    {
        private readonly IPrinterServiceContext context;
        private readonly IModelFactory factory;

        public CreateUserCommand (IPrinterServiceContext context, IModelFactory factory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.context = context;
            this.factory = factory;
        }

        public string Execute(IList<string> parameters)
        {
            int iD = int.Parse(parameters[0]);
            string firstName = parameters[1];
            string lastName = parameters[2];

            var user = this.factory.CreateUser();
            user.Id = iD;
            user.FirstName = firstName;
            user.LastName = lastName;

            this.context.Users.Add(user);
            this.context.SaveChanges();

            return $"User with ID {user.Id} was created";
        }
    }
}
