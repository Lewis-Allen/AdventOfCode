using Day02;

var lines = File.ReadAllLines("input.txt");

var result = Game.TotalOfPossibleIDs(lines, 12, 13, 14);

Console.WriteLine($"The total of all possible IDs is {result}.");

result = Game.GetPowerTotal(lines);

Console.WriteLine($"The sum of power of the sets is {result}.");