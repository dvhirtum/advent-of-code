using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day09Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[]
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
            var day09 = new Day09();

            // Act
            var result = day09.Solve1(input);

            // Assert
            result.Should().Be(15);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day09").ToArray();
            var day09 = new Day09();

            // Act
            var result = day09.Solve1(input);

            // Assert
            result.Should().Be(522);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[]
            {
                "2199943210",
                "3987894921",
                "9856789892",
                "8767896789",
                "9899965678"
            };
            var day09 = new Day09();

            // Act
            var result = day09.Solve2(input);

            // Assert
            result.Should().Be(1134);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day09").ToArray();
            var day09 = new Day09();

            // Act
            var result = day09.Solve2(input);

            // Assert
            result.Should().Be(916688);
        }
    }
}
