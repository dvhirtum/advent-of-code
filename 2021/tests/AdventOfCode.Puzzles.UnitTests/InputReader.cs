using System.Collections.Generic;
using System.IO;

namespace AdventOfCode.Puzzles.UnitTests
{
    public class InputReader
    {
        public static IEnumerable<string> ReadInput(string day)
        {
            using var reader = File.OpenText($"{day}_input.txt");
            var line = reader.ReadLine();
            while (line is not null)
            {
                yield return line;
                line = reader.ReadLine();
            }
        }
    }
}
