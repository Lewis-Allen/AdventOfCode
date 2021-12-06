using Day06;

var lanternfish = File.ReadAllText("Inputs/6.txt")
    .Split(',')
    .Select(int.Parse)
    .ToArray();

long count = LanternfishCalculator.GetFishCountAfterXDays(lanternfish, 80);

Console.WriteLine($"The amount of lanternfish after 80 days is {count}.");

count = LanternfishCalculator.GetFishCountAfterXDays(lanternfish, 256);

Console.WriteLine($"The amount of lanternfish after 256 days is {count}.");