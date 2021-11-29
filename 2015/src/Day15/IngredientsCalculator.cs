namespace Day15;

public class IngredientsCalculator
{
    public static long FindHighestTotal(Ingredient[] ingredients)
    {
        // This works but really need to think up a better solution here...

        long max = 0;

        for (int a = 0; a <= 100; a++)
        {
            for (int b = 0; b <= 100; b++)
            {
                for (int c = 0; c <= 100; c++)
                {
                    for (int d = 0; d <= 100; d++)
                    {
                        if (a + b + c + d != 100)
                            continue;

                        int capacity = (a * ingredients[0].Capacity) + (b * ingredients[1].Capacity) + (c * ingredients[2].Capacity) + (d * ingredients[3].Capacity);
                        int durability = (a * ingredients[0].Durability) + (b * ingredients[1].Durability) + (c * ingredients[2].Durability) + (d * ingredients[3].Durability);
                        int flavour = (a * ingredients[0].Flavour) + (b * ingredients[1].Flavour) + (c * ingredients[2].Flavour) + (d * ingredients[3].Flavour);
                        int texture = (a * ingredients[0].Texture) + (b * ingredients[1].Texture) + (c * ingredients[2].Texture) + (d * ingredients[3].Texture);

                        long result = Math.Max(0, capacity) * Math.Max(durability, 0) * Math.Max(flavour, 0) * Math.Max(texture, 0);

                        if (result > max)
                        {
                            max = result;
                        }
                    }
                }
            }
        }

        return max;
    }

    public static long FindHighestTotalWith500Cals(Ingredient[] ingredients)
    {
        long max = 0;

        for (int a = 0; a <= 100; a++)
        {
            for (int b = 0; b <= 100; b++)
            {
                for (int c = 0; c <= 100; c++)
                {
                    for (int d = 0; d <= 100; d++)
                    {
                        if (a + b + c + d != 100)
                            continue;

                        int calories = (a * ingredients[0].Calories) + (b * ingredients[1].Calories) + (c * ingredients[2].Calories) + (d * ingredients[3].Calories);

                        if (calories != 500)
                            continue;

                        int capacity = (a * ingredients[0].Capacity) + (b * ingredients[1].Capacity) + (c * ingredients[2].Capacity) + (d * ingredients[3].Capacity);
                        int durability = (a * ingredients[0].Durability) + (b * ingredients[1].Durability) + (c * ingredients[2].Durability) + (d * ingredients[3].Durability);
                        int flavour = (a * ingredients[0].Flavour) + (b * ingredients[1].Flavour) + (c * ingredients[2].Flavour) + (d * ingredients[3].Flavour);
                        int texture = (a * ingredients[0].Texture) + (b * ingredients[1].Texture) + (c * ingredients[2].Texture) + (d * ingredients[3].Texture);

                        long result = Math.Max(0, capacity) * Math.Max(durability, 0) * Math.Max(flavour, 0) * Math.Max(texture, 0);

                        if (result > max)
                        {
                            max = result;
                        }
                    }
                }
            }
        }

        return max;
    }
}
