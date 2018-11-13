using FluentAssertions;
using Xunit;

namespace AssemblyRover.Tests
{
    public class RoverTest
    {
        [Fact]
        public void WhenRoverArrivesTargetItsCoordinateShouldBeTheSameAsTargetsCoordinate()
        {
            Rover rover = new Rover(new Coordinate(1, 1));
            Coordinate target = new Coordinate(2, 1);
            rover.GoToCoordinate(target);
            rover.Coordinate.Should().Equals(target);
        }

        [Fact]
        public void WhenTargetIsOnEastPathShouldBe_EP()
        {
            Rover rover = new Rover(new Coordinate(1, 1));
            Coordinate target = new Coordinate(2, 1);
            rover.GoToCoordinate(target);
            rover.GetPath().Should().Equals("EP");
        }

        [Fact]
        public void WhenTargetIsOnWestPathShouldBe_WP()
        {
            Rover rover = new Rover(new Coordinate(2, 1));
            Coordinate target = new Coordinate(1, 1);
            rover.GoToCoordinate(target);
            rover.GetPath().Should().Equals("WP");
        }

        [Fact]
        public void WhenTargetIsOnNorthPathShouldBe_NP()
        {
            Rover rover = new Rover(new Coordinate(1, 1));
            Coordinate target = new Coordinate(1, 2);
            rover.GoToCoordinate(target);
            rover.GetPath().Should().Equals("NP");
        }

        [Fact]
        public void WhenTargetIsOnSouthPathShouldBe_SP()
        {
            Rover rover = new Rover(new Coordinate(1,2));
            Coordinate target = new Coordinate(1, 1);
            rover.GoToCoordinate(target);
            rover.GetPath().Should().Equals("SP");
        }
    }
}
