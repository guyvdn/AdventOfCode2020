using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day10
{
    public class Day10
    {
        private IReadOnlyCollection<int> _testData1;
        private IReadOnlyCollection<int> _testData2;
        private IReadOnlyCollection<int> _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day10_testdata1.txt").Split(Environment.NewLine).Select(int.Parse).ToList();
            _testData2 = File.ReadAllText("Data/Day10_testdata2.txt").Split(Environment.NewLine).Select(int.Parse).ToList();
            _input = File.ReadAllText("Data/Day10_input.txt").Split(Environment.NewLine).Select(int.Parse).ToList();
        }

        [Test]
        public void Part1WithTestData1()
        {
            var adapters = new Adapters(_testData1);
            adapters.CountDifference(1).ShouldBe(7);
            adapters.CountDifference(3).ShouldBe(5);
        }

        [Test]
        public void Part1WithTestData2()
        {
            var adapters = new Adapters(_testData2);
            adapters.CountDifference(1).ShouldBe(22);
            adapters.CountDifference(3).ShouldBe(10);
        }

        [Test]
        public void Part1()
        {
            var adapters = new Adapters(_input);
            var countDifference1 = adapters.CountDifference(1);
            var countDifference3 = adapters.CountDifference(3);
            TestContext.WriteLine($"Answer = {countDifference1 * countDifference3}");
        }

        [Test]
        public void Part2WithTestData1()
        {
            var adapters = new Adapters(_testData1);
            adapters.CountPossibleCombinations().ShouldBe(8);
        }

        [Test]
        public void Part2WithTestData2()
        {
            var adapters = new Adapters(_testData2);
            adapters.CountPossibleCombinations().ShouldBe(19208);
        }

        [Test]
        public void Part2()
        {
            var adapters = new Adapters(_input);
            TestContext.WriteLine($"Answer = {adapters.CountPossibleCombinations()}");
        }
    }
}