using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

Dictionary<int, List<int>> seats = new();

int highestSeatId = 0;
foreach (var line in lines)
{
    int row = BinarySpacePartition(line.Substring(0, 7), 0, 127);
    int column = BinarySpacePartition(line.Substring(7, 3), 0, 7);

    if(row != 127 && row != 0)
    {
        var columns = seats.GetValueOrDefault(row);
        if (columns == null)
            columns = new List<int>();

        columns.Add(column);
        seats[row] = columns;
    }

    int seatId = row * 8 + column;

    if (seatId > highestSeatId)
        highestSeatId = seatId;
}

HashSet<int> lookup = new() { 0, 1, 2, 3, 4, 5, 6, 7 };
foreach(var key in seats.Keys)
{
    HashSet<int> values = new(seats[key]);
    values.SymmetricExceptWith(lookup);

    if (values.Count == 1)
    {
        Console.WriteLine(key);
        Console.WriteLine(values.ToList()[0]);
        Console.WriteLine($"Your seat id: {key * 8 + values.ToList()[0]}");
    }
}

static int BinarySpacePartition(string commands, int min, int max)
{
    Console.WriteLine(commands);
    int result = 0;
    foreach(char letter in commands)
    {
        if (min == max) return min;

        if (letter == 'F' || letter == 'L')
        {
            max -= (max - min) / 2 + 1;
        }
        else
        {
            min += (max - min) / 2 + 1;
        }

        result = min;
    }
    return result; 
}