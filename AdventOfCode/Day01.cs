using System;

namespace AdventOfCode
{
    /// <summary>
    /// https://adventofcode.com/2023/day/1
    /// </summary>
    public class Day01
    {
        public class CalibrationDocument
        {
            private readonly string[] lines;

            public CalibrationDocument(string input)
            {
                lines = input.Split(Environment.NewLine);
            }

            public int FindSumOfCalibrationValues()
            {
                var sum = 0;

                for (int i = 0; i < lines.Length; i++)
                {
                    sum += GetCalibrationValue(lines[i]);
                }

                return sum;
            }

            private int GetCalibrationValue(string line)
            {
                var value = 0;
                var searchFirst = true;
                var searchLast = true;

                for (int i = 0; searchFirst || searchLast; i++)
                {
                    // Check in char is ASCII value 0-9
                    if (searchFirst && TryGetNumber(line, i, out int v))
                    {
                        searchFirst = false;
                        value += v * 10;
                    }

                    if (searchLast && TryGetNumber(line, line.Length - 1 - i, out v))
                    {
                        searchLast = false;
                        value += v;
                    }
                }

                return value;
            }

            private bool TryGetNumber(string str, int index, out int number)
            {
                number = str[index] - 48;
                return number >= 0 && number < 10;
            }
        }

        // == == == == == Puzzle 1 == == == == ==
        public static string Puzzle1(string input)
        {
            var cd = new CalibrationDocument(input);
            return cd.FindSumOfCalibrationValues().ToString();
        }

        // == == == == == Puzzle 2 == == == == ==
        public static string Puzzle2(string input)
        {
            return "Puzzle2";
        }
    }
}
