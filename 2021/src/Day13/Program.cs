using Day13;

var lines = File.ReadAllLines("Inputs/13.txt");

var separator = Array.IndexOf(lines, "");

var dots = lines
    .Take(separator)
    .Select(l =>
    {
        var split = l.Split(',');
        return new Dot(int.Parse(split[0]), int.Parse(split[1]));
    })
    .ToArray();

var instructions = lines
    .Take((separator + 1)..lines.Length)
    .Select(l =>
    {
        var split = l[11..^0].Split("=");
        return new Instruction(split[0] == "x", int.Parse(split[1]));
    })
    .ToArray();

for (int i = 0; i < instructions.Length; i++)
{
    dots = PaperFolder.Fold(instructions[i], dots);

    if(i == 0)
        Console.WriteLine($"The number of dots after a single folder is {dots.Length}.");
}

// This outputs my 8 digit code to the console
PaperFolder.OutputToConsole(dots);