# AdventOfCode2023

### Running benchmarks
Update reference [BenchmarkRunner.Run<Day**17**Benchmark>(config)](AdventOfCodeBenchmark/Program.cs).

Run without debugger: `ctrl+f5` in VS Code. This stores the benchmark in [results](AdventOfCodeBenchmark\BenchmarkDotNet.Artifacts\results) folder and the [Results](Results.json) file, also updates the table below.

## Runtimes
<!--ResultTableStart-->
|                                |         | Test @3.8GHz<sup>1</sup> | Benchmark<sup>2</sup> |
|--------------------------------|---------|-------------------------:|----------------------:|
| [Day01](AdventOfCode/Day01.cs) | Puzzle1 |                      1ms |                  98μs |
|                                | Puzzle2 |                      1ms |                 162μs |
| [Day02](AdventOfCode/Day02.cs) | Puzzle1 |                      1ms |                 185μs |
|                                | Puzzle2 |                      1ms |                 183μs |
| [Day03](AdventOfCode/Day03.cs) | Puzzle1 |                      1ms |                 438μs |
|                                | Puzzle2 |                      2ms |                 363μs |
| [Day04](AdventOfCode/Day04.cs) | Puzzle1 |                      1ms |                 489μs |
|                                | Puzzle2 |                      1ms |                 489μs |
| [Day05](AdventOfCode/Day05.cs) | Puzzle1 |                     <1ms |                  56μs |
|                                | Puzzle2 |                      33m |                   N/A |
| [Day06](AdventOfCode/Day06.cs) | Puzzle1 |                     <1ms |                   1μs |
|                                | Puzzle2 |                    114ms |                  23ms |
| [Day07](AdventOfCode/Day07.cs) | Puzzle1 |                      1ms |                 313μs |
|                                | Puzzle2 |                      1ms |                 312μs |
<!--ResultTableEnd-->

1) Laptop Intel i9-11950H @ 2.6GHz. Visual Studio Test Explorer
2) Laptop Intel i9-11950H @ 2.6GHz. Using [DotNetBenchmark](https://github.com/dotnet/BenchmarkDotNet).