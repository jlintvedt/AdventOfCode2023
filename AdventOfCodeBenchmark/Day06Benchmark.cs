using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day06Benchmark
    {
        string input;
        readonly int day = 06;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D06_P1() => Day06.Puzzle1(input);

        [Benchmark]
        public string D06_P2() => Day06.Puzzle2(input);
    }
}
