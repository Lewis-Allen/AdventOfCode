using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt");

PartOne(lines);

PartTwo(lines);

PartTwoCondensed(lines);

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

    Console.WriteLine($"Part One - The first bus that leaves after {leavingTime} is Bus ID {theBus.s} at {theBus.Item2}. There is a {minutesToWait} minute waiting time. Waiting time multiplied by bus ID is {theBus.s * minutesToWait}.");
}

/**
 * This can be done in a couple of LINQ statements (See PartTwoCondensed).
 * But if I look back on this code one day, i'll probably have no idea what I was doing.
 * So i'm keeping this one because it's more readable.
 */
static void PartTwo(string[] lines)
{
    var totals = new List<long>();

    var filteredBusIDs = lines[1]
        .Split(',')
        .Select((value, index) => (value, index))
        .Where(s => s.value != "x")
        .Select(s => (long.Parse(s.value), s.index))
        .ToList();

    // Product of all values
    long N = filteredBusIDs.Aggregate(1L, (acc, s) => acc * s.Item1);

    var test = filteredBusIDs
        .Select(s => (s.Item1 - s.index) * (N / s.Item1) * ModuloInverse(N / s.Item1, s.Item1))
        .Sum();

    Console.WriteLine(test % N);

    for (int i = 0; i < filteredBusIDs.Count; i++)
    {
        long busID = filteredBusIDs[i].Item1;

        long Bi = busID - filteredBusIDs[i].index;
        long Ni = N / busID;
        long Xi = ModuloInverse(Ni, busID);

        totals.Add(Bi * Ni * Xi);
    }

    long timestamp = totals.Sum() % N;

    Console.WriteLine($"Part Two - The timestamp we are looking for is {timestamp}.");
}

/**
 * Short version of the above PartTwo function.
 * But it's a lot less readable.
 */
static void PartTwoCondensed(string[] lines)
{
    var filteredBusIDs = lines[1]
        .Split(',')
        .Select((value, index) => (value, index))
        .Where(s => s.value != "x")
        .Select(s => (long.Parse(s.value), s.index))
        .ToList();

    long N = filteredBusIDs.Aggregate(1L, (acc, s) => acc * s.Item1);

    var total = filteredBusIDs
        .Select(s => (s.Item1 - s.index) * (N / s.Item1) * ModuloInverse(N / s.Item1, s.Item1))
        .Sum();

    Console.WriteLine($"Part Two Condensed - The timestamp we are looking for is {total % N}.");
}

static long ModuloInverse(long a, long m)
{
    a %= m;
    for (int x = 1; x < m; x++)
        if ((a * x) % m == 1)
            return x;
    return 1;
}