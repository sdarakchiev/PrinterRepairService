using Bytes2you.Validation;
using PrinterRepairService.Core.Providers;
using PrinterRepairService.Providers;
using System;

namespace PrinterRepairService.Core
{
    public class Engine : IEngine
    {
        private const string TerminationComand = "exit";

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;

        public Engine (IReader reader, IWriter writer, IParser parser)
        {
            Guard.WhenArgument(reader, "reader").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(parser, "parser").IsNull().Throw();

            this.reader = reader;
            this.writer = writer;
            this.parser = parser;
        }

        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine();
                    if (commandAsString == TerminationComand.ToLower())
                    {
                        break;
                    }

                    string result = this.ProcessCommand(commandAsString);
                    this.writer.Write(result);
                }
                catch (Exception ex)
                {
                    this.writer.Write(ex.Message);
                }
            }
            
        }

        private string ProcessCommand(string commandAsString)
        {
            Guard.WhenArgument(commandAsString, "command").IsNullOrWhiteSpace().Throw();

            var command = this.parser.ParseCommand(commandAsString);
            var parameters = this.parser.ParseParameters(commandAsString);

            var executionResult = command.Execute(parameters);

            return executionResult;
        }
    }
}
