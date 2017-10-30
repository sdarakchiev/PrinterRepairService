using PrinterRepairService.Commands;
using PrinterRepairService.Core.Factories;
using System.Collections.Generic;
using System.Linq;

namespace PrinterRepairService.Core.Providers
{
    public class CommandParser : IParser
    {
        private readonly ICommandFactory factory;

        public CommandParser(ICommandFactory factory)
        {
            this.factory = factory;
        }
        public ICommand ParseCommand(string fullCommand)
        {
            var commandName = fullCommand.Split()[0];
            return this.factory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            var commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }
            return commandParts;
        }
    }
}
