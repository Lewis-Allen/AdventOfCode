using Day07;
using System;
using System.Collections.Generic;
using System.IO;

var program = File.ReadAllText("Inputs/7.txt");

// Part One
int result = 0;
for (var i = 0; i <= 99999; i++)
{
    var phaseSettings = new List<int>()
                {
                    i % 10,
                    i / 10 % 10,
                    i / 100 % 10,
                    i / 1000 % 10,
                    i / 10000 % 10
                };

    // Should do this properly really...
    if (new HashSet<int>(phaseSettings).Count < 5)
        continue;

    var input = 0;
    for (var ps = 0; ps < phaseSettings.Count; ps++)
    {
        var phaseSetting = phaseSettings[ps];
        IntcodeComputer2 computer = new(program);
        computer.RunProgram(phaseSetting, input);
        input = computer._output[^1];
    }

    if (input > result)
        result = input;
}

Console.WriteLine($"The highest returned result is {result}");

// Part Two
IntcodeComputerArray ica = new();
result = ica.RunProgram(program);

Console.WriteLine($"The highest thruster signal from the array is {result}.");