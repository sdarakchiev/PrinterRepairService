using PrinterRepairService.Commands;

namespace PrinterRepairService.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);

    }
}
