using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllText("../../../input.txt")
    .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
    .Select(s => s.Replace("\r\n", ""))
    .ToList();

Console.WriteLine(lines.Sum(s => s.Distinct().Count()));

lines = File.ReadAllText("../../../input.txt")
    .Split("\r\n\r\n", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

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

Console.WriteLine(count);


