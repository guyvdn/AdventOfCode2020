using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day09
{
    public class Day09
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day09_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day09_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            var xmas = new Xmas(_testData);
            var invalidNumber = xmas.GetInvalidNumber(5);
            invalidNumber.ShouldBe(127);
        }

        [Test]
        public void Part1()
        {
            var xmas = new Xmas(_input);
            var invalidNumber = xmas.GetInvalidNumber(25);
            TestContext.WriteLine($"Answer = {invalidNumber}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var xmas = new Xmas(_testData);
            var weakness = xmas.FindWeakness(127);
            weakness.ShouldBe(62);
        }

        [Test]
        public void Part2()
        {
            var xmas = new Xmas(_input);
            var invalidNumber = xmas.GetInvalidNumber(25);
            var weakness = xmas.FindWeakness(invalidNumber);
            TestContext.WriteLine($"Answer = {weakness}");
        }
    }
}