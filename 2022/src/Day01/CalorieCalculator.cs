namespace Day01;

public class CalorieCalculator
{
    public static int GetMaxCalories(string[] calories)
    {
        int current = 0;
        int max = 0;
        foreach(var line in calories)
        {
            if (string.IsNullOrEmpty(line))
            {
                current = 0;
            }
            else
            {
                current += int.Parse(line);
                if (current > max)
                {
                    max = current;
                }
            }
        }

        return max;
    }

    public static int GetTotalOfTopThree(string[] calories)
    {
        var totals = new List<int>();

        int current = 0;
        foreach (var line in calories)
        {
            if (string.IsNullOrEmpty(line))
            {
                totals.Add(current);
                current = 0;
            }
            else
            {
                current += int.Parse(line);
            }
        }
        totals.Add(current);

        var result = totals.OrderByDescending(x => x).Take(3).Sum();

        return result;
    }
}
