using System;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

int validPasswordCount = lines.Count(PartOneVerify);
Console.WriteLine($"Part one valid passwords: {validPasswordCount}");

validPasswordCount = lines.Count(PartTwoVerify);
Console.WriteLine($"Part two valid passwords: {validPasswordCount}");

static bool PartOneVerify(string line)
{
    string[] values = line.Split(new[] { "-", " " }, StringSplitOptions.None);

    int min = int.Parse(values[0]) - 1;
    int max = int.Parse(values[1]) - 1;

    char letter = values[2][0];
    string password = values[3];

    int occurrences = password.Count(c => c == letter);
    return occurrences >= min && occurrences <= max;
}

static bool PartTwoVerify(string line)
{
    string[] values = line.Split(new[] { "-", " " }, StringSplitOptions.None);

    int min = int.Parse(values[0]) - 1;
    int max = int.Parse(values[1]) - 1;

    char letter = values[2][0];
    string password = values[3];

    return password[min] == letter ^ password[max] == letter;
}

