using System;
using System.Collections.Generic;

namespace AssemblyRover
{
    public class Grid
    {
        public readonly int Size;
        public readonly List<Component> ComponentList;
        public readonly Rover Rover;

        private Grid(int _Size, List<Component> _ComponentList, Rover _Rover)
        {
            Size = _Size;
            ComponentList = _ComponentList;
            Rover = _Rover;
        }

        public void StartRover()
        {
            foreach (Component component in ComponentList)
            {
                Rover.GoToCoordinate(component.Coordinate);
            }
        }

        public static GridBuilder Builder()
        {
            return new GridBuilder();
        }

        public class GridBuilder
        {
            private int Size;
            private List<Component> ComponentList = new List<Component>();
            private Rover Rover;
            public int Count { get; private set; }

            public GridBuilder WithSize(int _Size)
            {
                if (_Size <= 0)
                {
                    throw new ArgumentException("Please enter a valid positive integer value.");
                }
                Size = _Size;
                return this;
            }

            public GridBuilder WithComponentCount(int _ComponentCount)
            {
                if (_ComponentCount <= 0)
                {
                    throw new ArgumentException("Please enter a valid positive integer value.");
                }
                if (Size <= 0)
                {
                    throw new ArgumentException("Grid size is not set properly.Please set grid size first.");
                }
                if (_ComponentCount > Math.Pow(Size, 2))
                {
                    throw new ArgumentException("Component count cannot be greater than grid size.");
                }
                Count = _ComponentCount;
                return this;
            }

            public GridBuilder AddComponent(Component Component)
            {
                if (CoordinateXRangeCheck(Component) || CoordinateYRangeCheck(Component))
                {
                    throw new ArgumentException("Given coordinate values should be lower than grid size and positive.");
                }
                ComponentList.Add(Component);
                return this;
            }

            private bool CoordinateXRangeCheck(Component Component)
            {
                return Component.Coordinate.X > Size - 1 || Component.Coordinate.X < 0;
            }

            private bool CoordinateYRangeCheck(Component Component)
            {
                return Component.Coordinate.Y > Size - 1 || Component.Coordinate.Y < 0;
            }

            public GridBuilder WithRover(Rover _Rover)
            {
                Rover = _Rover;
                return this;
            }

            public Grid Build()
            {
                return new Grid(Size, ComponentList, Rover);
            }
        }
    }
}
