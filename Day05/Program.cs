using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

Dictionary<int, HashSet<int>> seats = new();
HashSet<int> columnLookup = new() { 0, 1, 2, 3, 4, 5, 6, 7 };

int highestSeatId = 0;
foreach (var line in lines)
{
    int row = Convert.ToInt32(line.Substring(0, 7).Replace('B', '1').Replace('F', '0'), 2);
    int column = Convert.ToInt32(line.Substring(7, 3).Replace('R', '1').Replace('L', '0'), 2);
    highestSeatId = Math.Max(highestSeatId, row * 8 + column);

    var columns = seats.GetValueOrDefault(row);
    if (columns == null)
        columns = new HashSet<int>();

    columns.Add(column);
    seats[row] = columns;
}
Console.WriteLine($"Highest Seat ID: {highestSeatId}");

foreach(var key in seats.Keys.Where(s => s != 0 && s != 127).ToList())
{
    HashSet<int> values = seats[key];
    values.SymmetricExceptWith(columnLookup);

    if (values.Count == 1)
    {
        Console.WriteLine($"Your Seat ID: {key * 8 + values.ToList()[0]}");
    }
}