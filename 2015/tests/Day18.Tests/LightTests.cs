namespace Day18.Tests;

public class LightTests
{
    [Fact]
    public void ShouldParseGridFromLines()
    {
        var lights = @".#.#.#
...##.
#....#
..#...
#.#..#
####..".Split(Environment.NewLine);

        var expected = new bool[][]
        {
            [false, true, false, true, false, true],
            [false, false, false, true, true, false],
            [true, false, false, false, false, true],
            [false, false, true, false, false, false],
            [true, false, true, false, false, true],
            [true, true, true, true, false, false]
        };

        var result = Grid.FromLines(lights);

        Assert.Equal(expected, result.Lights);
    }

    [Fact]
    public void ShouldCorrectlySwitch()
    {
        var lights = new bool[][]
        {
            [false, true, false, true, false, true],
            [false, false, false, true, true, false],
            [true, false, false, false, false, true],
            [false, false, true, false, false, false],
            [true, false, true, false, false, true],
            [true, true, true, true, false, false]
        };

        var expected = new bool[][]
        {
            [false, false, true, true, false, false],
            [false, false, true, true, false, true],
            [false, false, false, true, true, false],
            [false, false, false, false, false, false],
            [true, false, false, false, false, false],
            [true, false, true, true, false, false]
        };

        var grid = new Grid()
        {
            Lights = lights
        };

        grid.Switch();

        Assert.Equal(expected, grid.Lights);
    }

    [Fact]
    public void ShouldReturnNumberOfOnLights()
    {
        var lights = new bool[][]
        {
            [false, true, false, true, false, true],
            [false, false, false, true, true, false],
            [true, false, false, false, false, true],
            [false, false, true, false, false, false],
            [true, false, true, false, false, true],
            [true, true, true, true, false, false]
        };

        var expected = 15;
        var grid = new Grid()
        {
            Lights = lights
        };

        var result = grid.GetOnLights();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldCorrectlySwitchWithStuckLights()
    {
        var lights = new bool[][]
        {
            [true, true, false, true, false, true],
            [false, false, false, true, true, false],
            [true, false, false, false, false, true],
            [false, false, true, false, false, false],
            [true, false, true, false, false, true],
            [true, true, true, true, false, true]
        };

        var expected = new bool[][]
        {
            [true, false, true, true, false, true],
            [true, true, true, true, false, true],
            [false, false, false, true, true, false],
            [false, false, false, false, false, false],
            [true, false, false, false, true, false],
            [true, false, true, true, true, true]
        };

        var grid = new Grid()
        {
            Lights = lights
        };

        grid.SwitchWithStuckLights();

        Assert.Equal(expected, grid.Lights);
    }

    [Fact]
    public void ShouldGetCorrectNumberOfLightsAfterSwitchingFiveTimesWithStuckLights()
    {
        var lights = new bool[][]
        {
            [true, true, false, true, false, true],
            [false, false, false, true, true, false],
            [true, false, false, false, false, true],
            [false, false, true, false, false, false],
            [true, false, true, false, false, true],
            [true, true, true, true, false, true]
        };

        var grid = new Grid()
        {
            Lights = lights
        };

        for(var i = 0; i < 5; i++)
        {
            grid.SwitchWithStuckLights();
        }

        var expected = 17;
        var result = grid.GetOnLights();

        Assert.Equal(expected, result);
    }
}