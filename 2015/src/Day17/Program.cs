using Day17;

var containers = File.ReadAllLines("Inputs/17.txt")
    .Select((x, i) => new Container(i, int.Parse(x)))
    .ToList();

var combinations = EggnogCombinationsFinder.GetNoOfCombinations(containers, 150);

Console.WriteLine($"The number of unique combinations to reach 150 litres is {combinations}.");

combinations = EggnogCombinationsFinder.GetNoOfMinimumCombinations(containers, 150);

Console.WriteLine($"The number of unique combinations with minimum containers to reach 150 litres is {combinations}.");