using Example.Commands;
using Example.Output;
using Microsoft.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Example
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                var services = ConfigureServices();
                var serviceProvider = services.BuildServiceProvider();

                return serviceProvider
                    .GetRequiredService<CommandLineApplication>()
                    .Execute(args);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Internal error {ex.GetType().Name}");
                Console.WriteLine(ex.Message);
                return 1;
            }
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddSingleton<CommandLineApplication, ExampleCommandLineApplication>();
            services.AddSingleton<ICommand, HelpCommands>();
            services.AddSingleton<ICommand, FooCommand>();

            services.AddSingleton<IEtc, Etc>();

            return services;
        }
    }
}
