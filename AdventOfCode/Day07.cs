using System;
using System.Collections.Generic;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/7
    /// </summary>
    public class Day07
    {

        public class CamelCards
        {
            public List<CardHand> Hands = new List<CardHand> ();

            public CamelCards(string input)
            {
                foreach (var line in input.Split(Environment.NewLine))
                    Hands.Add(new CardHand(line));
            }

            public int FindTotalWinnings()
            {
                Hands.Sort();
                var sum = 0;
                for (int i = 0; i < Hands.Count; i++)
                    sum += Hands[i].Bid * (i + 1);

                return sum;
            }
        }

        public class  CardHand:IComparable<CardHand>
        {
            public int[] Cards = new int[5];
            public int Bid;
            public HandType Type;

            public CardHand(string input)
            {
                var comp = input.Split(' ');
                var cards = comp[0];
                Bid = int.Parse(comp[1]);

                for (int i = 0; i < 5; i++)
                {
                    Cards[i] = cards[i] switch
                    {
                        'A' => 14,
                        'K' => 13,
                        'Q' => 12,
                        'J' => 11,
                        'T' => 10,
                        _ => cards[i] - 48,
                    };
                }

                Type = FindHandType();
            }

            public int CompareTo(CardHand other)
            {
                if (Type != other.Type)
                    return Type - other.Type;

                for (int i = 0; i < Cards.Length; i++)
                    if (Cards[i] != other.Cards[i])
                        return Cards[i] - other.Cards[i];

                return 0;
            }

            private HandType FindHandType()
            {
                var numCards = new int[15];
                for (int i = 0; i < 5; i++)
                    numCards[Cards[i]]++;

                var hasPair = false;
                var most = 0;
                for (int i = 0; i < 15; i++)
                {
                    // First pair stored in bool
                    if (!hasPair && numCards[i] == 2)
                        hasPair = true;
                    else
                        most = numCards[i] > most ? numCards[i] : most;
                }

                return most switch
                {
                    5 => HandType.FiveOfAKind,
                    4 => HandType.FourOfAKind,
                    3 => hasPair ? HandType.FullHouse : HandType.ThreeOfAKind,
                    2 => HandType.TwoPairs,
                    _ => hasPair ? HandType.OnePair : HandType.HighCard,
                };
            }


            public enum HandType
            {
                HighCard,
                OnePair,
                TwoPairs,
                ThreeOfAKind,
                FullHouse,
                FourOfAKind,
                FiveOfAKind
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var cc = new CamelCards(input);
            return cc.FindTotalWinnings().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
