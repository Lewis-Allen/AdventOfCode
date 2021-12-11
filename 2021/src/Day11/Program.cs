using Day11;

var lines = File.ReadAllLines("Inputs/11.txt");

var octopuses = lines
    .SelectMany((l, y) => l.Select((o, x) => new Octopus(x, y, o - '0')));

var flashes = OctopusCalculator.GetFlashesAfterXSteps(octopuses.ToArray(), 100);

Console.WriteLine($"The number of flashes are 100 steps is {flashes}.");

var step = OctopusCalculator.GetSynchronisingFlashStep(octopuses.ToArray());

Console.WriteLine($"The step where all octopuses flash at the same time is {step}.");