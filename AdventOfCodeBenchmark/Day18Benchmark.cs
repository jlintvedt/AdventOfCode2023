using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day18Benchmark
    {
        string input;
        readonly int day = 18;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D18_P1() => Day18.Puzzle1(input);

        [Benchmark]
        public string D18_P2() => Day18.Puzzle2(input);
    }
}
