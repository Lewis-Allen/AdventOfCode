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

// Add my own adapter...
threes++;

Console.WriteLine($"Ones ({ones}) by Threes ({threes}) = {ones * threes}");

// Part Two
long[] memo = new long[lines.Count];
memo[0] = 1;
memo[1] = 2;
memo[2] = 4;

for (var i = 3; i < lines.Count; i++)
{
    var threshold = lines[i] - 3;
    memo[i] = 0;

    if (lines[i - 3] >= threshold)
        memo[i] += memo[i - 3];

    if (lines[i - 2] >= threshold)
        memo[i] += memo[i - 2];

    if (lines[i - 1] >= threshold)
        memo[i] += memo[i - 1];
}

Console.WriteLine(memo[lines.Count - 1]);