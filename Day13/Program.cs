using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Example1.txt");

//PartOne(lines);

PartTwo(lines);

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
    var totals = new List<long>();

    var filteredBusIDs = busIDs
            .Select((value, index) => (value, index))
            .Where(s => s.value != "x")
            .Select(s => (long.Parse(s.value), s.index))
            .ToList();

    // Sum of all values
    long N = filteredBusIDs.Aggregate(1L, (acc, s) => acc * s.Item1);

    for (int i = 0; i < busIDs.Length; i++)
    {
        if (!long.TryParse(busIDs[i], out long busID))
            continue;

        long Bi = i;
        long Ni = N / busID;
        long Xi = ModuloInverse(Ni, busID);

        Console.WriteLine($"Current Index: {i}");
        Console.WriteLine($"N: {N}, BusID: {busID}, Ni: {N / busID}");
        Console.WriteLine($"ModuloInverse({Ni},{busID}) = {Xi}");

        totals.Add(Bi * Ni * Xi);
    }

    long timestamp = totals.Sum() % N;

    Console.WriteLine($"Part Two: The timestamp we are looking for is {timestamp}.");
}

static long ModuloInverse(long a, long m)
{
    a %= m;
    for (int x = 1; x < m; x++)
        if ((a * x) % m == 1)
            return x;
    return 1;
}