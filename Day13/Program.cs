using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Example1.txt");

PartOne(lines);

static void PartOne(string[] lines)
{
    var leavingTime = int.Parse(lines[0]);
    var theBus = lines[1].Split(',')
        .Where(s => s != "x")
        .Select(s => int.Parse(s))
        .Select(s => (s, (Math.Floor((decimal)leavingTime / s) + 1) * s))
        .Where(s => s.Item2 >= leavingTime)
        .OrderBy(s => s.Item2)
        .First();

    var minutesToWait = theBus.Item2 - leavingTime;

    Console.WriteLine($"Part One: The first bus that leaves after {leavingTime} is Bus ID {theBus.s} at {theBus.Item2}. There is a {minutesToWait} minute waiting time. Waiting time multiplied by bus ID is {theBus.s * minutesToWait}.");
}

static void PartTwo(string[] lines)
{
    var busIDs = lines[1].Split(',');

    Console.WriteLine($"Part Two: ");
}