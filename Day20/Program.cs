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

// Part Two

// I want to put the puzzle together into a nice string array...
var topLeftCorner = items.Find(t =>
{
    int count = (t.Top is not null ? 1 : 0) +
                (t.Right is not null ? 1 : 0) +
                (t.Bottom is not null ? 1 : 0) +
                (t.Left is not null ? 1 : 0);

    return count == 2 && t.Top is null && t.Left is null;
});

List<string> puzzleLines = new();

Tile currentTile = null;
do
{
    currentTile = currentTile is null ? topLeftCorner : currentTile.Bottom;

    for (int i = 1; i < currentTile.Value.Length - 1; i++)
    {
        Tile currentTileLine = null;
        List<string> line = new();
        do
        {
            currentTileLine = currentTileLine is null ? currentTile : currentTileLine.Right;
            line.Add(new string(currentTileLine.Value[i][1..^1]));
        } while (currentTileLine.Right != null);

        puzzleLines.Add(string.Join(string.Empty, line.ToArray()));
    }
} while (currentTile.Bottom is not null);


foreach(var puzzleLine in puzzleLines)
{
    Console.WriteLine(puzzleLine);
}

var puzzleCharArray = puzzleLines.Select(s => s.ToCharArray()).ToArray();
int seaMonsters = 0;
int tilesPerMonster = 15;

List<(int, int)> positions = new()
{
    (0, 1),
    (1, 2),
    (4, 2),
    (5, 1),
    (6, 1),
    (7, 2),
    (10, 2),
    (11, 1),
    (12, 1),
    (13, 2),
    (16, 2),
    (17, 1),
    (18, 1),
    (18, 0),
    (19, 1)
};

foreach (var config in GetConfigs(puzzleCharArray))
{
    for(int y = 0; y < config.Length - 3; y++)
    {
        for(int x = 0; x < config[y].Length - 20; x++)
        {
            bool isSeaMonster = true;
            foreach(var pos in positions)
            {
                if(config[y + pos.Item2][x + pos.Item1] != '#')
                {
                    isSeaMonster = false;
                    break;
                }
            }

            if(isSeaMonster)
                seaMonsters++;
        }
    }

    if (seaMonsters != 0)
        break;
}

Console.WriteLine(seaMonsters);
var hashCount = puzzleLines.Sum(s => s.Count(c => c == '#')) - (seaMonsters * tilesPerMonster);

Console.WriteLine(hashCount);


static List<char[][]> GetConfigs(char[][] input)
{
    List<char[][]> configs = new();
    char[][] orig = new char[input.Length][];
    Array.Copy(input, orig, input.Length);

    for (int i = 0; i < 4; i++)
    {
        char[][] copy = new char[input.Length][];
        Array.Copy(orig, copy, input.Length);
        configs.Add(copy);

        copy = new char[input.Length][];
        Array.Copy(orig, copy, input.Length);
        copy = Tile.FlipH(copy);
        configs.Add(copy);

        copy = new char[input.Length][];
        Array.Copy(orig, copy, input.Length);
        copy = Tile.FlipV(copy);
        configs.Add(copy);

        orig = Tile.Rotate(orig);
    }

    return configs;
}