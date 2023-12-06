using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/6
    /// </summary>
    public class Day06
    {
        public class BoatRace
        {
            public List<Race> Races = new List<Race>();

            public BoatRace(string input)
            {
                var comp = input.Split(Environment.NewLine);
                var time = comp[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var dist = comp[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < time.Length; i++)
                    Races.Add(new Race(int.Parse(time[i]), int.Parse(dist[i])));
            }

            public int FindProductOfWaysToWin()
            {
                var sum = 1;
                foreach (var race in Races)
                    sum *= race.GetNumPossibleWaysToWin();
                return sum;
            }

            public class Race
            {
                public readonly int TimeLimit;
                public readonly int DistanceRecord;

                public Race(int timeLimit, int distanceRecord)
                {
                    this.TimeLimit = timeLimit;
                    this.DistanceRecord = distanceRecord;
                }

                public int GetNumPossibleWaysToWin()
                {
                    var mid = TimeLimit / 2;
                    var wins = 0;
                    for (int i = mid + 1; i < TimeLimit; i++)
                    {
                        var remTime = TimeLimit - i;
                        var speed = TimeLimit - remTime;
                        var dist = speed * remTime;
                        if (dist > DistanceRecord)
                            wins++;
                        else
                            break;
                    }

                    for (int i = mid; i > 0; i--)
                    {
                        var remTime = TimeLimit - i;
                        var speed = TimeLimit - remTime;
                        var dist = speed * remTime;
                        if (dist > DistanceRecord)
                            wins++;
                        else
                            break;
                    }

                    return wins;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var br = new BoatRace(input);
            return br.FindProductOfWaysToWin().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
