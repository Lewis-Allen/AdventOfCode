using System.Text.RegularExpressions;

namespace Day16;

public class SueFinder
{
    private static readonly Regex ITEM_EXPRESSION = new Regex(@"(\w+): (\d+)", RegexOptions.Compiled);
    public static Sue FindSue(string[] ticket, List<Sue> sues)
    {
        (string Item, int Amount)[] items = FormatItems(ticket);

        return sues
            .Where(s => items.All(i => !s.Items.ContainsKey(i.Item) || (s.Items[i.Item] == i.Amount)))
            .First();
    }

    public static Sue FindSueWithRanges(string[] ticket, List<Sue> sues)
    {
        (string Item, int Amount)[] items = FormatItems(ticket);

        return sues
            .Where(s => items.All(i => IsValidForSue(i, s)))
            .First();
    }

    private static (string Item, int Amount)[] FormatItems(string[] items)
        => items.Select(i => ITEM_EXPRESSION.Match(i))
            .Select(m => (m.Groups[1].Value, int.Parse(m.Groups[2].Value)))
            .ToArray();

    private static bool IsValidForSue((string Item, int Amount) item, Sue sue) 
        => !sue.Items.ContainsKey(item.Item) || 
            ((item.Item == "cats" || item.Item == "trees") && sue.Items[item.Item] > item.Amount) || 
            ((item.Item == "pomeranians" || item.Item == "goldfish") && sue.Items[item.Item] < item.Amount) || 
            (!(item.Item == "cats" || item.Item == "trees" || item.Item == "pomeranians" || item.Item == "goldfish") && sue.Items[item.Item] == item.Amount);
    
}
