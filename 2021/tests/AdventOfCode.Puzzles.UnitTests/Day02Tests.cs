using FluentAssertions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day02Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[] {"forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"};
            var day02 = new Day02();
            
            // Act
            var result = day02.Solve1(input);

            // Assert
            result.Should().Be(150);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day02 = new Day02();

            // Act
            var result = day02.Solve1(input);

            // Assert
            result.Should().Be(1990000);
        }
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[] {"forward 5", "down 5", "forward 8", "up 3", "down 8", "forward 2"};
            var day02 = new Day02();
            
            // Act
            var result = day02.Solve2(input);

            // Assert
            result.Should().Be(900);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day02 = new Day02();

            // Act
            var result = day02.Solve2(input);

            // Assert
            result.Should().Be(1975421260);
        }

        private IEnumerable<string> ReadInput()
        {
            using var reader = File.OpenText("day02_input.txt");
            var line = reader.ReadLine();
            while (line is {Length: > 0})
            {
                yield return line;
                line = reader.ReadLine();
            }
        }
    }
}
