using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day01Benchmark
    {
        string input;
        readonly int day = 01;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D01_P1() => Day01.Puzzle1(input);

        [Benchmark]
        public string D01_P2() => Day01.Puzzle2(input);
    }
}
