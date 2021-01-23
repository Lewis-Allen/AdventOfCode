using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../Input.txt");

var cardKey = lines[0];
var doorKey = lines[1];

var cardLoopSize = FindLoopSize(long.Parse(cardKey), 7);

var res = Transform(long.Parse(doorKey), cardLoopSize);

Console.WriteLine(res);

static long FindLoopSize(long key, long subjectNumber)
{
    long value = 1;
    int loopSize = 0;
    while(value != key)
    {
        value *= subjectNumber;
        value %= 20201227;

        loopSize++;
    }

    return loopSize;
}

static long Transform(long subjectNumber, long loopSize)
{
    long value = 1;
    for(int i = 0; i < loopSize; i++)
    {
        value *= subjectNumber;
        value %= 20201227;
    }

    return value;
}