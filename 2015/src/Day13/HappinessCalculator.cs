using System.Text.RegularExpressions;

namespace Day13;

public static class HappinessCalculator
{
    private static readonly Regex HAPPINESS_LINE_EXPRESSION = new(@"(\w+) would (\w+) (\d+) happiness units by sitting next to (\w+)\.", RegexOptions.Compiled);

    public static ((string person, string nextTo) seating, int happiness) ParseLine(string line)
    {
        var match = HAPPINESS_LINE_EXPRESSION.Match(line);
        if (!match.Success)
            throw new ArgumentException("Line is not in a valid format.", nameof(line));

        string person = match.Groups[1].Value;
        bool isLoss = match.Groups[2].Value == "lose";
        int happiness = int.Parse(match.Groups[3].Value);
        string nextTo = match.Groups[4].Value;

        return ((person, nextTo), isLoss ? -happiness : happiness);
    }

    public static int FindHappinessFromOptimalSeating(Dictionary<(string person, string nextTo), int> seatingArrangements)
    {
        var permutations = seatingArrangements.Keys.Select(p => p.person).Distinct().Permutate().ToList();
        int max = 0;

        foreach (var names in permutations)
        {
            var totalHappiness = 0;
            for (int i = 0; i < names.Length; i++)
            {
                if (i == names.Length - 1)
                {
                    totalHappiness += seatingArrangements[(names[i], names[0])];
                    totalHappiness += seatingArrangements[(names[0], names[i])];

                }
                else
                {
                    totalHappiness += seatingArrangements[(names[i], names[i + 1])];
                    totalHappiness += seatingArrangements[(names[i + 1], names[i])];
                }
            }

            if (totalHappiness > max)
                max = totalHappiness;
        }

        return max;
    }

    public static IEnumerable<T[]> Permutate<T>(this IEnumerable<T> source)
    {
        return permutate(source, Enumerable.Empty<T>());
        IEnumerable<T[]> permutate(IEnumerable<T> reminder, IEnumerable<T> prefix) =>
            !reminder.Any() ? new[] { prefix.ToArray() } :
            reminder.SelectMany((c, i) => permutate(
                reminder.Take(i).Concat(reminder.Skip(i + 1)).ToArray(),
                prefix.Append(c)));
    }
}
