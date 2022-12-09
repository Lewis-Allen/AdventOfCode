namespace Day04;

public record ElfPair(int LowerA, int UpperA, int LowerB, int UpperB)
{
    public static ElfPair FromString(string input)
    {
        var zones = input.Split(',')
            .Select(s => s.Split("-"))
            .ToArray();

        return new ElfPair(int.Parse(zones[0][0]), int.Parse(zones[0][1]), int.Parse(zones[1][0]), int.Parse(zones[1][1]));
    }

    public static bool OverlapsFully(ElfPair elfPair) => 
        (elfPair.LowerA <= elfPair.LowerB && elfPair.UpperA >= elfPair.UpperB) ||
        (elfPair.LowerB <= elfPair.LowerA && elfPair.UpperB >= elfPair.UpperA);

    public static bool Overlaps(ElfPair elfPair) =>
        (elfPair.UpperA >= elfPair.LowerB && elfPair.LowerA <= elfPair.UpperB) ||
        (elfPair.UpperB >= elfPair.LowerA && elfPair.UpperB <= elfPair.UpperA);
}
