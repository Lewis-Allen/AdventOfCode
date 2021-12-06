using Day16;

var sues = File.ReadAllLines("Inputs/16.txt")
    .Select(Sue.FromString)
    .ToList();

var ticket = new string[]
{
    "children: 3",
    "cats: 7",
    "samoyeds: 2",
    "pomeranians: 3",
    "akitas: 0",
    "vizslas: 0",
    "goldfish: 5",
    "trees: 3",
    "cars: 2",
    "perfumes: 1"
};

var sue = SueFinder.FindSue(ticket, sues);

Console.WriteLine($"The sue who got you the gift is number {sue.Id}");

sue = SueFinder.FindSueWithRanges(ticket, sues);

Console.WriteLine($"Wait - The sue who actually got you the gift is number {sue.Id}");
