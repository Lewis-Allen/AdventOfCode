using Xunit;

namespace Day09.Tests;

public class HeightmapCalculatorTests
{
    [Fact]
    public void Should_Find_Sum_Of_Risk()
    {
        var lineLength = 10;
        var input = new int[]
        {
            2,1,9,9,9,4,3,2,1,0,
            3,9,8,7,8,9,4,9,2,1,
            9,8,5,6,7,8,9,8,9,2,
            8,7,6,7,8,9,6,7,8,9,
            9,8,9,9,9,6,5,6,7,8
        };

        var result = HeightmapCalculator.FindSumOfRisk(input, lineLength);

        Assert.Equal(15, result);
    }

    [Fact]
    public void Should_Find_Sum_Of_Largest_Basins()
    {
        var lineLength = 10;
        var input = new int[]
        {
            2,1,9,9,9,4,3,2,1,0,
            3,9,8,7,8,9,4,9,2,1,
            9,8,5,6,7,8,9,8,9,2,
            8,7,6,7,8,9,6,7,8,9,
            9,8,9,9,9,6,5,6,7,8
        };

        var result = HeightmapCalculator.FindSumOfLargestBasins(input, lineLength);

        Assert.Equal(1134, result);
    }
}
