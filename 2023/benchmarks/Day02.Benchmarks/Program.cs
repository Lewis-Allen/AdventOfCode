using BenchmarkDotNet.Running;
using Day02.Benchmarks;

var summary = BenchmarkRunner.Run<Benchmarks>();