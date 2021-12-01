using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles
{
    public class Day01
    {
        public int Solve1(int[] input) =>
            input
                .Skip(1)
                .Zip(input, (current, previous) => current > previous ? 1 : 0)
                .Sum();

        public int Solve2(int[] input)
        {
            var sliding = input
                .Skip(2)
                .Zip(input.Skip(1), (third, second) => second + third)
                .Zip(input, (sum, first) => first + sum)
                .ToArray();

            return Solve1(sliding);
        }
    }
}
