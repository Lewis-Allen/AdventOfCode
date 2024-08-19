using BenchmarkDotNet.Attributes;

namespace Day02.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private string[] lines = [];

    [GlobalSetup]
    public void Setup() => lines = File.ReadAllLines("input.txt");

    [Benchmark]
    public int TotalOfPossibleIDs()
    {
        return Game.TotalOfPossibleIDs(lines, 12, 13, 14);
    }

    [Benchmark]
    public int SumOfPowers()
    {
        return Game.GetPowerTotal(lines);
    }
}

