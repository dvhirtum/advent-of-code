using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles
{
    public class Day06
    {
        public long Solve1(int[] input) => NumberOfFish(input, 80);

        public long Solve2(int[] input) => NumberOfFish(input, 256);

        private long NumberOfFish(int[] input, int numberOfDays)
        {
            var memoize = new Dictionary<int, long>();
            return input.Length + input.Select(x => NumberOfOffspring(numberOfDays, x + 1)).Sum();
            
            long NumberOfOffspring(int n, int t)
            {
                if (t > n)
                {
                    return 0;
                }

                if (memoize.TryGetValue(t, out var result))
                {
                    return result;
                }

                var newT = t;
                while (newT <= n)
                {
                    result += 1 + NumberOfOffspring(n, newT + 9);
                    newT += 7;
                }

                memoize.Add(t, result);
                
                return result;
            }
        }
    }
}
