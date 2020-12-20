using Day20;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllText("../../../Input.txt").Split("\r\n\r\n");
var linesSplit = lines.Select(s => s.Split("\r\n")).ToArray();

Dictionary<long, char[][]> tiles = new();
foreach (var entry in linesSplit)
{
    tiles.Add(long.Parse(Regex.Match(entry[0], "\\d+").Value), entry.Skip(1).Select(s => s.ToCharArray()).ToArray());
}

// Start with arbritrary tile
var items = tiles.Select(s => new Tile(s.Key, s.Value)).ToList();

Tile current = items.First();
current.FindNeighbours(items);

var cornerMult = items.Where(s =>
{
    int count = (s.Top is not null ? 1 : 0) +
                (s.Right is not null ? 1 : 0) +
                (s.Bottom is not null ? 1 : 0) +
                (s.Left is not null ? 1 : 0);

    return count == 2;
}).Select(tile => tile.ID).Aggregate((acc, t) => acc * t);

Console.WriteLine(cornerMult);