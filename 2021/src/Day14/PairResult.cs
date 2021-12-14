namespace Day14;

public record PairResult(Dictionary<string, long> PairCounts, Dictionary<char, long> KeyCounts)
{
    public static PairResult FromString(string polymer)
    {
        var pairCounts = new Dictionary<string, long>();
        var keyCounts = new Dictionary<char, long>()
        {
            { polymer[0], 1 }
        };

        for (int i = 1; i < polymer.Length; i++)
        {
            var a = polymer[i - 1];
            var b = polymer[i];

            pairCounts[a.ToString() + b.ToString()] = pairCounts.GetValueOrDefault(a.ToString() + b.ToString()) + 1;
            keyCounts[b] = keyCounts.GetValueOrDefault(b) + 1;
        }

        return new PairResult(pairCounts, keyCounts);
    }
}
