using Day04;

var lines = File.ReadAllLines("input.txt");

var score = lines.Select(l => Card.FromString(l).GetCardScore()).Sum();

Console.WriteLine($"The total score of all the cards is {score}");

var scratchcards = Card.GetTotalScratchCards(lines.Select(Card.FromString).ToArray());

Console.WriteLine($"The total number of scratchcards with the updated rules is {scratchcards}.");