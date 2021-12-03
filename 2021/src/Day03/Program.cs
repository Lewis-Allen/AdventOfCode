using Day03;

var lines = File.ReadAllLines("Inputs/3.txt").ToArray();

var powerConsumption = RateCalculator.GetPowerConsumption(lines);

Console.WriteLine($"The power consumption rate is {powerConsumption}.");

var lifeSupportRating = RateCalculator.GetLifeSupportRating(lines);

Console.WriteLine($"The life support rating is {lifeSupportRating}.");