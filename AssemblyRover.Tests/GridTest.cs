using FluentAssertions;
using System;
using Xunit;

namespace AssemblyRover.Tests
{
    public class GridTest
    {
        [Fact]
        public void WhenGridBuilderHasMoreElementsThanGridCapacityShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithSize(2).WithComponentCount(5);
            action.Should().Throw<ArgumentException>().WithMessage("Component count cannot be greater than grid size.");
        }

        [Fact]
        public void WhenComponentCountSentNegativeShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithComponentCount(-5);
            action.Should().Throw<ArgumentException>().WithMessage("Please enter a valid positive integer value.");
        }

        [Fact]
        public void WhenComponentCountSentZeroShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithComponentCount(0);
            action.Should().Throw<ArgumentException>().WithMessage("Please enter a valid positive integer value.");
        }

        [Fact]
        public void WhenCoordinateXGreaterThanGridCapacityShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithSize(2).AddComponent(new Component(new Coordinate(3, 1)));
            action.Should().Throw<ArgumentException>().WithMessage("Given coordinate values should be lower than grid size and positive.");
        }

        [Fact]
        public void WhenCoordinateXNegativeShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.AddComponent(new Component(new Coordinate(-1, 1)));
            action.Should().Throw<ArgumentException>().WithMessage("Given coordinate values should be lower than grid size and positive.");
        }

        [Fact]
        public void WhenCoordinateYGreaterThanGridCapacityShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithSize(2).AddComponent(new Component(new Coordinate(1, 3)));
            action.Should().Throw<ArgumentException>().WithMessage("Given coordinate values should be lower than grid size and positive.");
        }

        [Fact]
        public void WhenCoordinateYNegativeShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.AddComponent(new Component(new Coordinate(1, -1)));
            action.Should().Throw<ArgumentException>().WithMessage("Given coordinate values should be lower than grid size and positive.");
        }


        [Fact]
        public void WhenGridSizeIsNotSetAndComponentCountIsSetShouldThrowException()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Action action = () => builder.WithComponentCount(4);
            action.Should().Throw<ArgumentException>().WithMessage("Grid size is not set properly.Please set grid size first.");
        }

        [Fact]
        public void WhenAValidGridIsInitializedThenRoverShouldPickAllComponentsInCorrectOrder()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Grid grid = builder.WithSize(2)
                    .WithComponentCount(2)
                    .AddComponent(new Component(new Coordinate(1, 1)))
                    .AddComponent(new Component(new Coordinate(0, 0)))
                    .WithRover(new Rover(new Coordinate(1, 0)))
                    .Build();

            IPickUpEngine pickUpEngine = new PickUpEngine();
            pickUpEngine.PickUpComponents(grid);
            // grid.StartRover();
            for (int i = 0; i < grid.ComponentList.Count; i++)
            {
                grid.ComponentList[i].Coordinate.Should().Equals(grid.Rover.PickupCoordinates[i]);
            }
        }

        [Fact]
        public void WhenRoverPicksMultipleComponentsPathShouldBeCorrect()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Grid grid = builder.WithSize(8)
                    .WithComponentCount(5)
                    .AddComponent(new Component(new Coordinate(5, 4)))
                    .AddComponent(new Component(new Coordinate(6, 6)))
                    .AddComponent(new Component(new Coordinate(1, 0)))
                    .AddComponent(new Component(new Coordinate(0, 5)))
                    .AddComponent(new Component(new Coordinate(5, 1)))
                    .WithRover(new Rover(new Coordinate(4, 6)))
                    .Build();

            IPickUpEngine pickUpEngine = new PickUpEngine();
            pickUpEngine.PickUpComponents(grid);
            // grid.StartRover();
            grid.Rover.GetPath().Should().Equals("ESSPENNPWSWSWSWSWSPWNNNNNPESESESESEP");
        }

        [Fact]
        public void WhenRoverPicksComponentsShouldReturnTrue()
        {
            Grid.GridBuilder builder = Grid.Builder();
            Grid grid = builder.WithSize(2)
                    .WithComponentCount(2)
                    .AddComponent(new Component(new Coordinate(1, 1)))
                    .AddComponent(new Component(new Coordinate(0, 0)))
                    .WithRover(new Rover(new Coordinate(1, 0)))
                    .Build();

            IPickUpEngine pickUpEngine = new PickUpEngine();
            bool result = pickUpEngine.PickUpComponents(grid);
            result.Should().Equals(true);
        }
    }
}
