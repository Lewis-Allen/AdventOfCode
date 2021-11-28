using Xunit;

namespace Day14.Tests;

public class ReindeerTests
{

    [Theory]
    [InlineData("Comet", 14, 10, 127, 14, 1)]
    [InlineData("Comet", 14, 10, 127, 140, 10)]
    [InlineData("Comet", 14, 10, 127, 140, 11)]
    [InlineData("Comet", 14, 10, 127, 140, 12)]
    [InlineData("Comet", 14, 10, 127, 1120, 1000)]
    [InlineData("Dancer", 16, 11, 162, 16, 1)]
    [InlineData("Dancer", 16, 11, 162, 160, 10)]
    [InlineData("Dancer", 16, 11, 162, 176, 11)]
    [InlineData("Dancer", 16, 11, 162, 176, 12)]
    [InlineData("Dancer", 16, 11, 162, 1056, 1000)]
    public void Reindeer_Should_Travel_X_Distance_In_Y_Seconds(string name, int speed, int stamina, int restTime, int expectedDistance, int seconds)
    {
        var reindeer = new Reindeer(name, speed, stamina, restTime);

        var result = reindeer.GetDistanceTravelledAfterSecondsFromStart(seconds);

        Assert.Equal(expectedDistance, result);
    }

    [Theory]
    [InlineData("Comet", 14, 10, 127, 14, 1)]
    [InlineData("Comet", 14, 10, 127, 140, 10)]
    [InlineData("Comet", 14, 10, 127, 140, 11)]
    [InlineData("Comet", 14, 10, 127, 140, 12)]
    [InlineData("Comet", 14, 10, 127, 1120, 1000)]
    [InlineData("Dancer", 16, 11, 162, 16, 1)]
    [InlineData("Dancer", 16, 11, 162, 160, 10)]
    [InlineData("Dancer", 16, 11, 162, 176, 11)]
    [InlineData("Dancer", 16, 11, 162, 176, 12)]
    [InlineData("Dancer", 16, 11, 162, 1056, 1000)]
    public void Reindeer_Should_Travel_X_Distance_In_Y_Seconds_In_Second_Intervals(string name, int speed, int stamina, int restTime, int expectedDistance, int seconds)
    {
        var reindeer = new Reindeer(name, speed, stamina, restTime);

        for(int i = 0; i < seconds; i++)
        {
            reindeer.Travel(1);
        }

        var result = reindeer.DistanceTravelled;

        Assert.Equal(expectedDistance, result);
    }
}
