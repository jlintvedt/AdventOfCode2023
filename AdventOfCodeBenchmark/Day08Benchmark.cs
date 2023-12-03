using AdventOfCode;
using AdventOfCodeTests.InputHelpers;
using BenchmarkDotNet.Attributes;

namespace AdventOfCodeBenchmark
{
    public class Day08Benchmark
    {
        string input;
        readonly int day = 08;

        [Params(100000)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            input = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [Benchmark]
        public string D08_P1() => Day08.Puzzle1(input);

        [Benchmark]
        public string D08_P2() => Day08.Puzzle2(input);
    }
}
