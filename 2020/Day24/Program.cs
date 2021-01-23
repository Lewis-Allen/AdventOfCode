using Day24;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllLines("../../../Input.txt")
    .Select(l => ParseLine(l))
    .ToList();

Dictionary<Pos, HexCell> lookup = new();
HexCell reference = new(new Pos(0,0), true, lookup);

foreach(var line in lines)
{
    reference.Transverse(line, lookup);
}

int flippedTileCount = lookup.Values.Count(cell => !cell.White);

Console.WriteLine($"The number of black tiles is {flippedTileCount}.");

static Stack<Direction> ParseLine(string line)
{
    var matches = Regex.Matches(line, "(ne)|(nw)|(se)|(sw)|(e)|(w)");

    Stack<Direction> directions = new(matches.Select(m => (Direction)Enum.Parse(typeof(Direction), m.Value.ToUpper())).ToList());

    return directions;
}

// Part Two
var daysPassed = 0;
while(daysPassed < 100)
{
    var toFlips = lookup.Values.ToList();
    foreach(var toFlip in toFlips)
    {
        toFlip.GetAdjacents(lookup);
    }
    toFlips = lookup.Values.ToList();

    toFlips = toFlips.Where(cell =>
    {
        var count = cell.GetAdjacents(lookup).Count(cell => !cell.White);
        return (cell.White && count is 2) || ((!cell.White) && count is 0 or > 2);
    }).ToList();

    toFlips.ForEach(cell => cell.White = !cell.White);

    daysPassed++;
    int blackTileCount = lookup.Values.Count(cell => !cell.White);
    Console.WriteLine($"Days Passed: {daysPassed}, Number of black tiles: {blackTileCount}.");
}