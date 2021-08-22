using Day02;
using System;
using System.IO;

var program = File.ReadAllText("Inputs/2.txt");

// Part One
var computer = new IntcodeComputer(program);
computer[1] = 12;
computer[2] = 2;

var result = computer.RunProgramPartOne();

Console.WriteLine($"The value at position zero for part one is {result}");

// Part Two
bool solutionFound = false;
int expected = 19690720;
int noun = 0;
int verb = 0;

int currentMax = 0;
while (!solutionFound)
{
    for (int x = 0; x <= currentMax; x++)
    {
        if (RunForPartTwo(program, currentMax, x, expected))
        {
            noun = currentMax;
            verb = x;
            solutionFound = true;
        }
        else if (!solutionFound && RunForPartTwo(program, x, currentMax, expected))
        {
            noun = x;
            verb = currentMax;
            solutionFound = true;
        }
    }

    currentMax++;
}

Console.WriteLine($"Part Two: Noun={noun}, Verb={verb}, 100*{noun}+{verb}={100 * noun + verb}.");

static bool RunForPartTwo(string program, int noun, int verb, int expected)
{
    var computer = new IntcodeComputer(program);
    try
    {
        computer[1] = noun;
        computer[2] = verb;

        var output = computer.RunProgramPartOne();
        if (output == expected)
        {
            return true;
        }
    }
    catch (Exception)
    {
        // Program not valid. Return fail.
    }

    return false;
}
