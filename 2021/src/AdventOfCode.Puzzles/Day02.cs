using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day02
    {
        private readonly Regex _regex = new Regex(@"(?<direction>(forward|up|down)) (?<value>\d+)");

        public int Solve1(string[] input)
        {
            var (position, depth) = input
                .Where(x => _regex.IsMatch(x))
                .Select(x => Command.Create(_regex.Match(x)))
                .Select(x => x switch
                {
                    {Direction: "forward"} => (position: x.Value, depth: 0),
                    {Direction: "down"} => (position: 0, depth: x.Value),
                    {Direction: "up"} => (position: 0, depth: -x.Value),
                    _ => throw new InvalidOperationException()
                })
                .Aggregate((acc, next) => (position: acc.position + next.position, depth: acc.depth + next.depth));

            return position * depth;
        }

        public int Solve2(string[] input)
        {
            var (position, depth, _) = input
                .Where(x => _regex.IsMatch(x))
                .Select(x => Command.Create(_regex.Match(x)))
                .Select(x => x switch
                {
                    {Direction: "forward"} => (position: x.Value, depth: 0, aim: 0),
                    {Direction: "down"} => (position: 0, depth: 0, aim: x.Value),
                    {Direction: "up"} => (position: 0, depth: 0, aim: -x.Value),
                    _ => throw new InvalidOperationException()
                })
                .Aggregate((acc, next) =>
                    (position: acc.position + next.position,
                        depth: acc.depth + (acc.aim * next.position),
                        aim: acc.aim + next.aim));

            return position * depth;
        }
    }

    public record Command(string Direction, int Value)
    {
        public static Command Create(Match match) => new(match.Groups["direction"].Value, int.Parse(match.Groups["value"].Value));
    }
}
