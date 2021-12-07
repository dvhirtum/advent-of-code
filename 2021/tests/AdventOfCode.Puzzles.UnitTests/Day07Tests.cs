using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day07Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[] {16, 1, 2, 0, 4, 2, 7, 1, 2, 14};
            var day07 = new Day07();

            // Act
            var result = day07.Solve1(input);

            // Assert
            result.Should().Be(37);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day07").ToArray();
            var numbers = input[0].Split(",").Select(int.Parse).ToArray();
            var day07 = new Day07();

            // Act
            var result = day07.Solve1(numbers);

            // Assert
            result.Should().Be(357353);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[] {16, 1, 2, 0, 4, 2, 7, 1, 2, 14};
            var day07 = new Day07();

            // Act
            var result = day07.Solve2(input);

            // Assert
            result.Should().Be(168);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day07").ToArray();
            var numbers = input[0].Split(",").Select(int.Parse).ToArray();
            var day07 = new Day07();

            // Act
            var result = day07.Solve2(numbers);

            // Assert
            result.Should().Be(104822130);
        }
    }
}
