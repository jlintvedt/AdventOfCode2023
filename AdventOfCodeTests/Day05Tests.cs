using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day05Tests
    {
        private string input_puzzle;
        private readonly int day = 05;

        [TestInitialize]
        public void LoadInput()
        {
            // Load input
            input_puzzle = InputProvider.GetInput(AdventOfCode.Const.Year, day);
        }

        [TestMethod]
        public void Example_Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle1(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"35", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"535088217", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"46", result);
        }

        [Ignore] // Needs better solution: 33m
        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day05.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"51399228", result);
        }
    }
}
