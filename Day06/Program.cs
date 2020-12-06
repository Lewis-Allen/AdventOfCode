using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var file = File.ReadAllText("../../../input.txt")
    .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries);

var questions = file.Select(s => s.Replace("\r\n", ""))
    .Sum(s => s.Distinct().Count());

Console.WriteLine($"Part One: {questions}");

var lines = file.ToList();

int count = 0;
foreach(var group in lines)
{
    IEnumerable<char> letters = "abcdefghijklmnopqrstuvwxyz";
    
    var people = group.Split("\r\n");

    for (var i = 0; i < people.Length; i++)
    {
        letters = letters.Intersect(people[i]);
    }

    count += letters.Count();
}

Console.WriteLine($"Part Two: {count}");


