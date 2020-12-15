using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt").Select(s => s.Split(",")).ToArray();

// Part One
//Console.WriteLine(GetNthPosition(Array.ConvertAll(lines[0], long.Parse), 2020));

// Part Two

foreach (var line in lines)
{
    Console.WriteLine(GetNthPosition(Array.ConvertAll(line, long.Parse), 30000000L));
}

static long GetNthPosition(long[] numbers, long pos)
{
    Dictionary<long, long> lastTurns = new();
    for(var i = 1; i <= numbers.Length; i++)
    {
        lastTurns[numbers[i - 1]] = i;
    }

    long turnCounter = numbers.Length;
    long number = numbers.Last();

    while(turnCounter < pos)
    {
        long prevNumber = number;
        if (!lastTurns.ContainsKey(number))
        {
            number = 0;
        }
        else
        {
            number = turnCounter - lastTurns[number];
        }
        lastTurns[prevNumber] = turnCounter;

        turnCounter++;
    }
    /*
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

    return numbersList.Last();*/
    return number;
}