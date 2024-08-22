using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day03.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private char[][] Input = [];

    [GlobalSetup]
    public void Setup() => Input = File.ReadAllLines("input.txt")
        .Select(l => l.ToCharArray())
        .ToArray();

    [Benchmark]
    public int TotalOfPossibleIDs()
    {
        return EngineParser.GetSumOfPartNumbers(Input);
    }

    [Benchmark]
    public int SumOfPowers()
    {
        return EngineParser.GetSumOfGearRatios(Input);
    }
}
