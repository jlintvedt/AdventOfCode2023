using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day19Benchmark
    {
        string input;
        readonly int day = 19;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D19_P1() => Day19.Puzzle1(input);

        [Benchmark]
        public string D19_P2() => Day19.Puzzle2(input);
    }
}
