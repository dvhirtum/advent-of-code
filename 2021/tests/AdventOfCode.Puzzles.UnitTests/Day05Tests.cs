using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day05Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[]
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
            var day05 = new Day05();
            
            // Act
            var result = day05.Solve1(input);

            // Assert
            result.Should().Be(5);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day05").ToArray();
            var day05 = new Day05();

            // Act
            var result = day05.Solve1(input);

            // Assert
            result.Should().Be(6856);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[]
            {
                "0,9 -> 5,9",
                "8,0 -> 0,8",
                "9,4 -> 3,4",
                "2,2 -> 2,1",
                "7,0 -> 7,4",
                "6,4 -> 2,0",
                "0,9 -> 2,9",
                "3,4 -> 1,4",
                "0,0 -> 8,8",
                "5,5 -> 8,2"
            };
            var day05 = new Day05();
            
            // Act
            var result = day05.Solve2(input);

            // Assert
            result.Should().Be(12);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day05").ToArray();
            var day05 = new Day05();

            // Act
            var result = day05.Solve2(input);

            // Assert
            result.Should().Be(20666);
        }
    }
}
