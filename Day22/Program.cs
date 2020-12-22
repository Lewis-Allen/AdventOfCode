using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllText("../../../Input.txt")
    .Split("\r\n\r\n")
    .Select(s => s.Split("\r\n").Skip(1).ToArray())
    .Select(k => new Queue<long>(Array.ConvertAll(k, long.Parse)))
    .ToArray();

var p1 = lines[0];
var p2 = lines[1];

// Part One
while(p1.Count > 0 && p2.Count > 0)
{
    var p1current = p1.Dequeue();
    var p2current = p2.Dequeue();

    if(p1current > p2current)
    {
        p1.Enqueue(p1current);
        p1.Enqueue(p2current);
    }
    else
    {
        p2.Enqueue(p2current);
        p2.Enqueue(p1current);
    }

}

long acc = 0;
var winner = p1.Count > 0 ? p1 : p2;
for (int i = winner.Count - 1; i >= 0; i--)
{
    acc += winner.ElementAt(i) * (winner.Count - i);
}

Console.WriteLine($"The winning player's score is {acc}.");