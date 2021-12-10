using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day10
    {
        private readonly Dictionary<char, char> _matchingClosingChars =
            new() {{'{', '}'}, {'[', ']'}, {'(', ')'}, {'<', '>'}};

        private readonly Dictionary<char, char> _matchingOpeningChars =
            new() {{'}', '{'}, {']', '['}, {')', '('}, {'>', '<'}};

        public int Solve1(string[] input)
            => input.Select(CheckForSyntaxError).Sum(x => x.score);

        public long Solve2(string[] input)
        {
            var scores = input.Select(CheckForSyntaxError)
                .Where(x => x.score == 0)
                .Select(CompleteLineScore)
                .OrderBy(x => x)
                .ToArray();

            return scores.Skip(scores.Length / 2).Take(1).Single();
        }

        private long CompleteLineScore((int score, Stack<char> incompleteLine) input)
        {
            var score = 0L;
            while (input.incompleteLine.Any())
            {
                var character = input.incompleteLine.Pop();
                score *= 5;
                score += _matchingClosingChars[character] switch
                {
                    ')' => 1,
                    ']' => 2,
                    '}' => 3,
                    '>' => 4,
                    _ => throw new ArgumentOutOfRangeException()
                };
            }

            return score;
        }

        private (int score, Stack<char> incompleteLine) CheckForSyntaxError(string input)
        {
            var stack = new Stack<char>();

            foreach (var character in input)
            {
                if (character is '{' or '(' or '[' or '<')
                {
                    stack.Push(character);
                }
                else
                {
                    var previous = stack.Pop();

                    if (previous != _matchingOpeningChars[character])
                    {
                        return character switch
                        {
                            ')' => (3, new Stack<char>()),
                            ']' => (57, new Stack<char>()),
                            '}' => (1197, new Stack<char>()),
                            '>' => (25137, new Stack<char>()),
                            _ => throw new ArgumentOutOfRangeException()
                        };
                    }
                }
            }

            return (0, stack);
        }
    }
}
