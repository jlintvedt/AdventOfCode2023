using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/5
    /// </summary>
    public class Day05
    {
        public class SeedPlanting
        {
            public List<long> Seeds = new List<long>();
            public List<Mapping> Maps = new List<Mapping>();

            public SeedPlanting(string input)
            {
                var comp = input.Split($"{Environment.NewLine}{Environment.NewLine}");

                foreach (var num in comp[0][7..].Split(' '))
                    Seeds.Add(long.Parse(num));

                for (int i = 1; i < comp.Length; i++)
                    Maps.Add(new Mapping(comp[i]));
            }

            public long FindLowestLocationNumber()
            {
                var lowest = long.MaxValue;
                foreach (var seed in Seeds)
                {
                    var dest = GetDestinationOfSeed(seed);
                    lowest = lowest < dest ? lowest : dest;
                }

                return lowest;
            }

            public long FindLowestLocationNumberWithSeedRanges()
            {
                var lowest = long.MaxValue;
                for (int i = 0; i < Seeds.Count; i+=2)
                {
                    var seedStart = Seeds[i];
                    var seedRange = Seeds[i + 1];
                    for (int j = 0; j < seedRange; j++)
                    {
                        var dest = GetDestinationOfSeed(seedStart + j);
                        lowest = lowest < dest ? lowest : dest;
                    }
                }

                return lowest;
            }

            private long GetDestinationOfSeed(long seed)
            {
                foreach (var map in Maps)
                    seed = map.GetMapping(seed);

                return seed;
            }


            public class Mapping
            {
                public string Type;
                public List<Converter> Converters = new List<Converter>();

                public Mapping(string input)
                {
                    var comp = input.Split(Environment.NewLine);
                    Type = comp[0].Split(' ')[0];

                    for (int i = 1; i < comp.Length; i++)
                    {
                        var raw = comp[i].Split(' ');
                        Converters.Add(new Converter(long.Parse(raw[1]), long.Parse(raw[0]), long.Parse(raw[2])));
                    }

                    //Converters.Sort((x, y) => x.DestinationStart.CompareTo(y.DestinationStart));
                }

                public long GetMapping(long source)
                {
                    foreach (var conv in Converters)
                        if (conv.TryConvert(source, out long newValue))
                            return newValue;

                    return source;
                }
            }

            public class Converter
            {
                public long SourceStart, DestinationStart, Range;

                public Converter(long sourceStart, long destinationStart, long range)
                {
                    SourceStart = sourceStart;
                    DestinationStart = destinationStart;
                    Range = range;
                }

                public bool TryConvert(long source, out long destination)
                {
                    if (source >= SourceStart && source < SourceStart + Range)
                    {
                        destination = DestinationStart + (source - SourceStart);
                        return true;
                    }

                    destination = 0;
                    return false;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var sp = new SeedPlanting(input);
            return sp.FindLowestLocationNumber().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var sp = new SeedPlanting(input);
            return sp.FindLowestLocationNumberWithSeedRanges().ToString();
        }
    }
}
