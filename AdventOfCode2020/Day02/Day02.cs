using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020.Day02
{
    public class Day02
    {
        private Password[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            var inputText = File.ReadAllText("Data/Day02_input.txt");
            var inputTextArray = inputText.Split(Environment.NewLine);
            _input = inputTextArray.Select(input => new Password(input)).ToArray();
        }

        [Test]
        public void Part1()
        {
            var validCount = _input.Count(x => x.IsValidForPolicy1);
            TestContext.WriteLine($"{validCount} passwords are valid");
        }  
        
        [Test]
        public void Part2()
        {
            var validCount = _input.Count(x => x.IsValidForPolicy2);
            TestContext.WriteLine($"{validCount} passwords are valid");
        }
    }
}
