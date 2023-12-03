using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day23Benchmark
    {
        string input;
        readonly int day = 23;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D23_P1() => Day23.Puzzle1(input);

        [Benchmark]
        public string D23_P2() => Day23.Puzzle2(input);
    }
}
