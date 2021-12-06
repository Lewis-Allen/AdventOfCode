using System.Text.RegularExpressions;

namespace Day16;

public record Sue(int Id, Dictionary<string,int> Items)
{
    private static readonly Regex SUE_EXPRESSION = new Regex(@"Sue (\d+): (\w+): (\d+), (\w+): (\d+), (\w+): (\d+)", RegexOptions.Compiled);
    public static Sue FromString(string line)
    {
        var match = SUE_EXPRESSION.Match(line);

        if (!match.Success)
            throw new ArgumentException("Line was not a valid sue", nameof(line));

        int id = int.Parse(match.Groups[1].Value);

        Dictionary<string, int> items = new();

        items.Add(match.Groups[2].Value, int.Parse(match.Groups[3].Value));
        items.Add(match.Groups[4].Value, int.Parse(match.Groups[5].Value));
        items.Add(match.Groups[6].Value, int.Parse(match.Groups[7].Value));

        return new Sue(id, items);
    }
}
