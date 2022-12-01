using Day01;

var lines = File.ReadAllLines("Inputs/1.txt")
    .ToArray();

var max = CalorieCalculator.GetMaxCalories(lines);

Console.WriteLine($"The elf carrying the highest amount of calories is carrying {max}.");

var total = CalorieCalculator.GetTotalOfTopThree(lines);

Console.WriteLine($"The total calories carried by the top three elves is {total}.");