using System;
using System.Linq;

namespace AdventOfCode.Puzzles
{
    public class Day07
    {
        public int Solve1(int[] input) 
            => Enumerable
                .Range(input.Min(), input.Max() - input.Min())
                .Min(i => input.Sum(x => Math.Abs(x - i)));

        public int Solve2(int[] input) 
            => Enumerable
                .Range(input.Min(), input.Max() - input.Min())
                .Min(i => input.Sum(x =>
                {
                    var n = Math.Abs(x - i);
                    return n * (n + 1) / 2;
                }));
    }
}
