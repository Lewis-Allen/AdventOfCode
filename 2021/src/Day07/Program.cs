using Day07;

var crabs = File.ReadAllText("Inputs/7.txt")
    .Split(",")
    .Select(int.Parse)
    .ToArray();

var minFuel = CrabAligner.GetFuelRequiredToAlign(crabs);

Console.WriteLine($"The minimum fuel required to align is {minFuel}.");

minFuel = CrabAligner.GetFuelRequiredToAlignWithIncreasingCost(crabs);

Console.WriteLine($"The minimum fuel required to align with increasing costs is {minFuel}.");