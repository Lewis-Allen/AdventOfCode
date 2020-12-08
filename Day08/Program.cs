using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

var lines = File.ReadAllLines("../../../input.txt");

List<int> NOPIndexes = new();
List<int> JMPIndexes = new();
for (var i = 0; i < lines.Length; i++)
{
    if (lines[i].Contains("nop"))
        NOPIndexes.Add(i);

    if (lines[i].Contains("jmp"))
        JMPIndexes.Add(i);
}

foreach(var nop in NOPIndexes)
{
    var linesCopy = new List<string>(lines).ToArray();

    linesCopy[nop] = linesCopy[nop].Replace("nop", "jmp");

    int res = RunProgram(linesCopy);

    if(res != 0)
        Console.WriteLine(res);
}

foreach (var jmp in JMPIndexes)
{
    var linesCopy = new List<string>(lines).ToArray();

    linesCopy[jmp] = linesCopy[jmp].Replace("jmp", "nop");

    int res = RunProgram(linesCopy);

    if (res != 0)
        Console.WriteLine(res);
}

Console.WriteLine("Finished.");

static int RunProgram(string[] lines)
{
    var index = 0;
    var acc = 0;
    List<int> visitedInstructions = new();

    while (true)
    {
        if (index == lines.Length)
        {
            Console.WriteLine($"Won with acc {acc}");
            return acc;
        }

        // Shouldn't visit twice.. End
        if (visitedInstructions.Contains(index))
        {
            return 0;
        }
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

