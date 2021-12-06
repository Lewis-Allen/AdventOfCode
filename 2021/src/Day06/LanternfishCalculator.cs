namespace Day06;

public class LanternfishCalculator
{
    public static long GetFishCountAfterXDays(int[] initialState, int days)
    {
        // Initial setup
        long[] birthCycles = new long[9];
        
        foreach (var cycle in initialState)
            birthCycles[cycle]++;

        // Begin simulating days
        for(int i = 0; i < days; i++)
        {
            long births = birthCycles[0];

            for(int j = 0; j < 8; j++)
            {
                birthCycles[j] = birthCycles[j + 1];
            }

            birthCycles[6] += births;
            birthCycles[8] = births;
        }

        return birthCycles.Sum();
    }
}
