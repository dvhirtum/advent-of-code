using FluentAssertions;
using System.Linq;
using Xunit;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class Day10Tests
    {
        [Fact]
        public void Solve1_Example()
        {
            // Arrange
            var input = new[]
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };
            var day10 = new Day10();

            // Act
            var result = day10.Solve1(input);

            // Assert
            result.Should().Be(26397);
        }

        [Fact]
        public void Solve1_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day10").ToArray();
            var day10 = new Day10();

            // Act
            var result = day10.Solve1(input);

            // Assert
            result.Should().Be(339537);
        }
        
        [Fact]
        public void Solve2_Example()
        {
            // Arrange
            var input = new[]
            {
                "[({(<(())[]>[[{[]{<()<>>",
                "[(()[<>])]({[<{<<[]>>(",
                "{([(<{}[<>[]}>{[]{[(<()>",
                "(((({<>}<{<{<>}{[]{[]{}",
                "[[<[([]))<([[{}[[()]]]",
                "[{[{({}]{}}([{[{{{}}([]",
                "{<[[]]>}<{[{[{[]{()[[[]",
                "[<(<(<(<{}))><([]([]()",
                "<{([([[(<>()){}]>(<<{{",
                "<{([{{}}[<[[[<>{}]]]>[]]"
            };
            var day10 = new Day10();

            // Act
            var result = day10.Solve2(input);

            // Assert
            result.Should().Be(288957L);
        }

        [Fact]
        public void Solve2_Puzzle()
        {
            // Arrange
            var input = InputReader.ReadInput("day10").ToArray();
            var day10 = new Day10();

            // Act
            var result = day10.Solve2(input);

            // Assert
            result.Should().Be(2412013412L);
        }
    }
}
