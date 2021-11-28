using Day14;

var lines = File.ReadAllLines("Inputs/14.txt");

var reindeers = lines.Select(l => ReindeerCalculator.ParseLine(l)).ToArray();

// Part One
var winningDistance = reindeers.Select(reindeer => reindeer.GetDistanceTravelledAfterSecondsFromStart(2503)).Max();

Console.WriteLine($"The distance travelled by the reindeer in the lead after 2503 seconds is {winningDistance}.");

// Part Two
ReindeerCalculator.PerformRace(reindeers, 2503);

var winningPoints = reindeers.Select(reindeer => reindeer.Points).Max();

Console.WriteLine($"The points held by the reindeer(s) in the lead at 2503 seconds are {winningPoints}.");
