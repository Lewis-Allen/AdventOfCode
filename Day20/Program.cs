using Day20;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

var items = File.ReadAllText("../../../Input.txt")
    .Split("\r\n\r\n")
    .Select(s => s.Split("\r\n"))
    .Select(s => new Tile(long.Parse(Regex.Match(s[0], "\\d+").Value), s.Skip(1).Select(s => s.ToCharArray()).ToArray()))
    .ToList();

// Part One
Tile current = items.First();
current.FindNeighbours(items);

// We know the map is a square so corners can be found by looking for tiles that have exactly 2 neighbours.
var cornerMult = items.Where(s =>
{
    int count = (s.Top is not null ? 1 : 0) +
                (s.Right is not null ? 1 : 0) +
                (s.Bottom is not null ? 1 : 0) +
                (s.Left is not null ? 1 : 0);

    return count == 2;
}).Select(tile => tile.ID).Aggregate((acc, t) => acc * t);

Console.WriteLine($"The product of all the corner IDs is {cornerMult}.");

// Part Two
var topLeftCorner = items.Find(t =>
{
    int count = (t.Top is not null ? 1 : 0) +
                (t.Right is not null ? 1 : 0) +
                (t.Bottom is not null ? 1 : 0) +
                (t.Left is not null ? 1 : 0);

    return count == 2 && t.Top is null && t.Left is null;
});

Tile currentTile = null;
List<string> puzzleLines = new();

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

var puzzleCharArray = puzzleLines.Select(s => s.ToCharArray()).ToArray();

// Co-ord positions for a sea monster.
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
int tilesPerMonster = positions.Count;

int seaMonsters = 0;

foreach (var config in GetConfigsForMap(puzzleCharArray))
{
    for(int y = 0; y < config.Length - 3; y++)
    {
        for(int x = 0; x < config[y].Length - 20; x++)
        {
            if (positions.All(a => config[y + a.Item2][x + a.Item1] == '#'))
                seaMonsters++;
        }
    }

    if (seaMonsters != 0)
        break;
}

var hashCount = puzzleLines.Sum(s => s.Count(c => c == '#')) - (seaMonsters * tilesPerMonster);

Console.WriteLine($"There are {seaMonsters} sea monsters leaving {hashCount} hashes on the map.");

static List<char[][]> GetConfigsForMap(char[][] input)
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