using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt")
    .Select(long.Parse)
    .ToList();

long target = 0;

// Part One
for (var i = 25; i < lines.Count; i++)
{
    long result = lines[i];

    List<long> preamble = lines.Skip(i - 25).Take(25).ToList();

    Combinations<long> combos = new(preamble, 2);

    if(!combos.Any(s => s.Sum() == result))
    {
        target = result;
        break;
    }
}

// Part Two
for(int segLength = 2; segLength < lines.Count; segLength++)
    for (int segStart = 0; segStart < (lines.Count - segLength); segStart++)
    {
        var elements = lines.Skip(segStart).Take(segLength);
        long segSum = elements.Sum();

        if (segSum == target)
            Console.WriteLine(elements.Min() + elements.Max());
    }