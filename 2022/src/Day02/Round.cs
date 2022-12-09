namespace Day02;

public enum Move
{
    Rock,
    Paper,
    Scissors
}

public record Round(Move You, Move Opponent)
{
    public static Round FromString(string input)
    {
        var moves = input.Split(' ');

        Move opponent = moves[0] switch
        {
            "A" => Move.Rock,
            "B" => Move.Paper,
            "C" => Move.Scissors,
            _ => throw new NotSupportedException()
        };

        Move you = moves[1] switch
        {
            "X" => Move.Rock,
            "Y" => Move.Paper,
            "Z" => Move.Scissors,
            _ => throw new NotSupportedException()
        };

        return new Round(you, opponent);
    }

    public static Round FromStringWithResult(string input)
    {
        var moves = input.Split(' ');

        Move opponent = moves[0] switch
        {
            "A" => Move.Rock,
            "B" => Move.Paper,
            "C" => Move.Scissors,
            _ => throw new NotSupportedException()
        };

        Move you = (opponent, moves[1]) switch
        {
            (Move.Rock, "X") => Move.Scissors,
            (Move.Rock, "Y") => Move.Rock,
            (Move.Rock, "Z") => Move.Paper,
            (Move.Paper, "X") => Move.Rock,
            (Move.Paper, "Y") => Move.Paper,
            (Move.Paper, "Z") => Move.Scissors,
            (Move.Scissors, "X") => Move.Paper,
            (Move.Scissors, "Y") => Move.Scissors,
            (Move.Scissors, "Z") => Move.Rock,
            _ => throw new NotSupportedException()
        };

        return new Round(you, opponent);
    }

    public static int GetScore(Move You, Move Opponent) => (You, Opponent) switch
    {
        (Move.Rock, Move.Rock) => 4, /* 1 + 3 Draw*/
        (Move.Rock, Move.Paper) => 1, /* 1 + 0 Lose */
        (Move.Rock, Move.Scissors) => 7, /* 1 + 6 Win */
        (Move.Paper, Move.Rock) => 8, /* 2 + 6 Win */
        (Move.Paper, Move.Paper) => 5, /* 2 + 3 Draw */
        (Move.Paper, Move.Scissors) => 2, /* 2 + 0 Lose */
        (Move.Scissors, Move.Rock) => 3, /* 3 + 0 Lose */
        (Move.Scissors, Move.Paper) => 9, /* 3 + 6 Lose */
        (Move.Scissors, Move.Scissors) => 6, /* 3 + 3 Lose */
        _ => throw new NotSupportedException()
    };
}
