using Day08;

var lines = File.ReadAllLines("Inputs/8.txt");

var correctDigits = SignalDecoder.DecodeSignals(lines);

Console.WriteLine($"The number of 1, 4, 7 and 8s is {correctDigits}.");

var sum = SignalDecoder.DecodeSignalsAndGetSum(lines);

Console.WriteLine($"The sum of all outputs is {sum}.");