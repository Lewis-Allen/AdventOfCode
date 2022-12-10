using Day05;

var lines = File.ReadAllLines("Inputs/5.txt");

var stackLines = lines.Take(9).ToArray();

var instructions = lines.Skip(10)
    .Select(Instruction.FromString)
    .ToArray();

var stackHolder = new StackHolder(stackLines);
foreach(var instruction in instructions)
{
    stackHolder.ApplyInstruction9000(instruction);
}

var message = stackHolder.GetMessage();

Console.WriteLine($"The 9000 message is {message}.");

stackHolder = new StackHolder(stackLines);
foreach (var instruction in instructions)
{
    stackHolder.ApplyInstruction9001(instruction);
}

message = stackHolder.GetMessage();

Console.WriteLine($"The 9001 message is {message}.");