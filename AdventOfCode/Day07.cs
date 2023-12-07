using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

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

            public CamelCards(string input, bool jokers = false)
            {
                foreach (var line in input.Split(Environment.NewLine))
                    Hands.Add(new CardHand(line, jokers));
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
            private int numJokers;
            private string cardString;

            public CardHand(string input, bool jokers = false)
            {
                var comp = input.Split(' ');
                cardString = comp[0];
                Bid = int.Parse(comp[1]);

                for (int i = 0; i < 5; i++)
                {
                    Cards[i] = cardString[i] switch
                    {
                        'A' => 14,
                        'K' => 13,
                        'Q' => 12,
                        'J' => 11,
                        'T' => 10,
                        _ => cardString[i] - 48,
                    };
                }

                Type = FindHandType(jokers);
                if (jokers)
                    Type = RecaulculateHandUsingJokers();
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

            public override string ToString()
            {
                return $"{cardString} {Type}";
            }

            private HandType FindHandType(bool jokers = false)
            {
                var numCards = new int[15];
                for (int i = 0; i < 5; i++)
                    numCards[Cards[i]]++;

                if (jokers)
                {
                    numJokers = numCards[11];
                    numCards[11] = 0;
                }

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

            private HandType RecaulculateHandUsingJokers()
            {
                if (numJokers == 0)
                    return Type;

                // Set joker to lowest value
                for (int i = 0; i<Cards.Length; i++)
                    if (Cards[i] == 11)
                        Cards[i] = 1;

                // Recalculate Type using jokers
                switch (Type)
                {
                    case HandType.HighCard:
                        return numJokers switch
                        {
                            1 => HandType.OnePair,
                            2 => HandType.ThreeOfAKind,
                            3 => HandType.FourOfAKind,
                            _ => HandType.FiveOfAKind,
                        };
                    case HandType.OnePair:
                        return numJokers switch
                        {
                            1 => HandType.ThreeOfAKind,
                            2 => HandType.FourOfAKind,
                            3 => HandType.FiveOfAKind,
                        };
                    case HandType.TwoPairs:
                        return HandType.FullHouse;
                    case HandType.ThreeOfAKind:
                        return numJokers == 2 ? HandType.FiveOfAKind : HandType.FourOfAKind;
                    case HandType.FourOfAKind:
                        return HandType.FiveOfAKind;
                    default:
                        break;
                }

                return Type;
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
        var cc = new CamelCards(input, jokers: true); ;
            return cc.FindTotalWinnings().ToString();
        }
}
}
