using System;
using System.IO;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day08
{
    public class Day08
    {
        private string[] _testData1;
        private string[] _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day08_testdata_part1.txt").Split(Environment.NewLine);
            _testData2 = File.ReadAllText("Data/Day08_testdata_part2.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day08_input.txt").Split(Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            var program = new Program(_testData1);
            Should.Throw<InfiniteLoopException>(() => program.Run()).Accumulator.ShouldBe(5);
        }       
        
        [Test]
        public void Part1()
        {
            var program = new Program(_input);
            try
            {
                program.Run();
            }
            catch (InfiniteLoopException e)
            {
                TestContext.WriteLine($"Answer = {e.Accumulator}");
            }
        }


        [Test]
        public void Part2WithTestData()
        {
            var program = new Program(_testData2);

            var accumulator = program.RunWithSelfHealing();

            accumulator.ShouldBe(8);
        }  
        
        [Test]
        public void Part2()
        {
            var program = new Program(_input);

            var accumulator = program.RunWithSelfHealing();

            TestContext.WriteLine($"Answer = {accumulator}");
        }
    }
}