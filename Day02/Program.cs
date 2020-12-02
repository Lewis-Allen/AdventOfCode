using System;
using System.IO;

var lines = File.ReadAllLines("../../../input.txt");

int validPasswordCount = 0;
foreach(var line in lines)
{
    string[] values = line.Split(new[] { "-", " " }, StringSplitOptions.RemoveEmptyEntries);

    int min = int.Parse(values[0]) - 1;
    int max = int.Parse(values[1]) - 1;

    char letter = values[2][0];
    string password = values[3];

    if (password[min] == letter ^ password[max] == letter)
        validPasswordCount++;
}

Console.WriteLine(validPasswordCount);