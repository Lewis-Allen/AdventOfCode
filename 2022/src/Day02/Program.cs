using Day02;

var lines = File.ReadAllLines("Inputs/2.txt");

var totalScore = lines
    .Select(Round.FromString)
    .Sum(r => Round.GetScore(r.You, r.Opponent));

Console.WriteLine($"The total score from the strategy guide is {totalScore}.");

totalScore = lines
    .Select(Round.FromStringWithResult)
    .Sum(r => Round.GetScore(r.You, r.Opponent));

Console.WriteLine($"The total score from following the strategy guide correctly is {totalScore}.");