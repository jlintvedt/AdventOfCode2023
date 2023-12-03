``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
11th Gen Intel Core i9-11950H 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.404
  [Host]     : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT DEBUG
  DefaultJob : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT


```
| Method |      N |     Mean |   Error |  StdDev |
|------- |------- |---------:|--------:|--------:|
| D02_P1 | 100000 | 185.6 μs | 3.62 μs | 3.21 μs |
| D02_P2 | 100000 | 183.8 μs | 3.24 μs | 3.03 μs |
