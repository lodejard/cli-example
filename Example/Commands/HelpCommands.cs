using Microsoft.Extensions.CommandLineUtils;
using System;
using System.Linq;

namespace Example.Commands
{
    public class HelpCommands : ICommand
    {
        public void Register(CommandLineApplication app)
        {
            app.Command("help", help =>
            {
                help.Description = "Show help information";
                var command = help.Argument("command", "Show help for particular arguments", true);

                help.OnExecute(() =>
                {
                    CommandLineApplication helpTarget = app;
                    foreach (var helpCommand in command.Values)
                    {
                        helpTarget = app.Commands.Single(c =>
                            string.Equals(c.Name, helpCommand, StringComparison.OrdinalIgnoreCase));
                    }
                    helpTarget.ShowHelp();
                    return 0;
                });
            });
        }
    }
}
