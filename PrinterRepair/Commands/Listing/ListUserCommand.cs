using Bytes2you.Validation;
using PrinterRepair.Data;
using PrinterRepairService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrinterRepair.Commands.Listing
{
    public class ListUserCommand : ICommand
    {
        private readonly IPrinterServiceContext context;

        public ListUserCommand(IPrinterServiceContext context)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            this.context = context;
        }
        public string Execute(IList<string> parameters)
        {
            var users = this.context.Users;
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < users.ToList().Count; i++)
            {
                builder.Append(users.ToList()[i].ToString());
                if (i < users.ToList().Count-1)
                {
                    builder.Append(Environment.NewLine);
                }
            }

            //foreach (var user in users)
            //{
            //    builder.Append(user.ToString());
            //    builder.Append(Environment.NewLine);
            //}

            return builder.ToString();
        }
        
    }
}
