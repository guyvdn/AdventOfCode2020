using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day17
{
    public class Day17
    {
        private string[] _testData;
        //private string[] _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day17_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day17_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            var conwayCubes = new ConwayCubes(_testData);
            conwayCubes.ActiveCubes.ShouldBe(5);
            conwayCubes.Cycle3D(1);
            conwayCubes.ActiveCubes.ShouldBe(11);
            conwayCubes.Cycle3D(5);
            conwayCubes.ActiveCubes.ShouldBe(112);
        }

        [Test]
        public void Part1()
        {
            var conwayCubes = new ConwayCubes(_input);
            conwayCubes.Cycle3D(6);
            var answer = conwayCubes.ActiveCubes;
            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var conwayCubes = new ConwayCubes(_testData);
            conwayCubes.Cycle4D(6);
            conwayCubes.ActiveCubes.ShouldBe(848);
        }

        [Test]
        public void Part2()
        {
            var conwayCubes = new ConwayCubes(_input);
            conwayCubes.Cycle4D(6);
            var answer = conwayCubes.ActiveCubes;
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}