namespace Day03.Tests;

public class EngineParserTests
{
    private char[][] Input = [['4','6','7','.','.','1','1','4','.','.'],
                              ['.','.','.','*','.','.','.','.','.','.'],
                              ['.','.','3','5','.','.','6','3','3','.'],
                              ['.','.','.','.','.','.','#','.','.','.'],
                              ['6','1','7','*','.','.','.','.','.','.'],
                              ['.','.','.','.','.','+','.','5','8','.'],
                              ['.','.','5','9','2','.','.','.','.','.'],
                              ['.','.','.','.','.','.','7','5','5','.'],
                              ['.','.','.','$','.','*','.','.','.','.'],
                              ['.','6','6','4','.','5','9','8','.','.']];


    [Fact]
    public void ShouldGetPartNumbers()
    {
        List<int> expected =
        [
            467,
            35,
            633,
            617,
            592,
            755,
            664,
            598
        ];

        var result = EngineParser.GetPartNumbers(Input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGetSumOfPartNumbers()
    {
        var expected = 4361;
        var result = EngineParser.GetSumOfPartNumbers(Input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGetGearRatios()
    {
        List<int> expected =
        [
            16345,
            451490
        ];
        var result = EngineParser.GetGearRatios(Input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGetSumOfGearRatios()
    {
        var expected = 467835;
        var result = EngineParser.GetSumOfGearRatios(Input);

        Assert.Equal(expected, result);
    }
}