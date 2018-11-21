using FluentAssertions;
using Xunit;

namespace AssemblyRover.Tests
{
    public class InputProviderFromConsoleTest
    {
        /// <summary>
        ///  Mock class for console readline
        /// </summary>
        class ConsoleMockInputProvider : ConsoleGridProvider
        {
            private readonly string[] Input;
            private int Index;

            public ConsoleMockInputProvider(string[] _Input)
            {
                Input = _Input;
                Index = 0;
            }

            protected override string ConsoleReadLine()
            {
                return Input[Index++];
            }
        }

        [Fact]
        public void WhenValidInputIsGivenThenValidGridIsReturned()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "2", "2", "1,1", "0,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        [Fact]
        public void WhenInvalidInputIsGivenForSizeThenUserPromptShouldBeRetried()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "k", "2", "2", "1,1", "0,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        [Fact]
        public void WhenInvalidInputIsGivenForComponentCountThenUserPromptShouldBeRetried()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "2", "x", "2", "1,1", "0,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        [Fact]
        public void WhenInvalidInputIsGivenForFirstComponentThenUserPromptShouldBeRetried()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "2", "2", "x,y", "1,1", "0,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        [Fact]
        public void WhenInvalidInputIsGivenForSecondComponentThenUserPromptShouldBeRetried()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "2", "2", "1,1", "x,y", "0,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        [Fact]
        public void WhenInvalidInputIsGivenForRoverThenUserPromptShouldBeRetried()
        {
            ConsoleMockInputProvider mockInputProvider = new ConsoleMockInputProvider(new[] { "2", "2", "1,1", "0,0", "x,0", "1,0" });
            Grid grid = mockInputProvider.GetGridFromInputs();
            ShouldCheckValidGrid(grid);
        }

        private void ShouldCheckValidGrid(Grid grid)
        {
            grid.Should().NotBeNull();
            grid.Size.Should().Equals(2);
            grid.ComponentList.Count.Should().Equals(2);
            grid.ComponentList[0].Coordinate.X.Should().Equals(1);
            grid.ComponentList[0].Coordinate.Y.Should().Equals(1);
            grid.ComponentList[1].Coordinate.X.Should().Equals(0);
            grid.ComponentList[1].Coordinate.Y.Should().Equals(0);
            grid.Rover.Coordinate.X.Should().Equals(1);
            grid.Rover.Coordinate.Y.Should().Equals(0);
        }
    }
}
