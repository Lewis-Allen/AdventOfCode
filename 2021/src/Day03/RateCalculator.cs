using System.Linq;

namespace Day03;

public class RateCalculator
{
    public static int GetPowerConsumption(string[] binary)
    {
        int gamma = 0;
        int epsilon = 0;

        for(int i = 0; i < binary[0].Length; i++)
        {
            var mostCommon = GetMostCommonBit(binary, i);

            gamma = (gamma << 1) + (mostCommon == '0' ? 0 : 1);
            epsilon = (epsilon << 1) + (mostCommon == '0' ? 1 : 0);
        }

        return gamma * epsilon;
    }

    public static int GetLifeSupportRating(string[] binary)
    {
        var co2Array = new string[binary.Length];
        binary.CopyTo(co2Array, 0);

        int oxygenRating = FindRating(binary, true);
        int CO2Rating = FindRating(co2Array, false);

        return oxygenRating * CO2Rating;
    }

    private static int FindRating(string[] binary, bool keepMatches)
    {
        int position = 0;
        while (binary.Length > 1)
        {
            var mostCommon = GetMostCommonBit(binary, position);

            binary = binary
                .Where(b => keepMatches == (b[position] == mostCommon))
                .ToArray();

            position++;
        }

        return Convert.ToInt32(binary[0], 2);
    }

    private static char GetMostCommonBit(string[] binary, int position) 
        => binary.Select(b => b[position])
            .GroupBy(b => b)
            .OrderByDescending(b => b.Count())
            .ThenByDescending(b => b.Key == '1')
            .Select(b => b.Key)
            .FirstOrDefault();
}
