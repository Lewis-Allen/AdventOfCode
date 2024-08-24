using Day04;

namespace Day.Tests;

public class CardParserTests
{
    [Theory]
    [InlineData("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53", 1, new int[] { 41, 48, 83, 86, 17 }, new int[] { 83, 86, 6, 31, 17, 9, 48, 53 })]
    [InlineData("Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 2, new int[] { 13, 32, 20, 16, 61 }, new int[] { 61, 30, 68, 82, 17, 32, 24, 19 })]
    [InlineData("Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 3, new int[] { 1, 21, 53, 59, 44 }, new int[] { 69, 82, 63, 72, 16, 21, 14, 1 })]
    [InlineData("Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83", 4, new int[] { 41, 92, 73, 84, 69 }, new int[] { 59, 84, 76, 51, 58, 5, 54, 83 })]
    [InlineData("Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36", 5, new int[] { 87, 83, 26, 28, 32 }, new int[] { 88, 30, 70, 12, 93, 22, 82, 36 })]
    [InlineData("Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11", 6, new int[] { 31, 18, 13, 56, 72 }, new int[] { 74, 77, 10, 23, 35, 67, 36, 11 })]
    public void ShouldParseCardString(string card, int expectedID, int[] expectedWinners, int[] expectedEntries)
    {
        var result = Card.FromString(card);

        Assert.Equal(expectedID, result.ID);
        Assert.Equal(expectedWinners, result.Winners);
        Assert.Equal(expectedEntries, result.Entries);
    }

    [Theory]
    [InlineData(new int[] { 41, 48, 83, 86, 17 }, new int[] { 83, 86, 6, 31, 17, 9, 48, 53 }, 8)]
    [InlineData(new int[] { 13, 32, 20, 16, 61 }, new int[] { 61, 30, 68, 82, 17, 32, 24, 19 }, 2)]
    [InlineData(new int[] { 1, 21, 53, 59, 44 }, new int[] { 69, 82, 63, 72, 16, 21, 14, 1 }, 2)]
    [InlineData(new int[] { 41, 92, 73, 84, 69 }, new int[] { 59, 84, 76, 51, 58, 5, 54, 83 }, 1)]
    [InlineData(new int[] { 87, 83, 26, 28, 32 }, new int[] { 88, 30, 70, 12, 93, 22, 82, 36 }, 0)]
    [InlineData(new int[] { 31, 18, 13, 56, 72 }, new int[] { 74, 77, 10, 23, 35, 67, 36, 11 }, 0)]
    public void ShouldGetCorrectCardScore(int[] winners, int[] entries, int expected)
    {
        var card = new Card()
        {
            ID = 1,
            Winners = winners,
            Entries = entries
        };

        var result = card.GetCardScore();

        Assert.Equal(expected, result);
    }

    [Fact]
    public void ShouldGetTotalScratchCards()
    {
        var cards = new Card[]
        {
            new(){
                ID = 1,
                Winners = [41, 48, 83, 86, 17],
                Entries = [83, 86, 6, 31, 17, 9, 48, 53]
            },
            new(){
                ID = 2,
                Winners = [13, 32, 20, 16, 61],
                Entries = [61, 30, 68, 82, 17, 32, 24, 19]
            },
            new(){
                ID = 3,
                Winners = [1, 21, 53, 59, 44],
                Entries = [69, 82, 63, 72, 16, 21, 14, 1]
            },
            new(){
                ID = 4,
                Winners = [41, 92, 73, 84, 69],
                Entries = [59, 84, 76, 51, 58, 5, 54, 83]
            },
            new(){
                ID = 5,
                Winners = [87, 83, 26, 28, 32],
                Entries = [88, 30, 70, 12, 93, 22, 82, 36]
            },
            new(){
                ID = 5,
                Winners = [31, 18, 13, 56, 72],
                Entries = [74, 77, 10, 23, 35, 67, 36, 11]
            }
        };

        var expected = 30;
        var result = Card.GetTotalScratchCards(cards);

        Assert.Equal(expected, result);
    }
}