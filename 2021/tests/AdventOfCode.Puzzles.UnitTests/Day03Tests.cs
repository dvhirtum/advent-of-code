using FluentAssertions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day03Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[] {"00100","11110","10110","10111","10101","01111","00111","11100","10000","11001","00010","01010"};
            var day03 = new Day03();
            
            // Act
            var result = day03.Solve1(input);

            // Assert
            result.Should().Be(198);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day03 = new Day03();

            // Act
            var result = day03.Solve1(input);

            // Assert
            result.Should().Be(3242606);
        }

        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[] {"00100","11110","10110","10111","10101","01111","00111","11100","10000","11001","00010","01010"};
            var day03 = new Day03();
            
            // Act
            var result = day03.Solve2(input);

            // Assert
            result.Should().Be(230);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = ReadInput().ToArray();
            var day03 = new Day03();

            // Act
            var result = day03.Solve2(input);

            // Assert
            result.Should().Be(4856080);
        }
        
        private IEnumerable<string> ReadInput()
        {
            using var reader = File.OpenText("day03_input.txt");
            var line = reader.ReadLine();
            while (line is {Length: > 0})
            {
                yield return line;
                line = reader.ReadLine();
            }
        }
    }
}
