using Day09;

var input = File.ReadAllLines("Inputs/9.txt");

var lineLength = input[0].Length;

var heights = input
    .SelectMany(l => l.ToCharArray())
    .Select(c => (int)c - '0')
    .ToArray();

var result = HeightmapCalculator.FindSumOfRisk(heights, lineLength);

Console.WriteLine($"The sum of risk for the heightmap is {result}.");

result = HeightmapCalculator.FindSumOfLargestBasins(heights, lineLength);

Console.WriteLine($"The sum of the largest basins is {result}.");