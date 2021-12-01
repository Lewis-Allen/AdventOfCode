using Day01;

var depths = File.ReadAllLines("Inputs/1.txt")
    .Select(l => int.Parse(l))
    .ToArray();

// Part One
var depthIncreases = DepthCalculator.GetDepthIncreasesCount(depths);

Console.WriteLine($"The number of times the depth increases is {depthIncreases}.");

// Part Two
depthIncreases = DepthCalculator.GetDepthIncreasesCountWithMeasuringWindow(depths);

Console.WriteLine($"The number of times the depth increases when using measuring windows is {depthIncreases}.");