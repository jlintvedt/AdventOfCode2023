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
            public readonly List<Race> Races = new List<Race>();
            public readonly Race SingleRace;

            public BoatRace(string input)
            {
                var comp = input.Split(Environment.NewLine);
                var time = comp[0].Split(' ', StringSplitOptions.RemoveEmptyEntries);
                var dist = comp[1].Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i < time.Length; i++)
                    Races.Add(new Race(int.Parse(time[i]), long.Parse(dist[i])));

                SingleRace = new Race(int.Parse(comp[0][9..].Replace(" ", "")), long.Parse(comp[1][9..].Replace(" ", "")));
            }

            public int FindProductOfWaysToWin()
            {
                var sum = 1;
                foreach (var race in Races)
                    sum *= race.GetNumPossibleWaysToWin();
                return sum;
            }

            public int FindNumWaysToWinLongRace()
            {
                return SingleRace.GetNumPossibleWaysToWin();
            }

            public class Race
            {
                public readonly int TimeLimit;
                public readonly long DistanceRecord;

                public Race(int timeLimit, long distanceRecord)
                {
                    this.TimeLimit = timeLimit;
                    this.DistanceRecord = distanceRecord;
                }

                public int GetNumPossibleWaysToWin()
                {
                    var mid = TimeLimit / 2;
                    int wins = 0;

                    for (int i = mid + 1; i < TimeLimit; i++)
                        if (GetDistance(i) > DistanceRecord)
                            wins++;
                        else
                            break;

                    for (int i = mid; i > 0; i--)
                        if (GetDistance(i) > DistanceRecord)
                            wins++;
                        else
                            break;

                    return wins;
                }

                private long GetDistance(int secondsHeld)
                {
                    int remTime = TimeLimit - secondsHeld;
                    long speed = TimeLimit - remTime;
                    return speed * remTime;
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
            var br = new BoatRace(input);
            return br.FindNumWaysToWinLongRace().ToString();
        }
    }
}
