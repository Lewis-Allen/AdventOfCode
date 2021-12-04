using Day04;

var lines = File.ReadAllLines("Inputs/4.txt");

var parsedNumbers = BingoCalculator.ParseNumbers(lines[0]);
var parsedBoards = BingoCalculator.ParseBoards(lines.Skip(2).ToArray());

var winningScore = BingoCalculator.GetWinningScore(parsedBoards.ToArray(), parsedNumbers);

Console.WriteLine($"The score of the first winning board is {winningScore}.");

var lastWinningScore = BingoCalculator.GetLastWinningScore(parsedBoards, parsedNumbers);

Console.WriteLine($"The score of the last winning board is {lastWinningScore}.");