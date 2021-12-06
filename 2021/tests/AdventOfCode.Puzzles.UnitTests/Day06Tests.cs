using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day06Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[] {3, 4, 3, 1, 2};
            var day06 = new Day06();

            // Act
            var result = day06.Solve1(input);

            // Assert
            result.Should().Be(5934);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day06").ToArray();
            var numbers = input[0].Split(",").Select(int.Parse).ToArray();
            var day06 = new Day06();

            // Act
            var result = day06.Solve1(numbers);

            // Assert
            result.Should().Be(362346);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[] {3, 4, 3, 1, 2};
            var day06 = new Day06();

            // Act
            var result = day06.Solve2(input);

            // Assert
            result.Should().Be(26984457539L);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day06").ToArray();
            var numbers = input[0].Split(",").Select(int.Parse).ToArray();
            var day06 = new Day06();

            // Act
            var result = day06.Solve2(numbers);

            // Assert
            result.Should().Be(1639643057051L);
        }
    }
}
