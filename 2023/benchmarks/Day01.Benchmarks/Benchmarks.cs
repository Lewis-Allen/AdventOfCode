using BenchmarkDotNet.Attributes;

namespace Day01.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private string[] lines = [];

    [GlobalSetup]
    public void Setup() => lines = File.ReadAllLines("input.txt");

    [Benchmark]
    public int GetCalibrationValue()
    {
        return Calibrator.GetCalibrationValueTotal(lines);
    }

    [Benchmark]
    public int GetRealCalibrationValue()
    {
        return Calibrator.GetRealCalibrationValueTotal(lines);
    }
} 
