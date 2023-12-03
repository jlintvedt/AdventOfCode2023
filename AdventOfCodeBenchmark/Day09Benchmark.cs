using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day09Benchmark
    {
        string input;
        readonly int day = 09;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D09_P1() => Day09.Puzzle1(input);

        [Benchmark]
        public string D09_P2() => Day09.Puzzle2(input);
    }
}
