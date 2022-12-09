using Day03;

var lines = File.ReadAllLines("Inputs/3.txt");

var totalPriority = lines
    .Select(Rucksack.FromString)
    .Sum(Rucksack.GetRucksackPriority);

Console.WriteLine($"The total priority from {totalPriority}.");

totalPriority = lines
    .Select(Rucksack.FromString)
    .Chunk(3)
    .Sum(Rucksack.GetGroupPriority);

Console.WriteLine($"The total priority from groups of three is {totalPriority}.");