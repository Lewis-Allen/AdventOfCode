using Day13;

var input = File.ReadAllLines("Inputs/13.txt");

var seatingArrangements = new Dictionary<(string, string), int>();

foreach(var line in input)
{
    ((string person, string nextTo) seating, int happiness) information = HappinessCalculator.ParseLine(line);

    seatingArrangements.Add((information.seating.person, information.seating.nextTo), information.happiness);
}

// Part One
var optimalHappiness = HappinessCalculator.FindHappinessFromOptimalSeating(seatingArrangements);

Console.WriteLine($"The optimal happiness is {optimalHappiness}.");

// Part Two
var names = seatingArrangements.Keys
    .Select(sa => sa.Item1)
    .Distinct()
    .SelectMany(name => new List<((string, string), int)>() {
        (("Lewis", name), 0),
        ((name, "Lewis"), 0)
    });

foreach(var newPairs in names)
{
    seatingArrangements.Add(newPairs.Item1, newPairs.Item2);
}

var optimalHappinessIncludingMe = HappinessCalculator.FindHappinessFromOptimalSeating(seatingArrangements);

Console.WriteLine($"The optimal happiness, myself included is {optimalHappinessIncludingMe}.");