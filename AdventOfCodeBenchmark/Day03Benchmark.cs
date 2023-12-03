using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day03Benchmark
    {
        string input;
        readonly int day = 03;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D03_P1() => Day03.Puzzle1(input);

        [Benchmark]
        public string D03_P2() => Day03.Puzzle2(input);
    }
}
