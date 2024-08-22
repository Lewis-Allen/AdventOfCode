using Day03;

var engine = File.ReadAllLines("input.txt")
    .Select(l => l.ToCharArray())
    .ToArray();

var result = EngineParser.GetSumOfPartNumbers(engine);

Console.WriteLine($"The sum of all part numbers in the engine is {result}.");

result = EngineParser.GetSumOfGearRatios(engine);

Console.WriteLine($"The sum of all gear ratios in the engine is {result}.");