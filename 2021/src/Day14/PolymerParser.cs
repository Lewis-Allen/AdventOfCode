using System.Text;
using System.Text.RegularExpressions;

namespace Day14;

public class PolymerParser
{
    private static readonly Regex POLYMER_EXPRESSION = new(@"(\w{2}) -> (\w{1})");

    public static Dictionary<string, char> ParseLines(string[] lines) => lines
            .Select(l =>
            {
                var match = POLYMER_EXPRESSION.Match(l);

                return (Key: match.Groups[1].Value, match.Groups[2].Value);
            })
            .ToDictionary(k => k.Key,
                          v => v.Value[0]);

    public static PairResult Step(PairResult polymer, Dictionary<string, char> lookup)
    {
        var pairCount = new Dictionary<string, long>();
        var keyCount = polymer.KeyCounts;

        foreach (var pair in polymer.PairCounts)
        {
            long count = pair.Value;

            var p = lookup[pair.Key];

            keyCount[p] = keyCount.GetValueOrDefault(p) + count;

            pairCount[pair.Key[0].ToString() + p.ToString()] = pairCount.GetValueOrDefault(pair.Key[0].ToString() + p.ToString()) + count;
            pairCount[p.ToString() + pair.Key[1].ToString()] = pairCount.GetValueOrDefault(p.ToString() + pair.Key[1].ToString()) + count;
        }

        return new PairResult(pairCount, keyCount);
    }
}
