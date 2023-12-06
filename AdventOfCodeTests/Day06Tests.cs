using AdventOfCodeTests.InputHelpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdventOfCodeTests
{
    [TestClass]
    public class Day06Tests
    {
        private string input_puzzle;
        private readonly int day = 06;

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
            var result = AdventOfCode.Day06.Puzzle1(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"288", result);
        }

        [TestMethod]
        public void Puzzle1()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle1(input_puzzle);

            // Assert
            Assert.AreEqual($"6209190", result);
        }

        [TestMethod]
        public void Example_Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(InputProvider.GetExample(AdventOfCode.Const.Year, day, exampleNum: 1));

            // Assert
            Assert.AreEqual($"71503", result);
        }

        [TestMethod]
        public void Puzzle2()
        {
            // Act
            var result = AdventOfCode.Day06.Puzzle2(input_puzzle);

            // Assert
            Assert.AreEqual($"28545089", result);
        }
    }
}
