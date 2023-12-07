``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
11th Gen Intel Core i9-11950H 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.404
  [Host]     : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT DEBUG
  DefaultJob : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT


```
| Method |      N |          Mean |       Error |      StdDev |
|------- |------- |--------------:|------------:|------------:|
| D06_P1 | 100000 |      1.287 μs |   0.0232 μs |   0.0217 μs |
| D06_P2 | 100000 | 23,796.581 μs | 402.2539 μs | 494.0039 μs |
