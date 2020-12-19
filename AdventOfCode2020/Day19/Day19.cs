using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day19
{
    public class Day19
    {
        private string[] _testData1;
        private string[] _testData2;
        private string[] _input1;
        private string[] _input2;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day19_testdata1.txt").Split(Environment.NewLine + Environment.NewLine);
            _testData2 = File.ReadAllText("Data/Day19_testdata2.txt").Split(Environment.NewLine + Environment.NewLine);
            _input1 = File.ReadAllText("Data/Day19_input1.txt").Split(Environment.NewLine + Environment.NewLine);
            _input2 = File.ReadAllText("Data/Day19_input2.txt").Split(Environment.NewLine + Environment.NewLine);
        }

        [TestCase("ababbb", ExpectedResult = true)]
        [TestCase("bababa", ExpectedResult = false)]
        [TestCase("abbbab", ExpectedResult = true)]
        [TestCase("aaabbb", ExpectedResult = false)]
        [TestCase("aaaabbb", ExpectedResult = false)]
        public bool Part1WithTestData(string value)
        {
            var monsterMessages = new MonsterMessages(_testData1[0].Split(Environment.NewLine));
            monsterMessages.ParsedRule.ShouldBe("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$");
            return monsterMessages.IsValid(value);
        }

        [Test]
        public void Part1()
        {
            var monsterMessages = new MonsterMessages(_input1[0].Split(Environment.NewLine));
            var answer = _input1[1].Split(Environment.NewLine).Count(monsterMessages.IsValid);
            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var monsterMessages = new MonsterMessages(_testData2[0].Split(Environment.NewLine));
            var answer = _testData2[1].Split(Environment.NewLine).Count(monsterMessages.IsValid);
            answer.ShouldBe(12);
        }

        [Test]
        public void Part2()
        {
            var monsterMessages = new MonsterMessages(_input2[0].Split(Environment.NewLine));
            var answer = _input2[1].Split(Environment.NewLine).Count(monsterMessages.IsValid);
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}