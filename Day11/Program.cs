using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

var lines = File.ReadAllLines("../../../input.txt");

var current = new List<string>(lines);
var next = new List<string>(lines);

bool changed;
do
{
    changed = false;
    for (int y = 0; y < current.Count; y++)
    {
        for (int x = 0; x < current[y].Length; x++)
        {
            var character = current[y][x];

            if (character == 'L' && CheckSurroundingsPartTwo(current, y, x) == 0)
            {
                StringBuilder str = new(next[y]);
                str[x] = '#';
                next[y] = str.ToString();
                changed = true;
            }

            if(character == '#' && CheckSurroundingsPartTwo(current, y, x) >= 5)
            {
                StringBuilder str = new(next[y]);
                str[x] = 'L';
                next[y] = str.ToString();
                changed = true;
            }
        }
    }

    current = new List<string>(next);
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

    // Left
    for(int i = x - 1; i >= 0; i--)
    {
        if (lines[y][i] == 'L')
            break;

        if (lines[y][i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Right
    for (int i = x + 1; i < lines[y].Length; i++)
    {
        if (lines[y][i] == 'L')
            break;

        if (lines[y][i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Up
    for (int i = y - 1; i >= 0; i--)
    {
        if (lines[i][x] == 'L')
            break;

        if (lines[i][x] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Down
    for (int i = y + 1; i < lines.Count; i++)
    {
        if (lines[i][x] == 'L')
            break;

        if (lines[i][x] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Upper Left
    for(int i = 1;; i++)
    {
        if (x - i < 0 || y - i < 0)
            break;

        if(lines[y - i][x - i] == 'L')
        {
            break;
        }
        if (lines[y - i][x - i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Upper Right
    for(int i = 1; ; i++)
    {
        if (y - i < 0 || x + i >= lines[y].Length)
            break;

        if (lines[y - i][x + i] == 'L')
        {
            break;
        }
        if (lines[y - i][x + i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Lower Right
    for (int i = 1; ; i++)
    {
        if (y + i >= lines.Count || x + i >= lines[y].Length)
            break;

        if (lines[y + i][x + i] == 'L')
        {
            break;
        }
        if (lines[y + i][x + i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    // Lower Left
    for(int i = 1; ; i++)
    {
        if (y + i >= lines.Count || x - i < 0)
            break;

        if (lines[y + i][x - i] == 'L')
        {
            break;
        }
        if (lines[y + i][x - i] == '#')
        {
            noOfOccupied++;
            break;
        }
    }

    return noOfOccupied;
}