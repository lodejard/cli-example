using Example.Output;
using Microsoft.Extensions.CommandLineUtils;
using System.Threading.Tasks;

namespace Example.Commands
{
    public class FooCommand : ICommand
    {
        private readonly IEtc _etc;

        public FooCommand(IEtc etc)
        {
            _etc = etc;
        }

        public CommandOption QuuxOption { get; set; }
        public CommandArgument QuadArgument { get; set; }

        public void Register(CommandLineApplication app)
        {
            app.Command("foo", command =>
            {
                command.Description = "Executes foo";

                QuuxOption = command.Option("--quux", "The quux option", CommandOptionType.SingleValue);
                QuadArgument = command.Argument("quad", "The quad argument");

                command.OnExecute(Execute);
            });
        }

        public async Task<int> Execute()
        {
            try
            {
                _etc.Etc($"quux is {QuuxOption.Value()}");
                _etc.Etc($"quad is {QuadArgument.Value}");
                return 0;
            }
            catch
            {
                return 1;
            }
        }
    }
}
