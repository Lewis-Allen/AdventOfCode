namespace Day17;

public class EggnogCombinationsFinder
{
    public static int GetNoOfCombinations(List<Container> containers, int litres) 
        => GetCombinations(containers, litres).Count;

    public static int GetNoOfMinimumCombinations(List<Container> containers, int litres)
        => GetCombinations(containers, litres)
            .GroupBy(c => c.Count)
            .MinBy(c => c.Key)
            .Count();

    private static List<List<Container>> GetCombinations(List<Container> containers, int litres)
    {
        var combos = new List<List<Container>>();
        FindCombos(containers, litres, new List<Container>(), combos);

        return combos.Select(s => s.OrderBy(x => x.Id).ToList())
            .Distinct(new ContainerComparer())
            .ToList();
    }

    private static void FindCombos(List<Container> containers, int litres, List<Container> partition, List<List<Container>> validCombos)
    {
        var sum = partition.Sum(c => c.Value);

        if (sum == litres)
        {
            validCombos.Add(partition);
        }

        if (sum >= litres)
            return;

        for(int i = 0; i < containers.Count; i++)
        {
            var remaining = new List<Container>();
            for(int j = i + 1; j < containers.Count; j++)
            {
                remaining.Add(containers[j]);
            }

            var currentPartition = new List<Container>(partition)
            {
                containers[i]
            };

            FindCombos(remaining, litres, currentPartition, validCombos);
        }
    }
}
