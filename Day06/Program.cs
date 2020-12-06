using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var file = File.ReadAllText("../../../input.txt")
    .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

// Part One
int questions = file.Select(s => s.Replace("\r\n", ""))
    .Sum(s => s.Distinct().Count());

Console.WriteLine($"Part One: {questions}");

// Part Two
IEnumerable<char> c = "abcdefghijklmnopqrstuvwxyz";

var count = file.Select(s => s.Split("\r\n"))
    .Select(s => s.Aggregate(c, (a, b) => a.Intersect(b)))
    .Sum(s => s.Count());

Console.WriteLine($"Part Two: {count}");


