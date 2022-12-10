using Xunit;

namespace Day05.Tests;

public class StackHolderTests
{
    [Fact]
    public void Should_Get_Correct_Message_9000()
    {
        var instructions = new Instruction[]
        {
            new(1,2,1),
            new(3,1,3),
            new(2,2,1),
            new(1,1,2)
        };

        var stackLines = new string[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 "
        };

        var stackHolder = new StackHolder(stackLines);
        foreach(var instruction in instructions)
        {
            stackHolder.ApplyInstruction9000(instruction);
        }

        var exp = "CMZ";
        var res = stackHolder.GetMessage();
        Assert.Equal(exp, res);
    }

    [Fact]
    public void Should_Get_Correct_Message_9001()
    {
        var instructions = new Instruction[]
        {
            new(1,2,1),
            new(3,1,3),
            new(2,2,1),
            new(1,1,2)
        };

        var stackLines = new string[]
        {
            "    [D]    ",
            "[N] [C]    ",
            "[Z] [M] [P]",
            " 1   2   3 "
        };

        var stackHolder = new StackHolder(stackLines);
        foreach (var instruction in instructions)
        {
            stackHolder.ApplyInstruction9001(instruction);
        }

        var exp = "MCD";
        var res = stackHolder.GetMessage();
        Assert.Equal(exp, res);
    }
}
