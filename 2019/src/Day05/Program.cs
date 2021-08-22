using Day05;
using System;
using System.IO;

var program = File.ReadAllText("Inputs/5.txt");

// Part One
var computer = new IntcodeComputer(program);

var result = computer.RunProgramPartOne(1);

//Console.WriteLine(result);
computer._output.ForEach(s => Console.WriteLine(s));

// Part Two
computer = new IntcodeComputer(program);

result = computer.RunProgramPartOne(5);

Console.WriteLine(result);
computer._output.ForEach(s => Console.WriteLine(s));