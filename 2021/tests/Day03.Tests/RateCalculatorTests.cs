using Xunit;

namespace Day03.Tests;

public class RateCalculatorTests
{
    [Fact]
    public void Should_Get_Power_Consumption()
    {
        string[] binary = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var result = RateCalculator.GetPowerConsumption(binary);

        Assert.Equal(198, result);
    }

    [Fact]
    public void Should_Get_Life_Support_Rating()
    {
        string[] binary = new string[]
        {
            "00100",
            "11110",
            "10110",
            "10111",
            "10101",
            "01111",
            "00111",
            "11100",
            "10000",
            "11001",
            "00010",
            "01010"
        };

        var result = RateCalculator.GetLifeSupportRating(binary);

        Assert.Equal(230, result);
    }
}
