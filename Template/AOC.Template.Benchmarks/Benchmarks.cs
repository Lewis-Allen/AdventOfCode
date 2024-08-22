using BenchmarkDotNet.Attributes;

namespace AOC.Template.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private string[] lines = [];

    [GlobalSetup]
    public void Setup() => lines = File.ReadAllLines("input.txt");

    [Benchmark]
    public int Benchmark()
    {
        throw new NotImplementedException();
    }
}
