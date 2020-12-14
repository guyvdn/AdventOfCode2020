using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day14
{
    public class Day14
    {
        private string[] _testData1;
        private string[] _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day14_testdata1.txt").Split(Environment.NewLine);
            _testData2 = File.ReadAllText("Data/Day14_testdata2.txt").Split(Environment.NewLine);
            _input = File.ReadAllText("Data/Day14_input.txt").Split(Environment.NewLine);
        }

        [TestCase(11, ExpectedResult = 73)]
        [TestCase(101, ExpectedResult = 101)]
        [TestCase(0, ExpectedResult = 64)]
        public long ApplyMaskTests(long input)
        {
            return input.ApplyMask("XXXXXXXXXXXXXXXXXXXXXXXXXXXXX1XXXX0X");
        }

        [Test]
        public void ApplyFloatingMask()
        {
            var result = 42L.ApplyFloatingMask("000000000000000000000000000000X1001X");
            result.Length.ShouldBe(4);
            result.ShouldContain(26);
            result.ShouldContain(27);
            result.ShouldContain(58);
            result.ShouldContain(59);
        }

        [Test]
        public void Part1WithTestData()
        {
            var decoder = new Decoder(_testData1);
            decoder.Execute(decoder.ValueDecoding);
            var memory = decoder.Memory;

            memory[7].ShouldBe(101);
            memory[8].ShouldBe(64);
            memory.Sum(x => x.Value).ShouldBe(165);
        }

        [Test]
        public void Part1()
        {
            var decoder = new Decoder(_input);
            decoder.Execute(decoder.ValueDecoding);
            var memory = decoder.Memory;
            var answer = memory.Sum(x => x.Value);
            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var decoder = new Decoder(_testData2);
            decoder.Execute(decoder.AddressDecoding);
            var memory = decoder.Memory;
            memory.Sum(x => x.Value).ShouldBe(208);
        }

        [Test]
        public void Part2()
        {
            var decoder = new Decoder(_input);
            decoder.Execute(decoder.AddressDecoding);
            var memory = decoder.Memory;
            var answer = memory.Sum(x => x.Value);
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}