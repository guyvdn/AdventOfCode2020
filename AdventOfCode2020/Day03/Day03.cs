using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day03
{
    public class Day03
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day03_testdata.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day03_input.txt").Split(Environment.NewLine);
        }

        private int GetTreeCount(string[] grid, int moveRight, int moveDown)
        {
            var treeCount = 0;
            var position = 0;
            var height = grid.Length;
            var width = grid[0].Length;

            for (var down = 0; down < height; down += moveDown)
            {
                var row = grid[down];
                if (row[position] == '#')
                    treeCount++;

                position += moveRight;
                if (position >= width)
                    position -= width;
            }

            return treeCount;
        }
        
        [Test]
        public void Part1WithTestData()
        {
            var treeCount = GetTreeCount(_testData, 3, 1);
            treeCount.ShouldBe(7);
        }

        [Test]
        public void Part1()
        {
            var treeCount = GetTreeCount(_input, 3, 1);
            TestContext.WriteLine($"Number of trees = {treeCount}");
        }

        [TestCase(1, 1, ExpectedResult = 2)]
        [TestCase(3, 1, ExpectedResult = 7)]
        [TestCase(5, 1, ExpectedResult = 3)]
        [TestCase(7, 1, ExpectedResult = 4)]
        [TestCase(1, 2, ExpectedResult = 2)]
        public int Part2WithTestData(int moveRight, int moveDown)
        {
            return GetTreeCount(_testData, moveRight, moveDown);
        }

        [Test]
        public void Part2()
        {
            Int64 treeCount = 1;
            treeCount *= GetTreeCount(_input, 1, 1);
            treeCount *= GetTreeCount(_input, 3, 1);
            treeCount *= GetTreeCount(_input, 5, 1);
            treeCount *= GetTreeCount(_input, 7, 1);
            treeCount *= GetTreeCount(_input, 1, 2);

            TestContext.WriteLine($"Answer = {treeCount}");
        }
    }
}
