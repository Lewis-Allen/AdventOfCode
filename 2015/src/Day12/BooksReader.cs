using System.Text.Json;
using System.Text.RegularExpressions;

namespace Day12;

public static class BooksReader
{
    public static int SumOfAllNumbers(string json)
    {
        var matches = Regex.Matches(json, @"-*\d+");

        var total = matches.Sum(m => int.Parse(m.Value));

        return total;
    }

    public static int SumExcludingRed(string json)
    {
        var books = JsonDocument.Parse(json);
        var rootElement = books.RootElement;

        var acc = 0;
        var total = EnumerateElementIgnoringRed(acc, rootElement);

        return total;
    }

    private static int EnumerateElementIgnoringRed(int acc, JsonElement element)
    {
        switch (element.ValueKind)
        {
            case JsonValueKind.Array:

                foreach (var child in element.EnumerateArray())
                {
                    acc = EnumerateElementIgnoringRed(acc, child);
                }
                break;

            case JsonValueKind.Object:

                bool containsRed = false;
                foreach (var child in element.EnumerateObject())
                {
                    if (child.Value.ValueKind == JsonValueKind.String && (child.Value.GetString() ?? "") == "red")
                        containsRed = true;
                }

                if (!containsRed)
                {
                    foreach (var child in element.EnumerateObject())
                    {
                        acc = EnumerateElementIgnoringRed(acc, child.Value);
                    }
                }
                break;

            case JsonValueKind.String:
                break;

            case JsonValueKind.Number:
                int number = element.GetInt32();
                acc += number;
                break;
        }

        return acc;
    }
}
