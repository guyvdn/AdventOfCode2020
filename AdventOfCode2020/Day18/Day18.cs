using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day18
{
    public class Day18
    {
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _input = File.ReadAllText("Data/Day18_input.txt").Split(Environment.NewLine);
        }

        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", ExpectedResult = 51)]
        [TestCase("2 * 3 + (4 * 5)", ExpectedResult = 26)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", ExpectedResult = 437)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", ExpectedResult = 12240)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", ExpectedResult = 13632)]
        public long Part1WithTestData(string input)
        {
            return Math.Calculate(input);
        }

        [Test]
        public void Part1()
        {
            var answer = _input.Select(Math.Calculate).Sum();
            TestContext.WriteLine($"Answer = {answer}");
        }

        [TestCase("1 + (2 * 3) + (4 * (5 + 6))", ExpectedResult = 51)]
        [TestCase("2 * 3 + (4 * 5)", ExpectedResult = 46)]
        [TestCase("5 + (8 * 3 + 9 + 3 * 4 * 3)", ExpectedResult = 1445)]
        [TestCase("5 * 9 * (7 * 3 * 3 + 9 * 3 + (8 + 6 * 4))", ExpectedResult = 669060)]
        [TestCase("((2 + 4 * 9) * (6 + 9 * 8 + 6) + 6) + 2 + 4 * 2", ExpectedResult = 23340)]
        public long Part2WithTestData(string input)
        {
            return Math.CalculateAdvanced(input);
        }

        [Test]
        public void Part2()
        {
            var answer = _input.Select(Math.CalculateAdvanced).Sum();
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}