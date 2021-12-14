using Day14;

var lines = File.ReadAllLines("Inputs/14.txt");

// Parse Input
var polymer = lines[0];

var lookup = PolymerParser.ParseLines(lines.Skip(2).ToArray());

var pairsResult = PairResult.FromString(polymer);

// Step
for (int i = 0; i < 10; i++)
{
    pairsResult = PolymerParser.Step(pairsResult, lookup);
}

long count = pairsResult.KeyCounts.Values.Max() - pairsResult.KeyCounts.Values.Min();

Console.WriteLine($"The most common letter minus the least common letter after 10 steps is {count}.");

for (int i = 0; i < 30; i++)
{
    pairsResult = PolymerParser.Step(pairsResult, lookup);
}

count = pairsResult.KeyCounts.Values.Max() - pairsResult.KeyCounts.Values.Min();

Console.WriteLine($"The most common letter minus the least common letter after 40 steps is {count}.");

