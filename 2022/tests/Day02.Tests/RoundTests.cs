using Xunit;

namespace Day02.Tests;

public class RoundTests
{
    [Fact]
    public void Should_Create_Round_Object()
    {
        var input1 = "A Y";
        var input2 = "B X";
        var input3 = "C Z";

        var res1 = new Round(Move.Paper, Move.Rock);
        var res2 = new Round(Move.Rock, Move.Paper);
        var res3 = new Round(Move.Scissors, Move.Scissors);

        Assert.Equal(res1, Round.FromString(input1));
        Assert.Equal(res2, Round.FromString(input2));
        Assert.Equal(res3, Round.FromString(input3));
    }

    [Fact]
    public void Should_Create_Round_Object_With_Result()
    {
        var input1 = "A Y";
        var input2 = "B X";
        var input3 = "C Z";

        var res1 = new Round(Move.Rock, Move.Rock);
        var res2 = new Round(Move.Rock, Move.Paper);
        var res3 = new Round(Move.Rock, Move.Scissors);

        Assert.Equal(res1, Round.FromStringWithResult(input1));
        Assert.Equal(res2, Round.FromStringWithResult(input2));
        Assert.Equal(res3, Round.FromStringWithResult(input3));
    }

    [Fact]
    public void Should_Calculate_Correct_Score()
    {
        var round1 = new Round(Move.Paper, Move.Rock);
        var round2 = new Round(Move.Rock, Move.Paper);
        var round3 = new Round(Move.Scissors, Move.Scissors);

        Assert.Equal(8, Round.GetScore(round1.You, round1.Opponent));
        Assert.Equal(1, Round.GetScore(round2.You, round2.Opponent));
        Assert.Equal(6, Round.GetScore(round3.You, round3.Opponent));
    }
}
