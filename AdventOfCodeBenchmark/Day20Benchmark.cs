using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day20Benchmark
    {
        string input;
        readonly int day = 20;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D20_P1() => Day20.Puzzle1(input);

        [Benchmark]
        public string D20_P2() => Day20.Puzzle2(input);
    }
}
