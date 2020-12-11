using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

var lines = File.ReadAllLines("../../../example1.txt");

var current = new List<string>(lines);
var next = new List<string>(lines);

var changed = false;
PrintLines(current);
do
{
    changed = false;
    for (int y = 0; y < current.Count; y++)
    {
        for (int x = 0; x < current[y].Length; x++)
        {
            var character = current[y][x];

            if (character == 'L' && CheckSurroundingsPartOne(current, y, x) == 0)
            {
                StringBuilder str = new(next[y]);
                str[x] = '#';
                next[y] = str.ToString();
                changed = true;
            }

            if(character == '#' && CheckSurroundingsPartOne(current, y, x) >= 4)
            {
                StringBuilder str = new(next[y]);
                str[x] = 'L';
                next[y] = str.ToString();
                changed = true;
            }
        }
    }

    current = new List<string>(next);
    PrintLines(current);
} while (changed);

var count = current.Sum(s => s.Count(c => c == '#'));
Console.WriteLine($"Total number of occupied seat is {count}");

static int CheckSurroundingsPartOne(List<string> lines, int y, int x)
{
    int noOfOccupied = 0;

    // Dont count current seat
    int currentOccupied = lines[y][x] == '#' ? 1 : 0;

    var occupied = lines.Where((a, i) => i <= y + 1 && i >= y - 1)
        .SelectMany(s => s.Where((b, j) => j <= x + 1 && j >= x - 1))
        .Count(s => s == '#');

    noOfOccupied = occupied - currentOccupied;
        
    return noOfOccupied;
}

static int CheckSurroundingsPartTwo(List<string> lines, int y, int x)
{
    int noOfOccupied = 0;

    // Dont count current seat
    int currentOccupied = lines[y][x] == '#' ? 1 : 0;

    var occupied = lines.Where((a, i) => i <= y + 1 && i >= y - 1)
        .SelectMany(s => s.Where((b, j) => j <= x + 1 && j >= x - 1))
        .Count(s => s == '#');

    noOfOccupied = occupied - currentOccupied;

    return noOfOccupied;
}

static void PrintLines(List<string> lines)
{
    foreach(var line in lines)
    {
        Console.WriteLine(line);
    }
    Console.WriteLine();
    Console.WriteLine("----------------------------------------------------------------------------------------------------");
    Console.WriteLine();
}