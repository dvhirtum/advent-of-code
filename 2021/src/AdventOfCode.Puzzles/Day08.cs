using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day08
    {
        public int Solve1(string[] input)
            => GetEntries(input).Sum(x => x.output.Count(n => n.Length is 2 or 3 or 4 or 7));

        public int Solve2(string[] input) 
            => GetEntries(input)
                .Select(x =>
                {
                    var patternValues = MatchPatternsToValues(x);
                    return (int)x.output
                        .Select((o, i) => patternValues.Single(p => p.pattern == o).value * Math.Pow(10, 3 - i))
                        .Sum();
                }).Sum();

        private List<(string pattern, int value)> MatchPatternsToValues((string[] patterns, string[] output) entry)
        {
            var patternValues = new List<(string pattern, int value)>
            {
                (entry.patterns.Single(p => p.Length == 2), 1),
                (entry.patterns.Single(p => p.Length == 4), 4),
                (entry.patterns.Single(p => p.Length == 3), 7),
                (entry.patterns.Single(p => p.Length == 7), 8)
            };

            var nine = entry.patterns
                .Single(p =>
                    p.Length == 6
                    && Regex.Matches(p, $"[{entry.patterns.Single(p1 => p1.Length == 4)}]").Count == 4);
            patternValues.Add((nine, 9));

            var zero = entry.patterns
                .Single(p =>
                    p.Length == 6
                    && p != nine
                    && Regex.Matches(p, $"[{entry.patterns.Single(p1 => p1.Length == 2)}]").Count == 2);
            patternValues.Add((zero, 0));

            var six = entry.patterns
                .Single(p =>
                    p.Length == 6
                    && p != nine
                    && p != zero);
            patternValues.Add((six, 6));

            var three = entry.patterns
                .Single(p =>
                    p.Length == 5
                    && Regex.Matches(p, $"[{entry.patterns.Single(p1 => p1.Length == 2)}]").Count == 2);
            patternValues.Add((three, 3));

            var five = entry.patterns
                .Single(p =>
                    p.Length == 5
                    && Regex.Matches(p, $"[{six}]").Count == 5);
            patternValues.Add((five, 5));

            var two = entry.patterns
                .Single(p =>
                    p.Length == 5
                    && p != three
                    && p != five);
            patternValues.Add((two, 2));

            return patternValues;
        }

        private IEnumerable<(string[] patterns, string[] output)> GetEntries(string[] input)
            => input.Select(x =>
            {
                var split = x.Split(" | ");
                return (
                    patterns: split[0].Split(" ").Select(s => string.Concat(s.OrderBy(c => c))).ToArray(),
                    output: split[1].Split(" ").Select(s => string.Concat(s.OrderBy(c => c))).ToArray()
                );
            });
    }
}
