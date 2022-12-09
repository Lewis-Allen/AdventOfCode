using Day04;

var lines = File.ReadAllLines("Inputs/4.txt");

var overlapsFully = lines.Select(ElfPair.FromString)
    .Where(ElfPair.OverlapsFully)
    .Count();

Console.WriteLine($"The number of fully overlapping pairs is {overlapsFully}.");

var overlaps = lines.Select(ElfPair.FromString)
    .Where(ElfPair.Overlaps)
    .Count();

Console.WriteLine($"The number of overlapping pairs is {overlaps}.");