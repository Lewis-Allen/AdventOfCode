using Xunit;

namespace Day04.Tests;

public class BingoCalculatorTests
{
    [Fact]
    public void Should_Get_Winning_Score()
    {
        int[] numbers = new int[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

        var boards = new int[3][];
        boards[0] = new int[25] {
            22, 13, 17, 11,  0,
             8,  2, 23,  4, 24,
            21,  9, 14, 16,  7,
             6, 10,  3, 18,  5,
             1, 12, 20, 15, 19
        };

        boards[1] = new int[25] {
             3, 15,  0,  2, 22,
             9, 18, 13, 17,  5,
            19,  8,  7, 25, 23,
            20, 11, 10, 24,  4,
            14, 21, 16, 12,  6
        };

        boards[2] = new int[25] {
            14, 21, 17, 24,  4,
            10, 16, 15,  9, 19,
            18,  8, 23, 26, 20,
            22, 11, 13,  6,  5,
             2,  0, 12,  3,  7
        };

        var result = BingoCalculator.GetWinningScore(boards, numbers);

        Assert.Equal(4512, result);
    }

    [Fact]
    public void Should_Get_Last_Winning_Score()
    {
        int[] numbers = new int[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };

        var boards = new int[3][];
        boards[0] = new int[25] {
            22, 13, 17, 11,  0,
             8,  2, 23,  4, 24,
            21,  9, 14, 16,  7,
             6, 10,  3, 18,  5,
             1, 12, 20, 15, 19
        };

        boards[1] = new int[25] {
             3, 15,  0,  2, 22,
             9, 18, 13, 17,  5,
            19,  8,  7, 25, 23,
            20, 11, 10, 24,  4,
            14, 21, 16, 12,  6
        };

        boards[2] = new int[25] {
            14, 21, 17, 24,  4,
            10, 16, 15,  9, 19,
            18,  8, 23, 26, 20,
            22, 11, 13,  6,  5,
             2,  0, 12,  3,  7
        };

        var result = BingoCalculator.GetLastWinningScore(boards, numbers);

        Assert.Equal(1924, result);
    }

    [Fact]
    public void Should_Parse_Into_Calling_Numbers()
    {
        var input = "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1";

        var expected = new int[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 };
        var result = BingoCalculator.ParseNumbers(input);

        Assert.Equal(expected, result);
    }

    [Fact]
    public void Should_Parse_Board_Into_Int_Array()
    {
        var lines = new string[] {
            "12 79 33 36 97",
            "82 38 77 61 84",
            "55 74 21 65 39",
            "54 56 95 50  2",
            "45 68 31 94 14",
            "              ",
            "95 26 80 25 62",
            "79 91 70 76 61",
            "98 97 17 75 23",
            "71 30 21 52 29",
            "20 54 32 12 31",
            "              ",
            "35 31 86 36 52",
            "18 50 79 60 67",
            "98  3 51 46 25",
            " 4 61 55 87 70",
            "94 39 68 27 14"
        };

        var expected = new int[3][];
        expected[0] = new int[25] {
            12, 79, 33, 36, 97,
            82, 38, 77, 61, 84,
            55, 74, 21, 65, 39,
            54, 56, 95, 50,  2,
            45, 68, 31, 94, 14
        };

        expected[1] = new int[25] {
            95, 26, 80, 25, 62,
            79, 91, 70, 76, 61,
            98, 97, 17, 75, 23,
            71, 30, 21, 52, 29,
            20, 54, 32, 12, 31
        };

        expected[2] = new int[25] {
            35, 31, 86, 36, 52,
            18, 50, 79, 60, 67,
            98,  3, 51, 46, 25,
             4, 61, 55, 87, 70,
            94, 39, 68, 27, 14
        };

        var result = BingoCalculator.ParseBoards(lines);

        Assert.Equal(expected, result);
    }
}
