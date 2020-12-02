using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020
{
    public class Day02
    {
        private class Password
        {
            public Password(string input)
            {
                var inputs = input.Split(' ');
                var counts = inputs[0].Split('-');
                MinCount = int.Parse(counts[0]);
                MaxCount = int.Parse(counts[1]);
                RequiredCharacter = inputs[1][0];
                Value = inputs[2];
            }

            public int MinCount { get; }
            public int MaxCount { get; }
            public char RequiredCharacter { get; }
            public string Value { get; }

            public bool IsValidForPolicy1
            {
                get
                {
                    var count = Value.Count(x => x == RequiredCharacter);
                    return count >= MinCount && count <= MaxCount;
                }
            }

            public bool IsValidForPolicy2
            {
                get
                {
                    return (Value[MinCount - 1] == RequiredCharacter) ^ (Value[MaxCount - 1] == RequiredCharacter);
                }
            }
        }

        private Password[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            var inputText = File.ReadAllText("Day02_input.txt");
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
