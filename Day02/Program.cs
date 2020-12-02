using System;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("../../../input.txt");

int validPasswordCount = 0;
foreach(var s in input)
{
    string[] values = s.Split(new[] { "-", ":", " " }, StringSplitOptions.RemoveEmptyEntries);

    int min = int.Parse(values[0]) - 1;
    int max = int.Parse(values[1]) - 1;

    char letter = values[2][0];
    string password = values[3];

    if (password[min] == letter ^ password[max] == letter)
        validPasswordCount++;
}

Console.WriteLine(validPasswordCount);