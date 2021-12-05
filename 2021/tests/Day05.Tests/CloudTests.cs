using Xunit;

namespace Day05.Tests;

public class CloudTests
{
    [Theory]
    [InlineData("0,9 -> 5,9", 0,9,5,9)]
    [InlineData("8,0 -> 0,8", 8,0,0,8)]
    [InlineData("9,4 -> 3,4", 9,4,3,4)]
    [InlineData("2,2 -> 2,1", 2,2,2,1)]
    [InlineData("7,0 -> 7,4", 7,0,7,4)]
    [InlineData("6,4 -> 2,0", 6,4,2,0)]
    [InlineData("0,9 -> 2,9", 0,9,2,9)]
    [InlineData("3,4 -> 1,4", 3,4,1,4)]
    [InlineData("0,0 -> 8,8", 0,0,8,8)]
    [InlineData("5,5 -> 8,2", 5,5,8,2)]
    public void Should_Parse_Cloud_From_String(string input, int x1, int y1, int x2, int y2)
    {
        var expected = new Cloud(x1, y1, x2, y2);

        var result = Cloud.FromString(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Throw_Argument_Exception_When_Parsing_Cloud_With_Bad_String()
    {
        var input = "This string is not a valid cloud";

        Assert.Throws<ArgumentException>(() => Cloud.FromString(input));
    }
}
