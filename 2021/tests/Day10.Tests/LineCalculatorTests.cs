using Xunit;

namespace Day10.Tests;

public class LineCalculatorTests
{
    [Theory]
    [InlineData("{([(<{}[<>[]}>{[]{[(<()>", '}')]
    [InlineData("[{[{({}]{}}([{[{{{}}([]", ']')]
    public void Should_Show_As_Corrupt(string line, char expected)
    {
        var result = LineCalculator.AnalyseForCorruption(line.ToCharArray());

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Get_Score_For_Corrupt_Lines()
    {
        var lines = new string[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "{([(<{}[<>[]}>{[]{[(<()>",
            "(((({<>}<{<{<>}{[]{[]{}",
            "[[<[([]))<([[{}[[()]]]",
            "[{[{({}]{}}([{[{{{}}([]",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "[<(<(<(<{}))><([]([]()",
            "<{([([[(<>()){}]>(<<{{",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        var result = LineCalculator.CalculateScoreForCorrupt(lines);

        Assert.Equal(26397, result);
    }

    [Fact]
    public void Should_Get_String_To_Complete()
    {
        // The test explorer seems to break when using [Theory] with [InlineData] containing brackets.
        (string Line, string Expected)[] tests = new (string, string)[]
        {
            ("[({(<(())[]>[[{[]{<()<>>", "}}]])})]"),
            ("[(()[<>])]({[<{<<[]>>(", ")}>]})"),
            ("(((({<>}<{<{<>}{[]{[]{}", "}}>}>))))"),
            ("{<[[]]>}<{[{[{[]{()[[[]", "]]}}]}]}>"),
            ("<{([{{}}[<[[[<>{}]]]>[]]", "])}>")
        };

        foreach(var (Line, Expected) in tests)
        {
            var result = LineCalculator.GetCompletingString(Line.ToCharArray());
            Assert.Equal(Expected, result);
        }
    }

    [Fact]
    public void Should_Get_Score_For_Incomplete_Lines()
    {
        var lines = new string[]
        {
            "[({(<(())[]>[[{[]{<()<>>",
            "[(()[<>])]({[<{<<[]>>(",
            "(((({<>}<{<{<>}{[]{[]{}",
            "{<[[]]>}<{[{[{[]{()[[[]",
            "<{([{{}}[<[[[<>{}]]]>[]]"
        };

        var result = LineCalculator.CalculateScoreForIncomplete(lines);

        Assert.Equal(288957, result);
    }
}
