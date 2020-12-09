using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");
long target = 0;

// Part One
for (var i = 25; i < lines.Length; i++)
{
    List<long> preamble = new();

    for(int j = i - 25; j < i; j++)
    {
        preamble.Add(long.Parse(lines[j]));
    }
    long result = long.Parse(lines[i]);

    Combinations<long> combos = new Combinations<long>(preamble, 2);
    if(!combos.Any(s => s.Sum() == result))
    {
        target = result;
        break;
    }
}

// Part Two
for(int count = 2; count < lines.Length; count++)
    for (int i = 0; i < (lines.Length - count); i++)
    {
        var elements = lines.Skip(i).Take(count).Select(long.Parse);
        long segSum = elements.Sum();

        if (segSum == target)
            Console.WriteLine(elements.Min() + elements.Max());
    }


