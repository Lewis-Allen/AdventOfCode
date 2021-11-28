using System.Text.RegularExpressions;

namespace Day14;

public static class ReindeerCalculator
{
    private static readonly Regex REINDEER_EXPRESSION = new Regex(@"(\w+) can fly (\d+) km/s for (\d+) seconds, but then must rest for (\d+) seconds\.", RegexOptions.Compiled);
    public static Reindeer ParseLine(string line)
    {
        var match = REINDEER_EXPRESSION.Match(line);

        string name = match.Groups[1].Value;
        int speed = int.Parse(match.Groups[2].Value);
        int stamina = int.Parse(match.Groups[3].Value);
        int restTime = int.Parse(match.Groups[4].Value);

        return new Reindeer(name, speed, stamina, restTime);
    }

    public static Reindeer[] PerformRace(Reindeer[] reindeers, int seconds)
    {
        for(int i = 0; i < seconds; i++)
        {
            foreach(var reindeer in reindeers)
            {
                reindeer.Travel(1);
            }

            var leadersPoints = reindeers.Select(r => r.DistanceTravelled).Max();

            var leaders = reindeers.Where(r => r.DistanceTravelled == leadersPoints).ToList();

            foreach(var leader in leaders)
            {
                leader.Points++;
            }
        }

        return reindeers;
    }
}