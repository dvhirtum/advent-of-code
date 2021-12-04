using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode.Puzzles
{
    public class Day04
    {
        public int Solve1(string[] input)
        {
            var numbers = input.First().Split(",").Select(int.Parse);

            var boards = CreateBingoBoards(input);

            return PlayBingo(numbers, boards);
        }
        
        public int Solve2(string[] input)
        {
            var numbers = input.First().Split(",").Select(int.Parse);

            var boards = CreateBingoBoards(input);

            return PlayBingoToLose(numbers, boards);
        }

        private List<BingoBoard> CreateBingoBoards(string[] input)
        {
            var boards = new List<BingoBoard>();
            input = input.Skip(1).ToArray();
            while (input.Any())
            {
                input = input.Skip(1).ToArray();
                boards.Add(new BingoBoard(input.Take(5).ToArray()));
                input = input.Skip(5).ToArray();
            }

            return boards;
        }

        private int PlayBingo(IEnumerable<int> numbers, List<BingoBoard> boards)
        {
            foreach (var number in numbers)
            {
                foreach (BingoBoard board in boards)
                {
                    board.MarkNumber(number);
                    if (board.HasBingo())
                    {
                        return board.CalculateScore();
                    }
                }
            }

            return -1;
        }

        private int PlayBingoToLose(IEnumerable<int> numbers, List<BingoBoard> boards)
        {
            var completedBoards = new List<BingoBoard>();
            foreach (var number in numbers)
            {
                foreach (BingoBoard board in boards.Where(x => !x.HasBingo()))
                {
                    board.MarkNumber(number);
                    if (board.HasBingo())
                    {
                        completedBoards.Add(board);
                        if (completedBoards.Count == boards.Count)
                        {
                            return board.CalculateScore();
                        }
                    }
                }
            }

            return -1;
        }
    }

    public class BingoNumber
    {
        public BingoNumber(int row, int column, int value)
        {
            Row = row;
            Column = column;
            Value = value;
        }

        public int Row { get; }
        public int Column { get; }
        public int Value { get; }
        public bool IsMarked { get; set; }
    }

    public class BingoBoard
    {
        private readonly BingoNumber[] _board;
        private int _lastNumber;

        public BingoBoard(string[] input)
        {
            var numbers = new List<BingoNumber>();
            
            for (int row = 0; row < input.Length; row++)
            {
                var split = Regex.Split(input[row].TrimStart(), @"\s+");
                var rowNumbers = split.Select((value, column) => new BingoNumber(row, column, int.Parse(value))).ToList();

                numbers.AddRange(rowNumbers);
            }

            _board = numbers.ToArray();
        }
        
        public void MarkNumber(int number)
        {
            _lastNumber = number;
            foreach (var bingoNumber in _board)
            {
                if (bingoNumber.Value == number)
                {
                    bingoNumber.IsMarked = true;
                }
            }
        }

        public bool HasBingo()
        {
            for (int i = 0; i < 5; i++)
            {
                var row = _board.Where(x => x.Row == i && !x.IsMarked);
                if (!row.Any())
                {
                    return true;
                }

                var column = _board.Where(x => x.Column == i & !x.IsMarked);
                if (!column.Any())
                {
                    return true;
                }
            }

            return false;
        }

        public int CalculateScore() 
            => _lastNumber * _board.Where(x => !x.IsMarked).Sum(x => x.Value);
    }
}
