using NUnit.Framework;

namespace AdventOfCode2020.Day15
{
    public class Day15
    {
        [TestCase(1, ExpectedResult = 0)]
        [TestCase(2, ExpectedResult = 3)]
        [TestCase(3, ExpectedResult = 6)]
        [TestCase(4, ExpectedResult = 0)]
        [TestCase(5, ExpectedResult = 3)]
        [TestCase(6, ExpectedResult = 3)]
        [TestCase(7, ExpectedResult = 1)]
        [TestCase(8, ExpectedResult = 0)]
        [TestCase(9, ExpectedResult = 4)]
        [TestCase(10, ExpectedResult = 0)]
        public int NumberAtTurnTests(int turn)
        {
            var memoryGame = new MemoryGame("0,3,6");
            return memoryGame.NumberAtTurn(turn);
        }

        [TestCase("1,3,2", ExpectedResult = 1)]
        [TestCase("2,1,3", ExpectedResult = 10)]
        [TestCase("1,2,3", ExpectedResult = 27)]
        [TestCase("2,3,1", ExpectedResult = 78)]
        [TestCase("3,2,1", ExpectedResult = 438)]
        [TestCase("3,1,2", ExpectedResult = 1836)]
        public int Part1WithTestData(string startingNumbers)
        {
            var memoryGame = new MemoryGame(startingNumbers);
            return memoryGame.NumberAtTurn(2020);
        }

        [Test]
        public void Part1()
        {
            var memoryGame = new MemoryGame("9, 12, 1, 4, 17, 0, 18");
            var answer = memoryGame.NumberAtTurn(2020);
            TestContext.WriteLine($"Answer = {answer}");
        }

        [TestCase("0,3,6", ExpectedResult = 175594)]
        [TestCase("1,3,2", ExpectedResult = 2578)]
        [TestCase("2,1,3", ExpectedResult = 3544142)]
        [TestCase("1,2,3", ExpectedResult = 261214)]
        [TestCase("2,3,1", ExpectedResult = 6895259)]
        [TestCase("3,2,1", ExpectedResult = 18)]
        [TestCase("3,1,2", ExpectedResult = 362)]
        public int Part2WithTestData(string startingNumbers)
        {
            var memoryGame = new MemoryGame(startingNumbers);
            return memoryGame.NumberAtTurn(30000000);
        }

        [Test]
        public void Part2()
        {
            var memoryGame = new MemoryGame("9, 12, 1, 4, 17, 0, 18");
            var answer = memoryGame.NumberAtTurn(30000000);
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}