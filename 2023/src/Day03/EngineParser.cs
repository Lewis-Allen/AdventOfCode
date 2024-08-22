using System.Text;

namespace Day03;

public class EngineParser
{
    private static (int y, int x)[] OFFSETS =
                        [
                            (-1, -1),
                            (-1, 0),
                            (-1, 1),
                            (0, -1),
                            (0, 0),
                            (0, 1),
                            (1, -1),
                            (1, 0),
                            (1, 1)
                        ];

    public static List<int> GetPartNumbers(char[][] lines)
    {
        List<int> partNumbers = [];
        var currentNumber = new StringBuilder();

        for (var y = 0; y < lines.Length; y++)
        {
            currentNumber.Clear();
            bool adjacent = false;
            for (var x = 0; x < lines[y].Length; x++)
            {
                if (char.IsDigit(lines[y][x]))
                {
                    currentNumber.Append(lines[y][x]);

                    if (!adjacent)
                    {
                        // Search for symbols adjacent to number
                        foreach (var offset in OFFSETS)
                        {
                            var yPos = offset.y + y;
                            var xPos = offset.x + x;

                            if (yPos >= 0 && yPos <= lines.Length - 1 &&
                                xPos >= 0 && xPos <= lines[y].Length - 1)
                            {
                                var lookup = lines[yPos][xPos];
                                if (!char.IsDigit(lookup) && lookup != '.')
                                {
                                    adjacent = true;
                                    break;
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (adjacent)
                    {
                        partNumbers.Add(int.Parse(currentNumber.ToString()));
                    }

                    adjacent = false;
                    currentNumber.Clear();
                }
            }

            // Line break is also end of a number potentially
            if (adjacent)
            {
                partNumbers.Add(int.Parse(currentNumber.ToString()));
            }

            adjacent = false;
            currentNumber.Clear();
        }

        return partNumbers;
    }

    public static int GetSumOfPartNumbers(char[][] lines) => GetPartNumbers(lines).Sum();

    public static List<int> GetGearRatios(char[][] lines)
    {
        List<int> partNumbers = [];
        var currentNumber = new StringBuilder();

        Dictionary<(int y, int x), List<int>> adjacents = []; // Dictionary of symbols, and their adjacent numbers

        for (var y = 0; y < lines.Length; y++)
        {
            HashSet<(int, int)> symbolsAdjacent = []; // Symbols adjacent to the current number

            for (var x = 0; x < lines[y].Length; x++)
            {
                if (char.IsDigit(lines[y][x]))
                {
                    currentNumber.Append(lines[y][x]);

                    // Search for symbols adjacent to number
                    foreach (var offset in OFFSETS)
                    {
                        var yPos = offset.y + y;
                        var xPos = offset.x + x;

                        if (yPos >= 0 && yPos <= lines.Length - 1 &&
                            xPos >= 0 && xPos <= lines[y].Length - 1)
                        {
                            var lookup = lines[yPos][xPos];
                            if (lookup == '*')
                            {
                                if (!symbolsAdjacent.Contains((yPos, xPos)))
                                {
                                    symbolsAdjacent.Add((yPos, xPos));
                                }
                            }
                        }
                    }
                }
                else
                {
                    EndOfGearNumber(currentNumber, adjacents, symbolsAdjacent);

                    symbolsAdjacent = [];
                    currentNumber.Clear();
                }
            }

            // Line break is also end of a number potentially
            EndOfGearNumber(currentNumber, adjacents, symbolsAdjacent);

            symbolsAdjacent = [];
            currentNumber.Clear();
        }

        return adjacents
            .Where(a => a.Value.Count == 2)
            .Select(a => a.Value[0] * a.Value[1])
            .ToList();
    }

    private static void EndOfGearNumber(StringBuilder currentNumber, Dictionary<(int y, int x), List<int>> adjacents, HashSet<(int, int)> symbolsAdjacent)
    {
        foreach (var pos in symbolsAdjacent)
        {
            if (!adjacents.TryGetValue(pos, out List<int>? value))
            {
                adjacents.Add(pos, [int.Parse(currentNumber.ToString())]);
            }
            else
            {
                value.Add(int.Parse(currentNumber.ToString()));
            }
        }
    }

    public static int GetSumOfGearRatios(char[][] lines) => GetGearRatios(lines).Sum();
}
