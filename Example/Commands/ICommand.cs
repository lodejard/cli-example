using Microsoft.Extensions.CommandLineUtils;

namespace Example.Commands
{
    public interface ICommand
    {
        void Register(CommandLineApplication app);
    }
}
