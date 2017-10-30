using Bytes2you.Validation;
using Ninject;
using PrinterRepairService.Commands;

namespace PrinterRepairService.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory ( IKernel kernel)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();
            this.kernel = kernel;
        }

        public ICommand CreateCommand(string commandName)
        {
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
