using System;
using System.IO;

var integers = Array.ConvertAll(File.ReadAllLines("../../../input.txt"), int.Parse);

for(var i = 0; i < integers.Length; i++)
    for(var j = i + 1; j < integers.Length; j++)
        for(var k = j + 1; k < integers.Length; k++)
            if (integers[i] + integers[j] + integers[k] == 2020)
                Console.WriteLine(integers[i] * integers[j] * integers[k]);