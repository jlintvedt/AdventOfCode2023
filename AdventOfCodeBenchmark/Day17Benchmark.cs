using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day17Benchmark
    {
        string input;
        readonly int day = 17;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D17_P1() => Day17.Puzzle1(input);

        [Benchmark]
        public string D17_P2() => Day17.Puzzle2(input);
    }
}
