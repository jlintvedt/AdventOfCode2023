``` ini

BenchmarkDotNet=v0.13.1, OS=Windows 10.0.22621
11th Gen Intel Core i9-11950H 2.60GHz, 1 CPU, 16 logical and 8 physical cores
.NET SDK=7.0.404
  [Host]     : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT DEBUG
  DefaultJob : .NET Core 3.1.32 (CoreCLR 4.700.22.55902, CoreFX 4.700.22.56512), X64 RyuJIT


```
| Method |      N |      Mean |    Error |   StdDev |
|------- |------- |----------:|---------:|---------:|
| D01_P1 | 100000 |  98.28 μs | 1.952 μs | 2.861 μs |
| D01_P2 | 100000 | 162.23 μs | 3.045 μs | 3.127 μs |
