using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day05
    {
        private readonly Regex _regex = new(@"(?<x1>\d+),(?<y1>\d+) -> (?<x2>\d+),(?<y2>\d+)");
        
        public int Solve1(string[] input)
        {
            var points = new List<Point>();
            
            foreach (var line in input)
            {
                var match = _regex.Match(line);
                var a = new Point(int.Parse(match.Groups["x1"].Value), int.Parse(match.Groups["y1"].Value));
                var b = new Point(int.Parse(match.Groups["x2"].Value), int.Parse(match.Groups["y2"].Value));
                
                points.AddRange(a.PointsBetween(b));
            }
            
            return points.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .Distinct()
                .Count();
        }
        
        public int Solve2(string[] input)
        {
            var points = new List<Point>();
            
            foreach (var line in input)
            {
                var match = _regex.Match(line);
                var a = new Point(int.Parse(match.Groups["x1"].Value), int.Parse(match.Groups["y1"].Value));
                var b = new Point(int.Parse(match.Groups["x2"].Value), int.Parse(match.Groups["y2"].Value));
                
                points.AddRange(a.PointsBetweenIncludeDiagonal(b));
            }
            
            return points.GroupBy(x => x)
                .Where(x => x.Count() > 1)
                .Select(x => x.Key)
                .Distinct()
                .Count();
        }
    }

    public record Point(int X, int Y)
    {
        public IEnumerable<Point> PointsBetween(Point point)
        {
            if (X == point.X)
            {
                var minY = Math.Min(Y, point.Y);
                var maxY = Math.Max(Y, point.Y);
                for (int i = minY; i <= maxY; i++)
                {
                    yield return new Point(X, i);
                }
            }
            else if (Y == point.Y)
            {
                var minX = Math.Min(X, point.X);
                var maxX = Math.Max(X, point.X);
                for (int i = minX; i <= maxX; i++)
                {
                    yield return new Point(i, Y);
                }
            }
        }
        
        public IEnumerable<Point> PointsBetweenIncludeDiagonal(Point point)
        {
            if (X == point.X)
            {
                var minY = Math.Min(Y, point.Y);
                var maxY = Math.Max(Y, point.Y);
                for (int i = minY; i <= maxY; i++)
                {
                    yield return new Point(X, i);
                }
            }
            else if (Y == point.Y)
            {
                var minX = Math.Min(X, point.X);
                var maxX = Math.Max(X, point.X);
                for (int i = minX; i <= maxX; i++)
                {
                    yield return new Point(i, Y);
                }
            }
            else
            {
                var minX = Math.Min(X, point.X);
                var maxX = Math.Max(X, point.X);
                var maxY = Math.Max(Y, point.Y);
                var leftPoint = X > point.X ? point : this;
                var dirY = leftPoint.Y == maxY ? -1 : 1;
                for (int i = 0; i <= (maxX - minX); i++)
                {
                    yield return new Point(leftPoint.X + i, leftPoint.Y + (dirY * i));
                }
            }
        }
    }
}
