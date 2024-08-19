using BenchmarkDotNet.Running;
using Day01.Benchmarks;

var summary = BenchmarkRunner.Run<Benchmarks>();