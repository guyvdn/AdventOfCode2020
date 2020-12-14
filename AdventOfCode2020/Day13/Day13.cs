using NUnit.Framework;
using Shouldly;
using System;
using System.IO;

namespace AdventOfCode2020.Day13
{
    public class Day13
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day13_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day13_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            var busSchedule = new BusSchedule(_testData[1]);
            var timestamp = int.Parse(_testData[0]);
            var nextDeparture = busSchedule.GetNextDeparture(timestamp);
            var answer = (nextDeparture.Timestamp - timestamp) * nextDeparture.Bus;
            answer.ShouldBe(295);
        }

        [Test]
        public void Part1()
        {
            var busSchedule = new BusSchedule(_input[1]);
            var timestamp = int.Parse(_input[0]);
            var nextDeparture = busSchedule.GetNextDeparture(timestamp);
            var answer = (nextDeparture.Timestamp - timestamp) * nextDeparture.Bus;
            TestContext.WriteLine($"Answer = {answer}");
        }

        [TestCase("17,x,13,19", ExpectedResult = 3417)]
        [TestCase("7,13,x,x,59,x,31,19", ExpectedResult = 1068781)]
        [TestCase("67,7,59,61", ExpectedResult = 754018)]
        [TestCase("67,x,7,59,61", ExpectedResult = 779210)]
        [TestCase("67,7,x,59,61", ExpectedResult = 1261476)]
        [TestCase("1789,37,47,1889", ExpectedResult = 1202161486)]
        public long Part2WithForceTestData(string input)
        {
            var busSchedule = new BusSchedule(input);
            return busSchedule.GetAnswerForContestWithForce();
        }
        
        [TestCase("17,x,13,19", ExpectedResult = 3417)]
        [TestCase("7,13,x,x,59,x,31,19", ExpectedResult = 1068781)]
        [TestCase("67,7,59,61", ExpectedResult = 754018)]
        [TestCase("67,x,7,59,61", ExpectedResult = 779210)]
        [TestCase("67,7,x,59,61", ExpectedResult = 1261476)]
        [TestCase("1789,37,47,1889", ExpectedResult = 1202161486)]
        public long Part2WithSpeedTestData(string input)
        {
            var busSchedule = new BusSchedule(input);
            return busSchedule.GetAnswerForContestWithSpeed();
        }

        [Test]
        public void Part2()
        {
            var busSchedule = new BusSchedule(_input[1]);
            var answer = busSchedule.GetAnswerForContestWithSpeed();
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}