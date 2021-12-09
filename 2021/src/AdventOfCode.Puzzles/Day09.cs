using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day09
    {
        public int Solve1(string[] input)
        {
            var numbers = GetNumbers(input);
            var lowPoints = GetLowPoints(numbers);
            return lowPoints.Sum(x => x.Value + 1);
        }

        public int Solve2(string[] input)
        {
            var numbers = GetNumbers(input);
            var basins = GetBasins(numbers);
            return basins.OrderByDescending(x => x).Take(3).Aggregate((total, next) => total * next);
        }

        private List<Number> GetNumbers(string[] input)
            => input.SelectMany((n, y) => n.Select((c, x) => new Number(x, y, (int)char.GetNumericValue(c)))).ToList();

        private List<Number> GetLowPoints(List<Number> numbers) 
            => numbers.Where(n =>
            {
                var adjacent = numbers.Where(IsAdjacent(n));
                return !adjacent.Any(x => n.Value >= x.Value);
            }).ToList();

        private List<int> GetBasins(List<Number> numbers)
        {
            var basinNumbers = numbers.Where(x => x.Value != 9).ToList();

            var basins = new List<List<Number>>();
            while (basinNumbers.Any())
            {
                var basin = new List<Number>();

                var first = basinNumbers.First();
                basin.AddRange(GetBasinNumbers(first, basinNumbers.Where(x => x != first).ToList(), new List<Number>{first}));
                
                basins.Add(basin);
                foreach (var number in basin)
                {
                    basinNumbers.Remove(number);
                }
            }

            return basins.Select(x => x.Count).ToList();
        }

        private List<Number> GetBasinNumbers(Number current, List<Number> basinNumbers, List<Number> accumulator)
        {
            var adjacent = basinNumbers.Where(x => !accumulator.Contains(x) && IsAdjacent(current)(x)).ToList();

            if (!adjacent.Any())
            {
                return accumulator;
            }
            
            accumulator.AddRange(adjacent);

            foreach (var number in adjacent)
            {
                accumulator = GetBasinNumbers(number, basinNumbers, accumulator);
            }

            return accumulator;
        }
        
        private Func<Number, bool> IsAdjacent(Number number) =>
            n =>
                (n.X == number.X && (n.Y == number.Y - 1 || n.Y == number.Y + 1)) ||
                (n.Y == number.Y && (n.X == number.X - 1 || n.X == number.X + 1));
    }

    public record Number(int X, int Y, int Value);
}
