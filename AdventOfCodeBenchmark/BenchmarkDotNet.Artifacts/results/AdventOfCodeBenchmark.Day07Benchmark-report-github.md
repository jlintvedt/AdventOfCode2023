``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
11th Gen Intel Core i9-11950H 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.404
  [Host]     : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT DEBUG
  DefaultJob : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT


```
| Method |      N |     Mean |   Error |   StdDev |
|------- |------- |---------:|--------:|---------:|
| D07_P1 | 100000 | 313.2 μs | 6.25 μs |  9.16 μs |
| D07_P2 | 100000 | 312.2 μs | 6.21 μs | 13.23 μs |
