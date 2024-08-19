using System.Text.RegularExpressions;

namespace Day02;

public partial class Game
{
    [GeneratedRegex(@"Game (\d+)|(\d+) (blue|red|green)|(;)+")]
    private static partial Regex POSSIBLE_LINE_PARSER();

    public static int IsPossible(string line, int maxRed, int maxGreen, int maxBlue)
    {
        var id = 0;
        var red = 0;
        var green = 0;
        var blue = 0;

        foreach (Match match in POSSIBLE_LINE_PARSER().Matches(line))
        {
            if (match.Groups[1].Success) // Is Game match
            {
                id = int.Parse(match.Groups[1].Value);
                continue;
            }

            if (match.Groups[4].Success) // Is end of a hand
            {
                if (red > maxRed || green > maxGreen || blue > maxBlue)
                {
                    return 0;
                }
                else
                {
                    red = 0;
                    green = 0;
                    blue = 0;
                }

                continue;
            }

            var amount = int.Parse(match.Groups[2].Value);

            switch (match.Groups[3].Value)
            {
                case "red": red += amount; break;
                case "green": green += amount; break;
                case "blue": blue += amount; break;
            }
        }

        if (red > maxRed || green > maxGreen || blue > maxBlue)
        {
            return 0;
        }

        return id;
    }

    [GeneratedRegex(@"(\d+) (blue|red|green)|(;)+")]
    private static partial Regex POWER_PARSER();

    public static int GetPower(string line)
    {
        var red = 0;
        var green = 0;
        var blue = 0;

        var currentRed = 0;
        var currentGreen = 0;
        var currentBlue = 0;

        foreach (Match match in POWER_PARSER().Matches(line))
        {
            if (match.Groups[3].Success) // Is end of a hand
            {
                if (currentRed > red)
                    red = currentRed;

                if (currentGreen > green)
                    green = currentGreen;

                if (currentBlue > blue)
                    blue = currentBlue;

                currentRed = 0;
                currentGreen = 0;
                currentBlue = 0;

                continue;
            }

            var amount = int.Parse(match.Groups[1].Value);

            switch (match.Groups[2].Value)
            {
                case "red": currentRed += amount; break;
                case "green": currentGreen += amount; break;
                case "blue": currentBlue += amount; break;
            }
        }

        if (currentRed > red)
            red = currentRed;

        if (currentGreen > green)
            green = currentGreen;

        if (currentBlue > blue)
            blue = currentBlue;

        return red * green * blue;
    }

    public static int TotalOfPossibleIDs(string[] lines, int red, int green, int blue)
    {
        return lines.Sum(l => Game.IsPossible(l, red, green, blue));
    }

    public static int GetPowerTotal(string[] lines)
    {
        return lines.Sum(Game.GetPower);
    }
}
