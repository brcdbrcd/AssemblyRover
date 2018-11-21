using Microsoft.Extensions.DependencyInjection;
using System;

namespace AssemblyRover
{
    class Program
    {
        // private static IGridProvider _inputService; 

        public static void Main(string[] args)
        {
            // _inputService = new ConsoleGridProvider();
            // Grid Grid = _inputService.GetGridFromInputs();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            // getting inputs
            var GridService = serviceProvider.GetService<IGridProvider>();
            Grid Grid = GridService.GetGridFromInputs();
            
            // Rover runs and picks the components
            // Grid.StartRover();
            var PickUpService = serviceProvider.GetService<IPickUpEngine>();
            if (PickUpService.PickUpComponents(Grid))
            {
                Console.WriteLine("PATH : " + Grid.Rover.GetPath());
            }
            else
            {
                Console.WriteLine("Rover could not pick up components..");
            }

            Console.WriteLine("Press <Enter> to exit...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGridProvider, ConsoleGridProvider>()
                .AddSingleton<IPickUpEngine, PickUpEngine>();
        }
    }
}
