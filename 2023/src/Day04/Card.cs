using System.Text.RegularExpressions;

namespace Day04;

public partial class Card
{
    public int ID { get; set; }
    public int[] Winners { get; set; } = [];
    public int[] Entries { get; set; } = [];

    [GeneratedRegex(@"Card +(\d+): *((\d+ +)+)\| *((\d+ *)+)")]
    private static partial Regex CARD_PARSER();

    public static Card FromString(string cardString)
    {
        var match = CARD_PARSER().Match(cardString);

        if (!match.Success)
            throw new ArgumentException("Not a valid card string", nameof(cardString));

        return new Card
        {
            ID = int.Parse(match.Groups[1].Value),
            Winners = GetEntries(match.Groups[2].Value),
            Entries = GetEntries(match.Groups[4].Value)
        };
    }

    public int GetCardScore()
    {
        var matches = GetMatches()
            .Count();

        if (matches > 0)
        {
            return (int)Math.Pow(2, matches - 1);
        }
        else
        {
            return 0;
        }
    }

    public IEnumerable<int> GetMatches() => Winners
            .Intersect(Entries);

    private static int[] GetEntries(string entriesString) => entriesString
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

    public static int GetTotalScratchCards(Card[] cards)
    {
        var matchCache = new Dictionary<int, int>();

        // Start from the back
        for (var i = cards.Length - 1; i >= 0; i--)
        {
            var card = cards[i];

            var matches = card
                .GetMatches()
                .Count();

            var scratchcards = 1;
            for (var j = 1; j <= matches; j++)
            {
                if (i + j < cards.Length)
                {
                    scratchcards += matchCache[i + j];
                }
            }

            matchCache[i] = scratchcards;
        }

        return matchCache.Values.Sum();
    }
}
