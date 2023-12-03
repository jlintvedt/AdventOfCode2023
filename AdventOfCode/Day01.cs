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
            private bool searchNumberAsString = false;
            private readonly string[] numString = new string[9] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            public CalibrationDocument(string input)
            {
                lines = input.Split(Environment.NewLine);
            }

            public int FindSumOfCalibrationValues(bool searchNumberAsString = false)
            {
                this.searchNumberAsString = searchNumberAsString;
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
                    if (searchFirst && TryGetNumber(line, i, out int v))
                    {
                        searchFirst = false;
                        value += v * 10;
                    }

                    if (searchLast && TryGetNumber(line, line.Length - 1 - i, out v, leftToRight: false))
                    {
                        searchLast = false;
                        value += v;
                    }
                }

                return value;
            }

            private bool TryGetNumber(string str, int index, out int number, bool leftToRight = true)
            {
                number = str[index] - 48;
                if (number >= 0 && number < 10)
                    return true;

                if (searchNumberAsString)
                    return TryGetNumberAsString(str, index, out number, leftToRight);

                return false;
            }

            private bool TryGetNumberAsString(string str, int index, out int number, bool leftToRight = true)
            {
                number = 0;
                var increment = leftToRight ? 1 : -1;

                // Iterate over string rep. of numbers
                for (int j = 0; j < numString.Length; j++)
                {
                    var numStr = numString[j];
                    var match = true;
                    int i;

                    // Chack if number is present as string
                    for (i = 0; i < numStr.Length; i++)
                    {
                        var numStrIndex = leftToRight ? i : numStr.Length - i - 1;
                        if (str[index + i*increment] != numStr[numStrIndex])
                        {
                            match = false;
                            break;
                        }
                    }

                    if (match)
                    {
                        number = j + 1;
                        return true;
                    }
                }

                return false;
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
            var cd = new CalibrationDocument(input);
            return cd.FindSumOfCalibrationValues(searchNumberAsString: true).ToString();
        }
    }
}
