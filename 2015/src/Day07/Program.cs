using Day07;
using System;
using System.IO;

var instructions = File.ReadAllText("Inputs/7.txt");

// Part One
var circuit = new Circuit(instructions);

var result = circuit.GetValueOf("a");

Console.WriteLine($"The value of wire a is: {result}");

// Part Two
circuit = new Circuit(instructions);

circuit.SetWire("b", result.ToString());

result = circuit.GetValueOf("a");
Console.WriteLine($"The value of wire a after setting b and a reset is: {result}");
