using Example.Commands;
using Microsoft.Extensions.CommandLineUtils;
using System.Collections.Generic;

namespace Example
{
    public class ExampleCommandLineApplication : CommandLineApplication
    {
        public ExampleCommandLineApplication(IEnumerable<ICommand> commands)
        {
            foreach (var command in commands)
            {
                command.Register(this);
            }

            OnExecute(() =>
            {
                ShowHelp();
                return 1;
            });
        }
    }
}
