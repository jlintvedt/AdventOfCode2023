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
                var cardString = comp[0];
                Bid = int.Parse(comp[1]);

                for (int i = 0; i < 5; i++)
                {
                    Cards[i] = cardString[i] switch
                    {
                        'A' => 14,
                        'K' => 13,
                        'Q' => 12,
                        'J' => jokers ? 1 : 11,
                        'T' => 10,
                        _ => cardString[i] - 48,
                    };
                }

                Type = FindHandType();
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

            private HandType FindHandType()
            {
                var numCards = new int[15];
                for (int i = 0; i < 5; i++)
                    numCards[Cards[i]]++;
                numJokers = numCards[1];

                // Analyze cards
                var hasPair = false;
                var most = 0;
                for (int i = 2; i < 15; i++) // Skip i=1 (jokers)
                {
                    // First pair stored in bool
                    if (!hasPair && numCards[i] == 2)
                        hasPair = true;
                    else
                        most = numCards[i] > most ? numCards[i] : most;
                }

                // Find hand type
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

                return Type switch
                {
                    HandType.HighCard => numJokers switch { 1 => HandType.OnePair, 2 => HandType.ThreeOfAKind, 3 => HandType.FourOfAKind, _ => HandType.FiveOfAKind },
                    HandType.OnePair => numJokers switch { 1 => HandType.ThreeOfAKind, 2 => HandType.FourOfAKind, _ => HandType.FiveOfAKind },
                    HandType.TwoPairs => HandType.FullHouse,
                    HandType.ThreeOfAKind => numJokers == 2 ? HandType.FiveOfAKind : HandType.FourOfAKind,
                    HandType.FourOfAKind => HandType.FiveOfAKind,
                    _ => Type
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
        var cc = new CamelCards(input, jokers: true); ;
            return cc.FindTotalWinnings().ToString();
        }
}
}
