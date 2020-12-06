using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var file = File.ReadAllText("../../../input.txt")
    .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

// Part One
int yesInGroup = file.Select(s => s.Replace("\r\n", ""))
    .Sum(s => s.Distinct().Count());

Console.WriteLine($"Part One: {yesInGroup}");

// Part Two
var allYesInGroup = file.Select(s => s.Split("\r\n"))
    .Select(s => s.Aggregate((IEnumerable<char> a, IEnumerable<char> b) => a.Intersect(b)))
    .Sum(s => s.Count());

Console.WriteLine($"Part Two: {allYesInGroup}");


