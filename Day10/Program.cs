using System;
using System.IO;
using System.Linq;

var lines = Array.ConvertAll(File.ReadAllLines("../../../input.txt"), int.Parse).ToList();

lines.Sort();

int ones = 0;
int threes = 0;

var a = 0;

for(var i = 0; i < lines.Count; i++)
{
    var b = lines[i];
    int difference = b - a;

    if (difference == 1)
        ones++;

    if (difference == 3)
        threes++;

    a = b;
}

// Add my own adaptor...
threes++;

Console.WriteLine($"Ones ({ones}) by Threes ({threes}) = {ones * threes}");