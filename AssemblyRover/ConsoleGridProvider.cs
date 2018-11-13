using System;

namespace AssemblyRover
{
    public class ConsoleGridProvider : IGridProvider
    {
        public Grid GetGridFromInputs()
        {
            Grid.GridBuilder builder = Grid.Builder();
            
            GetSafeUserInput(builder, "grid size", v => { builder.WithSize(v); });
            GetSafeUserInput(builder, "number of components", v => { builder.WithComponentCount(v); });

            for (int i = 1; i <= builder.Count; i++)
            {
                GetSafeUserInputForCoordinate(builder, "component" + i + "'s coordinate as X,Y", c => { builder.AddComponent(new Component(c)); });
            }
            GetSafeUserInputForCoordinate(builder, "rover's coordinate X,Y", c => { builder.WithRover(new Rover(c)); });
            
            return builder.Build();
        }

        private void GetSafeUserInput(Grid.GridBuilder builder, string label, Action<int> setFunc)
        {
            bool valueSet = false;
            Console.WriteLine("Please enter " + label + " : ");
            while (!valueSet)
            {
                try
                {
                    setFunc(GetNumberValue());
                    valueSet = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void GetSafeUserInputForCoordinate(Grid.GridBuilder builder, string label, Action<Coordinate> setFunc)
        {
            bool valueSet = false;
            Console.WriteLine("Please enter " + label + " : ");
            while (!valueSet)
            {
                try
                {
                    setFunc(GetCoordinateValue());
                    valueSet = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private int GetNumberValue()
        {
            int value = 0;
            bool valid = int.TryParse(ConsoleReadLine(), out value);
            if (!valid)
            {
                throw new ArgumentException("Please enter a valid positive integer value.");
            }
            return value;
        }
        
        private Coordinate GetCoordinateValue()
        {
            int x, y;
            string value = ConsoleReadLine();
            string[] coordinates = value.Split(",");
            if(coordinates.Length != 2)
            {
                throw new ArgumentException("Please enter a valid coordinate value. Format: X,Y");
            }
            bool valid = int.TryParse(coordinates[0], out x);
            if (!valid)
            {
                throw new ArgumentException("Please enter a valid coordinate value. Format: X,Y");
            }
            valid = int.TryParse(coordinates[1], out y);
            if (!valid)
            {
                throw new ArgumentException("Please enter a valid coordinate value. Format: X,Y");
            }
            return new Coordinate(x,y);
        }

        /// <summary>
        /// In order to mock data in tests it is set virtual
        /// </summary>
        /// <returns></returns>
        protected virtual string ConsoleReadLine()
        {
            return Console.ReadLine();
        }

    }
}
