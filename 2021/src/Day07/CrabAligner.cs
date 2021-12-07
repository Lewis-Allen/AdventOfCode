namespace Day07;

public class CrabAligner
{
    public static int GetFuelRequiredToAlign(int[] crabs)
        => Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min())
            .Select(i => crabs.Sum(c => Difference(i, c)))
            .Min();

    public static int GetFuelRequiredToAlignWithIncreasingCost(int[] crabs)
        => Enumerable.Range(crabs.Min(), crabs.Max() - crabs.Min())
            .Select(i => crabs.Sum(c => Difference(i, c) * (Difference(i, c) + 1) / 2))
            .Min();

    private static int Difference(int target, int value)
        => Math.Abs(target - value);
}
