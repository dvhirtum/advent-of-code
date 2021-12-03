using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode.Puzzles
{
    public class Day03
    {
        public int Solve1(string[] input)
        {
            var mostSignificantBits = input
                .Select(x => x.Select(c => (int)char.GetNumericValue(c)))
                .Aggregate((acc, next) => acc.Zip(next, (x, y) => x + (y == 0 ? -1 : 1)))
                .Select(x => x > 0 ? 1 : 0)
                .ToArray();
            
            var gammaRate = string.Join("", mostSignificantBits);
            var epsilonRate = string.Join("", mostSignificantBits.Select(x => x == 1 ? 0 : 1));
            
            return Convert.ToInt32(gammaRate, 2) * Convert.ToInt32(epsilonRate, 2);
        }

        public int Solve2(string[] input)
        {
            var oxygenGeneratorRating = OxygenGeneratorRating(input);
            var co2ScrubberRating = Co2ScrubberRating(input);

            return Convert.ToInt32(oxygenGeneratorRating, 2) * Convert.ToInt32(co2ScrubberRating, 2);
        }

        private string OxygenGeneratorRating(string[] input) 
            => DetermineRating((a, b) => a.Length >= b.Length ? a : b, input, 0);

        private string Co2ScrubberRating(string[] input) 
            => DetermineRating((a, b) => a.Length >= b.Length ? b : a, input, 0);

        private string DetermineRating(Func<string[], string[], string[]> selector, string[] input, int index)
        {
            if (input.Length == 1)
            {
                return input[0];
            }

            var bitIsSet = input.Where(x => x[index] == '1').ToArray();
            var bitIsNotSet = input.Where(x => x[index]=='0').ToArray();

            return DetermineRating(selector, selector(bitIsSet, bitIsNotSet), index + 1);
        }
    }
}
