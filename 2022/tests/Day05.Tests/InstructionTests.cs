using Xunit;

namespace Day05.Tests;

public class InstructionTests
{
    [Theory]
    [InlineData("move 1 from 2 to 1", 1, 2, 1)]
    [InlineData("move 3 from 1 to 3", 3, 1, 3)]
    [InlineData("move 2 from 2 to 1", 2, 2, 1)]
    [InlineData("move 1 from 1 to 2", 1, 1, 2)]
    public void Should_Parse_Instruction(string input, int number, int source, int destination)
    {
        var exp = new Instruction(number, source, destination);
        var res = Instruction.FromString(input);

        Assert.Equal(exp, res);
    }
}