using System.Text.RegularExpressions;

namespace Day04;

public class BingoCalculator
{
    public static int GetWinningScore(int[][] boards, int[] numbers)
    {
        int winner = -1;
        int position = 0;
        int currentNumber = 0;

        while(winner < 0)
        {
            currentNumber = numbers[position];
            
            for(var i = 0; i < boards.Length; i++)
            {
                var board = boards[i];
                boards[i] = board.Select(v => v == currentNumber ? -1 : v).ToArray();

                if(HasBoardWon(boards[i]))
                {
                    winner = i;
                    break;
                }
            }

            position++;
        }

        int finalScore = boards[winner].Where(v => v >= 0).Sum() * currentNumber;

        return finalScore;
    }

    public static int GetLastWinningScore(int[][] boards, int[] numbers)
    {
        int[]? finalWinner = null;
        int[]? previousWinner = null;
        int position = 0;
        int currentNumber = 0;

        List<(int[] Board, bool HasWon)> parsedBoards = boards.Select(b => (b, false)).ToList();

        while (finalWinner is null && position < numbers.Length)
        {
            currentNumber = numbers[position];

            for (var i = 0; i < parsedBoards.Count; i++)
            {
                if (parsedBoards[i].HasWon)
                    continue;

                var board = parsedBoards[i].Board;
                board = board.Select(v => v == currentNumber ? -1 : v).ToArray();

                var hasWon = HasBoardWon(board);
                if (hasWon && parsedBoards.Count(b => !b.HasWon) == 1)
                {
                    finalWinner = board;
                    break;
                }
                parsedBoards[i] = new (board, hasWon);

                if (hasWon)
                    previousWinner = board;

            }

            position++;
        }

        int finalScore = (finalWinner ?? previousWinner ?? Array.Empty<int>()).Where(v => v >= 0).Sum() * currentNumber;

        return finalScore;
    }

    public static int[][] ParseBoards(string[] input)
    {
        int[][] parsedBoards = new int[(input.Length + 1) / 6][];
        for(int i = 0; i < input.Length; i+=6)
        {
            parsedBoards[i / 6] = input
                .Skip(i)
                .Take(5)
                .SelectMany(r => Regex.Matches(r, @"\d+")
                    .Select(v => int.Parse(v.Value)).ToArray())
                .ToArray();
        }

        return parsedBoards;
    }

    public static int[] ParseNumbers(string input)
        => Regex.Matches(input, @"\d+").Select(m => int.Parse(m.Value)).ToArray();
    

    private static bool HasBoardWon(int[] board)
        => board.Chunk(5).Any(r => r.All(f => f == -1)) || board.Chunk(5).Transpose().Any(c => c.All(f => f == -1));
}
