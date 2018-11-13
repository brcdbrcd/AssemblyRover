using System;

namespace AssemblyRover
{
    class Program
    {
        private static IGridProvider _inputService;
        
        static void Main(string[] args)
        {
            _inputService = new ConsoleGridProvider();
            Grid Grid = _inputService.GetGridFromInputs();

            // Rover runs and picks the components
            Grid.StartRover();

            Console.WriteLine("PATH : " + Grid.Rover.GetPath());

            Console.WriteLine("Press <Enter> to exit...");
            while (Console.ReadKey(true).Key != ConsoleKey.Enter) { }
        }
    }
}
