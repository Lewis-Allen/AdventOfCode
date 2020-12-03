using System;
using System.IO;
using System.Linq;
var lines = File.ReadAllLines("../../../input.txt");

var slope = string.Join("", lines.Select(s => s.Trim()).ToArray());

int length = lines[0].Length;
int totalTrees = CheckSlope(slope, length, 1, 1) *
                 CheckSlope(slope, length, 3, 1) *
                 CheckSlope(slope, length, 5, 1) *
                 CheckSlope(slope, length, 7, 1) *
                 CheckSlope(slope, length, 1, 2);


Console.WriteLine(totalTrees);

static int CheckSlope(string slope, int length, int x, int y)
{
    int noOfTrees = 0;
    int curPos = 0;

    while (curPos < slope.Length)
    {
        if (slope[curPos] == '#')
            noOfTrees++;

        curPos = ((curPos + x) / length > curPos / length ? curPos - (curPos % length) + ((curPos + x) % length) : curPos + x) + (y * length);
    }

    return noOfTrees;
}