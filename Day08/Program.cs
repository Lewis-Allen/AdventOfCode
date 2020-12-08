using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

List<int> indexes = new();
for (var i = 0; i < lines.Length; i++)
{
    if (lines[i].Contains("nop") || lines[i].Contains("jmp"))
        indexes.Add(i);
}

foreach(var index in indexes)
{
    var linesCopy = new List<string>(lines).ToArray();

    linesCopy[index] = linesCopy[index].Contains("nop") ? linesCopy[index].Replace("nop", "jmp") : linesCopy[index].Replace("jmp", "nop");

    int res = RunProgram(linesCopy);

    if(res != 0)
        Console.WriteLine(res);
}

static int RunProgram(string[] lines)
{
    var index = 0;
    var acc = 0;
    HashSet<int> visitedInstructions = new();

    while (true)
    {
        if (index == lines.Length)
            return acc;

        // Shouldn't visit twice.. End
        if (visitedInstructions.Contains(index))
            return 0;

        visitedInstructions.Add(index);

        var values = lines[index].Split(" ");
        var operation = values[0];
        var argument = int.Parse(values[1]);

        switch (operation)
        {
            case "acc":
                acc += argument;
                index++;
                break;

            case "jmp":
                index += argument;
                break;

            default:
                index++;
                break;
        }
    }
}

