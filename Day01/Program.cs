using System;
using System.IO;
using System.Linq;

var integers = File.ReadAllLines("../../../input.txt").Select(val => int.Parse(val)).ToList();

for(var i = 0; i < integers.Count; i++)
{
    for(var j = i + 1; j < integers.Count; j++)
    {
        for(var k = j + 1; k < integers.Count; k++)
        {
            if (integers[i] + integers[j] + integers[k] == 2020)
                Console.WriteLine(integers[i] * integers[j] * integers[k]);
        }
    }
}