namespace Day05;

public class CloudCalculator
{
    public static int GetNumberOfIntersectionsNoDiagonals(Cloud[] clouds) => clouds
        .Where(l => l.X1 == l.X2 || l.Y1 == l.Y2)
        .SelectMany(c => c.Points())
        .GroupBy(c => c)
        .Select(group => group.Count())
        .Count(g => g > 1);

    public static int GetNumberOfIntersections(Cloud[] clouds) => clouds
        .SelectMany(c => c.Points())
        .GroupBy(c => c)
        .Select(group => group.Count())
        .Count(g => g > 1);
}
