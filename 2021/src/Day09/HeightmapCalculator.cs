namespace Day09;

public class HeightmapCalculator
{
    public static int FindSumOfRisk(int[] heights, int lineLength) => heights
        .Where((h,i) => IsLowPoint(i, heights, lineLength))
        .Sum(r => r + 1);

    public static int FindSumOfLargestBasins(int[] heights, int lineLength) => heights
        .Select((h, i) => i)
        .Where(o => IsLowPoint(o, heights, lineLength))
        .Select(l => GetBasinSize(l, heights, lineLength))
        .OrderByDescending(b => b)
        .Take(3)
        .Aggregate(1, (acc, val) => acc * val);

    private static bool IsLowPoint(int i, int[] heights, int lineLength)
    {
        var valid = true;
        var h = heights[i];
        var x = i % lineLength;

        if (i >= lineLength)
            valid &= heights[i - lineLength] > h;

        if (i < heights.Length - lineLength)
            valid &= heights[i + lineLength] > h;

        if (x < lineLength - 1 && i < heights.Length - 1)
            valid &= heights[i + 1] > h;

        if (x > 0 && i > 0)
            valid &= heights[i - 1] > h;

        return valid;
    }

    private static int GetBasinSize(int i, int[] heights, int lineLength) =>
        GetBasinSizeRecur(i, heights, lineLength, new bool[heights.Length]);

    public static int GetBasinSizeRecur(int i, int[] heights, int lineLength, bool[] visited)
    {
        visited[i] = true;
        var h = heights[i];
        
        if (h == 9)
            return 0;

        var x = i % lineLength;
        var size = 1;

        if (i >= lineLength && !visited[i - lineLength] && heights[i - lineLength] > h)
            size += GetBasinSizeRecur(i - lineLength, heights, lineLength, visited);

        if (i < heights.Length - lineLength && !visited[i + lineLength] && heights[i + lineLength] > h)
            size += GetBasinSizeRecur(i + lineLength, heights, lineLength, visited);

        if (x < lineLength - 1 && i < heights.Length - 1 && !visited[i + 1] && heights[i + 1] > h)
            size += GetBasinSizeRecur(i + 1, heights, lineLength, visited);

        if (x > 0 && i > 0 && !visited[i - 1] && heights[i - 1] > h)
            size += GetBasinSizeRecur(i - 1, heights, lineLength, visited);

        return size;
    }
}
