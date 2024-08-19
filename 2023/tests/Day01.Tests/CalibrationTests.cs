namespace Day01.Tests;

public class CalibrationTests
{
    [Theory]
    [InlineData("1abc2", 12)]
    [InlineData("pqr3stu8vwx", 38)]
    [InlineData("a1b2c3d4e5f", 15)]
    [InlineData("treb7uchet", 77)]
    public void should_get_calibration_value_from_line(string line, int expected)
    {
        var result = Calibrator.GetCalibrationValue(line);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void should_get_calibration_total()
    {
        string[] lines = [
            "1abc2",
            "pqr3stu8vwx",
            "a1b2c3d4e5f",
            "treb7uchet"
        ];

        var result = Calibrator.GetCalibrationValueTotal(lines);

        Assert.Equal(142, result);
    }

    [Theory]
    [InlineData("two1nine", 29)]
    [InlineData("eightwothree", 83)]
    [InlineData("abcone2threexyz", 13)]
    [InlineData("xtwone3four", 24)]
    [InlineData("4nineeightseven2", 42)]
    [InlineData("zoneight234", 14)]
    [InlineData("7pqrstsixteen", 76)]
    public void should_get_real_calibration_value_from_line(string line, int expected)
    {
        var result = Calibrator.GetRealCalibrationValue(line);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void should_get_real_calibration_total()
    {
        string[] lines = [
            "two1nine",
            "eightwothree",
            "abcone2threexyz",
            "xtwone3four",
            "4nineeightseven2",
            "zoneight234",
            "7pqrstsixteen"
        ];

        var result = Calibrator.GetRealCalibrationValueTotal(lines);

        Assert.Equal(281, result);
    }
}