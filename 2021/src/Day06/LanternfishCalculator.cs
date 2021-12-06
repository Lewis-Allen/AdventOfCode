using System.Text.RegularExpressions;

namespace Day06;

public class LanternfishCalculator
{
    public static long GetFishCountAfterXDays(int[] initialState, int days)
    {
        long[] birthCycles = new long[9];

        foreach (var cycle in initialState)
            birthCycles[cycle]++;

        for(int i = 0; i < days; i++)
        {
            long temp = birthCycles[0];

            for(int j = 0; j < 8; j++)
            {
                birthCycles[j] = birthCycles[j + 1];
            }

            birthCycles[6] += temp;
            birthCycles[8] = temp;
        }

        return birthCycles.Sum();
    }
}
