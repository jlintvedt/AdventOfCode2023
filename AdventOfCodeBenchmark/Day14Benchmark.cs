using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day14Benchmark
    {
        string input;
        readonly int day = 14;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D14_P1() => Day14.Puzzle1(input);

        [Benchmark]
        public string D14_P2() => Day14.Puzzle2(input);
    }
}
