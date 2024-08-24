```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method               | Mean     | Error   | StdDev  | Median   | Gen0    | Allocated |
|--------------------- |---------:|--------:|--------:|---------:|--------:|----------:|
| TotalCardScore       | 121.6 μs | 2.01 μs | 1.68 μs | 121.2 μs | 34.6680 | 142.45 KB |
| GetTotalScratchCards | 125.1 μs | 2.44 μs | 4.07 μs | 123.0 μs | 36.6211 | 149.69 KB |
