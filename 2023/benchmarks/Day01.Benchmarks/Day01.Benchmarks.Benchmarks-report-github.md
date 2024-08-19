```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.4780/22H2/2022Update)
Intel Core i7-7700 CPU 3.60GHz (Kaby Lake), 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.400
  [Host]     : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.8 (8.0.824.36612), X64 RyuJIT AVX2


```
| Method                  | Mean      | Error     | StdDev    | Median    | Gen0     | Allocated |
|------------------------ |----------:|----------:|----------:|----------:|---------:|----------:|
| GetCalibrationValue     |  46.12 μs |  0.918 μs |  1.346 μs |  45.61 μs |   7.6294 |  31.28 KB |
| GetRealCalibrationValue | 630.14 μs | 12.456 μs | 20.812 μs | 619.04 μs | 202.1484 | 826.94 KB |
