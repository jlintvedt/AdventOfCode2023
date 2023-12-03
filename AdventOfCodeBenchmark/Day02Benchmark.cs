using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day02Benchmark
    {
        string input;
        readonly int day = 02;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D02_P1() => Day02.Puzzle1(input);

        [Benchmark]
        public string D02_P2() => Day02.Puzzle2(input);
    }
}
