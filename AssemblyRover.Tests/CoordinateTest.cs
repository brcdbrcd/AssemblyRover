using FluentAssertions;
using Xunit;

namespace AssemblyRover.Tests
{
    public class CoordinateTest
    {
        [Fact]
        public void WhenCoordinatesAreSameShouldReturnTrue()
        {
            Coordinate coordinate1 = new Coordinate(1, 1);
            Coordinate coordinate2 = new Coordinate(1, 1);
            (coordinate1.Equals(coordinate2)).Should().Equals(true);
        }

        [Fact]
        public void WhenCoordinatesAreDifferentShouldReturnFalse()
        {
            Coordinate coordinate1 = new Coordinate(1, 1);
            Coordinate coordinate2 = new Coordinate(3, 2);
            (coordinate1.Equals(coordinate2)).Should().Equals(false);
        }
    }
}
