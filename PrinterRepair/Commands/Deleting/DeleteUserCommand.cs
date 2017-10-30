using Bytes2you.Validation;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System.Collections.Generic;
using System.Linq;

namespace PrinterRepair.Commands.Deleting
{
    public class DeleteUserCommand : ICommand
    {
        private readonly IPrinterServiceContext context;

        public DeleteUserCommand (IPrinterServiceContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }

        public string Execute(IList<string> parameters)
        {
            var userId = int.Parse(parameters[0]);
            var userToRemove = this.context.Users.FirstOrDefault(u => u.Id == userId);

            this.context.Users.Remove(userToRemove);
            this.context.SaveChanges();

            return $"User with ID {userToRemove.Id} was deleted successfully";
        }
        
    }
}
