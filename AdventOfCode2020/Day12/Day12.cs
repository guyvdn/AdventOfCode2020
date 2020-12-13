using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day12
{
    public class Day12
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day12_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day12_input.txt").Split(Environment.NewLine);
        }
        
        [Test]
        public void Part1WithTestData()
        {
            var navigate = new Navigate(_testData);
            navigate.ToDestination().ShouldBe(25);
        }

        [Test]
        public void Part1()
        {
            var navigate = new Navigate(_input);
            var destination = navigate.ToDestination();
            TestContext.WriteLine($"Answer = {destination}");
        }
        
        [Test]
        public void Part2WithTestData()
        {
            var navigate = new Navigate(_testData);
            navigate.ToWayPoint().ShouldBe(286);
        }

        [Test]
        public void Part2()
        {
            var navigate = new Navigate(_input);
            var destination = navigate.ToWayPoint();
            TestContext.WriteLine($"Answer = {destination}");
        }
    }
}