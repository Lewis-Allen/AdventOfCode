using Day10;

var lines = File.ReadAllLines("Inputs/10.txt");

long score = LineCalculator.CalculateScoreForCorrupt(lines);

Console.WriteLine($"The total score for the corrupt lines is {score}.");

score = LineCalculator.CalculateScoreForIncomplete(lines);

Console.WriteLine($"The winning score for the incomplete lines is {score}.");