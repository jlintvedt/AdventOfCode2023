using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day04Tests
    {
        private string input_puzzle;
        private readonly int day = 04;

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
            var result = AdventOfCode.Day04.Puzzle1(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"13", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"20829", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle2(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day04.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"Puzzle2", result);
        }
    }
}
