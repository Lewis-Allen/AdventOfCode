using Day15;

var ingredients = File.ReadAllLines("Inputs/15.txt")
    .Select(x => Ingredient.FromString(x))
    .ToArray();

// Part One
var max = IngredientsCalculator.FindHighestTotal(ingredients);

Console.WriteLine($"The highest total found is {max}.");

max = IngredientsCalculator.FindHighestTotalWith500Cals(ingredients);

Console.WriteLine($"The highest total found with 500 calories is {max}.");