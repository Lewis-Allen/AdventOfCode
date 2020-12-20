using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var lines = File.ReadAllText("../../../Example1.txt").Split("\r\n\r\n");
var linesSplit = lines.Select(s => s.Split("\r\n")).ToArray();

Dictionary<int, char[][]> tiles = new();
foreach (var entry in linesSplit)
{
    tiles.Add(int.Parse(Regex.Match(entry[0], "\\d+").Value), entry.Skip(1).Select(s => s.ToCharArray()).ToArray());
}

foreach(var key in tiles.Keys)
{
    var tile = tiles[key];
    Console.WriteLine($"{key.ToString().PadRight(10, '-')} Rotated--- FlipH----- FlipV-----");

    var rotated = Rotate(tile);
    var flipH = FlipH(tile);
    var flipV = FlipV(tile);

    for(int i = 0; i < tile.Length; i++)
    {
        Console.WriteLine($"{new string(tile[i])} {new string(rotated[i])} {new string(flipH[i])} {new string(flipV[i])}");
    }

    Console.WriteLine();
}

static char[][] Rotate(char[][] tile)
{
    char[][] chars = new char[10][];
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = new char[10];
    }

    for (int i = 0; i < tile.Length; ++i)
    {
        for (int j = 0; j < tile.Length; ++j)
        {
            chars[i][j] = tile[tile.Length - j - 1][i];
        }
    }

    return chars;
}

static char[][] FlipH(char[][] tile)
{
    char[][] chars = new char[10][];
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = new char[10];
    }

    for (int x = 0; x < tile.Length / 2; x++)
    {
        for (int y = 0; y < tile.Length; y++)
        {
            var temp = tile[y][x];
            chars[y][x] = tile[y][tile.Length - 1 - x];
            chars[y][tile.Length - 1 - x] = temp;
        }
    }

    return chars;
}

static char[][] FlipV(char[][] tile)
{
    char[][] chars = new char[10][];
    for (int i = 0; i < chars.Length; i++)
    {
        chars[i] = new char[10];
    }

    for (int x = 0; x < tile.Length; x++)
    {
        for(int y = 0; y < tile.Length / 2; y++)
        {
            var temp = tile[y][x];
            chars[y][x] = tile[tile.Length - 1 - y][x];
            chars[tile.Length - 1 - y][x] = temp;
        }
    }

    return chars;
}

Console.WriteLine(  );