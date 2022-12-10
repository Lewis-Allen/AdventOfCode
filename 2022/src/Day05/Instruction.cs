using System.Text.RegularExpressions;

namespace Day05;

public partial record Instruction(int Number, int Source, int Destination)
{

    [GeneratedRegex("move (\\d+) from (\\d+) to (\\d+)", RegexOptions.Compiled)]
    private static partial Regex InstructionRegex();

    public static Instruction FromString(string input)
    {
        var match = InstructionRegex().Match(input);

        var number = int.Parse(match.Groups[1].Value);
        var source = int.Parse(match.Groups[2].Value);
        var destination = int.Parse(match.Groups[3].Value);

        return new Instruction(number, source, destination);
    }
}
