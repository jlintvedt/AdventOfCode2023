using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/2
    /// </summary>
    public class Day02
    {
        public class CubeConundrum
        {
            public List<Game> Games = new List<Game>();

            public CubeConundrum(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    Games.Add(new Game(line));
                }
            }

            public int FindSumOfPossibleGames()
            {
                var maxRed = 12;
                var maxGreen = 13;
                var maxBlue = 14;
                var sum = 0;

                foreach (var game in Games)
                {
                    if (game.IsPossible(maxRed, maxGreen, maxBlue))
                        sum += game.Id;
                }

                return sum;
            }

            public int FindSumOfPowerOfSets()
            {
                var sum = 0;
                foreach (var game in Games)
                    sum += game.FindPowerOfSet();

                return sum;
            }

            public class Game
            {
                public readonly int Id;
                private readonly List<Reveal> Reveals = new List<Reveal>();

                public Game(string input)
                {
                    var comp = input.Split(':');
                    Id = int.Parse(comp[0][5..]);
                    foreach (var rev in comp[1].Split(';'))
                        Reveals.Add(new Reveal(rev));
                }

                public bool IsPossible(int maxRed, int maxGreen, int maxBlue)
                {
                    foreach (var reveal in Reveals)
                    {
                        if (reveal.Red > maxRed || reveal.Green > maxGreen || reveal.Blue > maxBlue)
                            return false;
                    }

                    return true;
                }

                public int FindPowerOfSet()
                {
                    int red = 0, green = 0, blue = 0;
                    foreach (var reveal in Reveals)
                    {
                        red = reveal.Red > red ? reveal.Red : red;
                        green = reveal.Green > green ? reveal.Green : green;
                        blue = reveal.Blue > blue ? reveal.Blue : blue;
                    }

                    return red * green * blue;
                }
            }

            public class Reveal
            {
                public int Red;
                public int Green;
                public int Blue;

                public Reveal(string input)
                {
                    foreach (var type in input.Split(','))
                    {
                        var comp = type.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var num = int.Parse(comp[0]);

                        switch (comp[1]) {
                            case "red":
                                Red = num;
                                break;
                            case "green":
                                Green = num;
                                break;
                            case "blue":
                                Blue = num;
                                break;
                            default:
                                throw new ArgumentException($"Invalid color {comp[1]}");
                        }
                    }
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var cc = new CubeConundrum(input);
            return cc.FindSumOfPossibleGames().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var cc = new CubeConundrum(input);
            return cc.FindSumOfPowerOfSets().ToString();
        }
    }
}
