using System;
using System.IO;
using System.Linq;

int validPasswordCount = File.ReadAllLines("../../../input.txt").Count(line =>
{
    string[] values = line.Split(new[] { "-", " " }, StringSplitOptions.None);

    int min = int.Parse(values[0]) - 1;
    int max = int.Parse(values[1]) - 1;

    char letter = values[2][0];
    string password = values[3];

    return password[min] == letter ^ password[max] == letter;
});

Console.WriteLine(validPasswordCount);
