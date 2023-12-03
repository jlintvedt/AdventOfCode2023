using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day21Benchmark
    {
        string input;
        readonly int day = 21;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D21_P1() => Day21.Puzzle1(input);

        [Benchmark]
        public string D21_P2() => Day21.Puzzle2(input);
    }
}
