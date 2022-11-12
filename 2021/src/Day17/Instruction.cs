using System.Text.RegularExpressions;

namespace Day17;

public record Instruction(int FromX, int ToX, int FromY, int ToY)
{
    private static readonly Regex INSTRUCTION_EXPRESSION = new(@"target area: x=([-]?\d+)..([-]?\d+), y=([-]?\d+)..([-]?\d+)", RegexOptions.Compiled);

    public static Instruction FromString(string input)
    {
        var match = INSTRUCTION_EXPRESSION.Match(input);

        var fromX = int.Parse(match.Groups[1].Value);
        var toX = int.Parse(match.Groups[2].Value);
        var fromY = int.Parse(match.Groups[3].Value);
        var toY = int.Parse(match.Groups[4].Value);

        return new Instruction(fromX, toX, fromY, toY);
    }
}
