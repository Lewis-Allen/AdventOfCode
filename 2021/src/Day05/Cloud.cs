using System.Text.RegularExpressions;

namespace Day05;

public record Cloud(int X1, int Y1, int X2, int Y2)
{
    private static readonly Regex CLOUD_EXPRESSION = new(@"(\d+),(\d+) -> (\d+),(\d+)", RegexOptions.Compiled);

    public static Cloud FromString(string line)
    {
        var match = CLOUD_EXPRESSION.Match(line);

        if (!match.Success)
            throw new ArgumentException("String was not a valid line", nameof(line));
            
        int x1 = int.Parse(match.Groups[1].Value);
        int y1 = int.Parse(match.Groups[2].Value);
        int x2 = int.Parse(match.Groups[3].Value);
        int y2 = int.Parse(match.Groups[4].Value);

        return new Cloud(x1, y1, x2, y2);
    }

    public IEnumerable<(int x, int y)> Points()
    {
        if(X1 == X2)
        {
            // vertical lines
            return Enumerable.Range(Math.Min(Y1, Y2), Math.Max(Y1, Y2) - Math.Min(Y1, Y2) + 1)
                .Select(y => (X1, y));
        }
        else
        {
            // y = mx + c
            var m = (Y2 - Y1) / (X2 - X1);
            var c = Y1 - (m * X1);

            return Enumerable.Range(Math.Min(X1, X2), Math.Max(X1, X2) - Math.Min(X1, X2) + 1)
                .Select(x => (x, (m * x) + c));
        }
    }
}