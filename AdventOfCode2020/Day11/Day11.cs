using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day11
{
    public class Day11
    {
        private string[] _testData1;
        //private IReadOnlyCollection<int> _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day11_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day11_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData1()
        {
            var seats = new Seats(_testData1);
            seats.ChangeSeats(Seats.GetOccupiedAdjacentSeats, 4).ShouldBe(37);
        }

        [Test]
        public void Part1()
        {
            var seats = new Seats(_input);
            var occupiedSeats = seats.ChangeSeats(Seats.GetOccupiedAdjacentSeats, 4);
            TestContext.WriteLine($"Answer = {occupiedSeats }");
        }


        [TestCase(0,0,1,1, Description = "NW")]
        [TestCase(0,2,1,2, Description = "N")]
        [TestCase(0,4,1,3, Description = "NE")]
        [TestCase(2,4,2,3, Description = "E")]
        [TestCase(4,4,3,3, Description = "SE")]
        [TestCase(4,2,3,2, Description = "S")]
        [TestCase(4,0,3,1, Description = "SW")]
        [TestCase(2,0,2,1, Description = "W")]
        public void GetVisibleAdjacentSeatsTests(int invisibleSeatRow, int invisibleSeatColumn, int visibleSeatRow, int visibleSeatColumn)
        {
            var seat = new Seat('L', 2, 2);

            Seats.GetVisibleAdjacentSeats(new Seat[]{new('#', visibleSeatRow, visibleSeatColumn), new('L', invisibleSeatRow, invisibleSeatColumn)}, seat).ShouldBe(1);
        }


        [Test]
        public void Part2WithTestData1()
        {
            var seats = new Seats(_testData1);
            seats.ChangeSeats(Seats.GetVisibleAdjacentSeats, 5).ShouldBe(26);
        }

        [Test]
        public void Part2()
        {
            var seats = new Seats(_input);
            var occupiedSeats = seats.ChangeSeats(Seats.GetVisibleAdjacentSeats, 5);
            TestContext.WriteLine($"Answer = {occupiedSeats }");
        }

    }
}