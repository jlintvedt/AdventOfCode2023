using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/3
    /// </summary>
    public class Day03
    {
        public class GearRatios
        {
            public Dictionary<(int x, int y), Part> Parts = new Dictionary<(int x, int y), Part>();
            public List<Symbol> Symbols = new List<Symbol>();
            private readonly List<(int x, int y)> Offsets = new List<(int x, int y)>() { (-1, -1), (-1, 0), (-1, 1), (0, -1), (0, 1), (1, -1), (1, 0), (1, 1) };

            public GearRatios(string input)
            {
                var lines = input.Split(Environment.NewLine);

                for (int y = 0; y < lines.Length; y++)
                {
                    var line = lines[y];
                    for (int x = 0; x < lines[y].Length; x++)
                    {
                        var c = line[x];
                        // Part
                        if (c >= 48 && c < 58)
                        {
                            var Part = ExtractPart(line, x);
                            Parts.Add((x, y), Part);
                            if (Part.Number >= 10)
                                Parts.Add((++x, y), Part);
                            if (Part.Number >= 100)
                                Parts.Add((++x, y), Part);
                        }
                        // Symbol
                        else if (c != '.')
                            Symbols.Add(new Symbol(c, (x, y)));
                    }
                }
            }

            public int FindSumOfPartNumbers()
            {
                var sum = 0;
                foreach (var symbol in Symbols)
                    foreach (var offset in Offsets)
                        if (Parts.TryGetValue((symbol.Pos.x + offset.x, symbol.Pos.y + offset.y), out Part part))
                            sum += part.GetNumberOnce();

                return sum;
            }

            public int FindSumOfGearRatios()
            {
                var sum = 0;
                foreach (var symbol in Symbols)
                {
                    if (symbol.Type != '*')
                        continue;

                    var adjecentParts = new HashSet<Part>();
                    foreach (var offset in Offsets)
                        if (Parts.TryGetValue((symbol.Pos.x + offset.x, symbol.Pos.y + offset.y), out Part part))
                            adjecentParts.Add(part);

                    // Check if gear is valid
                    if (adjecentParts.Count == 2)
                    {
                        var gearRatio = 1;
                        foreach (var part in adjecentParts)
                            gearRatio *= part.Number;
                        sum += gearRatio;
                    }
                }

                return sum;
            }

            private Part ExtractPart(string line, int index)
            {
                var number = 0;
                while (index < line.Length)
                {
                    var c = line[index] - 48;
                    if (c < 0 || c > 9)
                        break;
                    number *= 10;
                    number += c;
                    index++;
                }

                return new Part(number);
            }

            public class Symbol
            {
                public readonly char Type;
                public readonly (int x, int y) Pos;

                public Symbol(char type, (int x, int y) pos)
                {
                    Type = type;
                    Pos = pos;
                }
            }

            public class Part
            {
                public readonly int Number;
                private bool alreadyUsed = false;

                public Part(int number)
                {
                    this.Number = number;
                }

                public int GetNumberOnce()
                {
                    if (alreadyUsed)
                        return 0;

                    alreadyUsed = true;
                    return Number;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var gr = new GearRatios(input);
            return gr.FindSumOfPartNumbers().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var gr = new GearRatios(input);
            return gr.FindSumOfGearRatios().ToString();
        }
    }
}
