```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method             | Mean     | Error   | StdDev   | Gen0     | Gen1   | Allocated  |
|------------------- |---------:|--------:|---------:|---------:|-------:|-----------:|
| TotalOfPossibleIDs | 137.0 μs | 1.51 μs |  1.34 μs |  11.7188 |      - |   48.58 KB |
| SumOfPowers        | 405.8 μs | 8.03 μs | 13.63 μs | 286.1328 | 0.4883 | 1168.67 KB |
