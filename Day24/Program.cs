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
    Stack<Direction> directions = new();

    var matches = Regex.Matches(line, "(ne)|(nw)|(se)|(sw)|(e)|(w)");

    directions = new(matches.Select(m => (Direction)Enum.Parse(typeof(Direction), m.Value.ToUpper())).ToList());

    return directions;
}