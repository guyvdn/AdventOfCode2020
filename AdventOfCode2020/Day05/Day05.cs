using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day05
{
    public class Day05
    {
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _input = File.ReadAllText("Data/Day05_input.txt").Split(Environment.NewLine);
        }

        [TestCase("BFFFBBFRRR", ExpectedResult = 567)]
        [TestCase("FFFBBBFRRR", ExpectedResult = 119)]
        [TestCase("BBFFBBFRLL", ExpectedResult = 820)]
        public int Part1WithTestData(string value)
        {
            return new BoardingPass(value).SeatId;
        }

        [Test]
        public void Part1()
        {
            var answer = _input
                .Select(x => new BoardingPass(x))
                .Max(x => x.SeatId);

            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2()
        {
            var seatIds = _input
                .Select(x => new BoardingPass(x).SeatId)
                .ToList();

            var answer = seatIds.Single(seatId =>
                !seatIds.Contains(seatId + 1) &&
                seatIds.Contains(seatId + 2)) + 1;

            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}