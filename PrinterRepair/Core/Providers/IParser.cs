using PrinterRepairService.Commands;
using System.Collections.Generic;

namespace PrinterRepairService.Core.Providers
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
