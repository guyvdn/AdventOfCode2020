using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day07
{
    public class Day07
    {
        private string[] _testData1;
        private string[] _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day07_testdata_part1.txt").Split(Environment.NewLine);
            _testData2 = File.ReadAllText("Data/Day07_testdata_part2.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day07_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void RegexTest()
        {
            var bag = new Rule("light red bags contain 1 bright white bag, 2 muted yellow bags.");
            bag.Name.ShouldBe("light red");
            bag.Contents.Count.ShouldBe(2);
            bag.Contents.ShouldContain(x => x.BagName == "bright white");
            bag.Contents.ShouldContain(x => x.BagName == "muted yellow");
        }


        [Test]
        public void Part1WithTestData()
        {
            new Rules(_testData1).GetParents("shiny gold").Distinct().Count().ShouldBe(4);
        }

        [Test]
        public void Part1()
        {
            var parentsCount = new Rules(_input).GetParents("shiny gold").Distinct().Count();
            TestContext.WriteLine($"Answer = {parentsCount}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var contentCount = new Rules(_testData2).GetContentCount("shiny gold") - 1;
            contentCount.ShouldBe(126);
        }


        [Test]
        public void Part2()
        {
            var contentCount = new Rules(_input).GetContentCount("shiny gold") - 1;
            TestContext.WriteLine($"Answer = {contentCount}");
        }

    }
}
