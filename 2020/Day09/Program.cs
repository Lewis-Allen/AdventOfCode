using Combinatorics.Collections;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = Array.ConvertAll(File.ReadAllLines("../../../input.txt"), long.Parse);

long target = PartOne(lines);
long encryptionWeakness = PartTwo(lines, target);

Console.WriteLine($"Target {target}, Weakness {encryptionWeakness}.");

// Part One
static long PartOne(long[] numbers)
{
    for (var i = 25; i < numbers.Length; i++)
    {
        long result = numbers[i];

        List<long> preamble = numbers.Skip(i - 25).Take(25).ToList();

        Combinations<long> combos = new(preamble, 2);

        if (!combos.Any(s => s.Sum() == result))
            return result;
    }

    return 0;
}

// Part Two
static long PartTwo(long[] numbers, long target)
{
    for (int segLength = 2; segLength < numbers.Length; segLength++)
        for (int segStart = 0; segStart < (numbers.Length - segLength); segStart++)
        {
            var segment = numbers.Skip(segStart).Take(segLength);
            long segSum = segment.Sum();

            if (segSum == target)
                return segment.Min() + segment.Max();
        }

    return 0;
}