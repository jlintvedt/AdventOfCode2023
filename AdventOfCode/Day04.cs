using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/4
    /// </summary>
    public class Day04
    {
        public class ScratchcardScoring
        {
            public List<Scratchcard> Cards = new List<Scratchcard>();

            public ScratchcardScoring(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                {
                    Cards.Add(new Scratchcard(line));
                }
            }

            public int FindSumOfScores()
            {
                var sum = 0;
                foreach (var card in Cards)
                    sum += card.GetScore();

                return sum;
            }

            public int FindTotalNumberOfScratchcards()
            {
                var totalNum = 0;
                for (int i = 0; i < Cards.Count; i++)
                {
                    var card = Cards[i];
                    totalNum += card.Count;
                    var num = card.GetNumWinningNumbers();
                    for (int j = 1; j <= num; j++)
                        Cards[i + j].Count += card.Count; // Potential ArgumentOutOfRangeException
                }

                return totalNum;
            }

            public class Scratchcard
            {
                public HashSet<int> WinningNumbers = new HashSet<int>();
                public List<int> Numbers = new List<int>();
                public int Count = 1;
                private int score;
                private int numMatches;

                public Scratchcard(string input)
                {
                    var comp = input.Split(':')[1].Split('|');
                    foreach (var n in comp[0].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        WinningNumbers.Add(int.Parse(n));

                    foreach (var n in comp[1].Split(' ', StringSplitOptions.RemoveEmptyEntries))
                        Numbers.Add(int.Parse(n));
                }

                public int GetScore()
                {
                    foreach (var num in Numbers)
                        if (WinningNumbers.Contains(num))
                            score = score == 0 ? 1 : score * 2;

                    return score;
                }

                public int GetNumWinningNumbers()
                {
                    foreach (var num in Numbers)
                        if (WinningNumbers.Contains(num))
                            numMatches++;

                    return numMatches;
                }
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var sc = new ScratchcardScoring(input);
            return sc.FindSumOfScores().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            var sc = new ScratchcardScoring(input);
            return sc.FindTotalNumberOfScratchcards().ToString();
        }
    }
}
