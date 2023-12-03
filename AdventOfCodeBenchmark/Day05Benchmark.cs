using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day05Benchmark
    {
        string input;
        readonly int day = 05;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D05_P1() => Day05.Puzzle1(input);

        [Benchmark]
        public string D05_P2() => Day05.Puzzle2(input);
    }
}
