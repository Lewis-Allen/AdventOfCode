using BenchmarkDotNet.Attributes;

namespace Day04.Benchmarks;

[MemoryDiagnoser]
public class Benchmarks
{
    private Card[] cards = [];

    [GlobalSetup]
    public void Setup() => cards = File.ReadAllLines("input.txt").Select(Card.FromString).ToArray();

    [Benchmark]
    public int TotalCardScore()
    {
        return cards.Select(c => c.GetCardScore()).Sum();
    }

    [Benchmark]
    public int GetTotalScratchCards()
    {
        return Card.GetTotalScratchCards(cards);
    }
}
