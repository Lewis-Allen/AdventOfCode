using System.Text.RegularExpressions;

namespace Day15;

public record Ingredient(string Name, int Capacity, int Durability, int Flavour, int Texture, int Calories)
{
    private static readonly Regex INGREDIENT_EXPRESSION = new(@"(\w+): capacity (-?\d+), durability (-?\d+), flavor (-?\d+), texture (-?\d+), calories (-?\d+)", RegexOptions.Compiled);
    public static Ingredient FromString(string line)
    {
        var match = INGREDIENT_EXPRESSION.Match(line);

        if(!match.Success)
        {
            throw new ArgumentException("Could not parse ingredient from string", nameof(line));
        }

        string name = match.Groups[1].Value;
        int capacity = int.Parse(match.Groups[2].Value);
        int durability = int.Parse(match.Groups[3].Value);
        int flavour = int.Parse(match.Groups[4].Value);
        int texture = int.Parse(match.Groups[5].Value);
        int calories = int.Parse(match.Groups[6].Value);

        return new Ingredient(name, capacity, durability, flavour, texture, calories);
    }
}
