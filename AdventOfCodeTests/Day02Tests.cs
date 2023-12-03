using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day02Tests
    {
        private string input_puzzle;
        private readonly int day = 02;

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
            var result = AdventOfCode.Day02.Puzzle1(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"8", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"2449", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"2286", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day02.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"63981", result);
        }
    }
}
