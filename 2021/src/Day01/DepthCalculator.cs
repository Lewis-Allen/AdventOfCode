namespace Day01;

public class DepthCalculator
{
    // Part One
    public static int GetDepthIncreasesCount(int[] depths)
    {
        var count = 0;
        for (var i = 0; i < depths.Length - 1; i++)
        {
            if (depths[i + 1] > depths[i])
                count++;
        }

        return count;
    }

    // Part Two
    public static int GetDepthIncreasesCountWithMeasuringWindow(int[] depths)
    {
        var count = 0;
        for (var i = 0; i < depths.Length - 3; i++)
        {
            int firstWindow = depths[i] + depths[i + 1] + depths[i + 2];
            int secondWindow = depths[i + 1] + depths[i + 2] + depths[i + 3];
            if (secondWindow > firstWindow)
                count++;
        }

        return count;
    }
}
