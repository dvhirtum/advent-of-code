using FluentAssertions;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day01Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
            var day1 = new Day01();

            // Act
            var result = day1.Solve1(input);

            // Assert
            result.Should().Be(7);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day1 = new Day01();

            // Act
            var result = day1.Solve1(input);

            // Assert
            result.Should().Be(1215);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[] {199, 200, 208, 210, 200, 207, 240, 269, 260, 263};
            var day1 = new Day01();

            // Act
            var result = day1.Solve2(input);

            // Assert
            result.Should().Be(5);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day1 = new Day01();

            // Act
            var result = day1.Solve2(input);

            // Assert
            result.Should().Be(1150);
        }

        private IEnumerable<int> ReadInput()
        {
            using var reader = File.OpenText("day01_puzzle01_input.txt");
            var line = reader.ReadLine();
            while (line is {Length: > 0})
            {
                yield return int.Parse(line);
                line = reader.ReadLine();
            }
        }
    }
}
