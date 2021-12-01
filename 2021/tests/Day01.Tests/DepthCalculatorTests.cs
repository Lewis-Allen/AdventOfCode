using Xunit;

namespace Day01.Tests;

public class DepthCalculatorTests
{
    [Fact]
    public void Should_Count_Amount_Of_Depth_Increases()
    {
        int[] input = new[] {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

        var result = DepthCalculator.GetDepthIncreasesCount(input);

        Assert.Equal(7, result);
    }

    [Fact]
    public void Should_Count_Amount_Of_Depth_Increases_With_Measuring_Window()
    {
        int[] input = new[] {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

        var result = DepthCalculator.GetDepthIncreasesCountWithMeasuringWindow(input);

        Assert.Equal(5, result);
    }
}
