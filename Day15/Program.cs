using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt").Select(s => s.Split(",")).ToArray();

foreach (var line in lines)
{
    Console.WriteLine(GetNthPosition(Array.ConvertAll(line, long.Parse), 2020));
}

static long GetNthPosition(long[] numbers, long pos)
{
    List<long> numbersList = numbers.ToList();
    int turnCounter = numbersList.Count;

    while(numbersList.Count < pos)
    { 
        long number = numbersList.Last();
        if (numbersList.Count(c => c == number) < 2)
        {
            numbersList.Add(0);
        }
        else
        {
            long lastOccurence = Array.LastIndexOf(numbersList.SkipLast(1).ToArray(), number) + 1;

            numbersList.Add(turnCounter - lastOccurence);
        }

        turnCounter++;
    }

    return numbersList.Last();
}