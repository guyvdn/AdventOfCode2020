using System;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace AdventOfCode2020
{
    public class Day01
    {
        private int[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            var inputText = File.ReadAllText("Day01_input.txt");
            var inputTextArray = inputText.Split(Environment.NewLine);
            _input = inputTextArray.Select(int.Parse).ToArray();
        }

        [Test]
        public void Part1()
        {
            foreach (var x in _input)
            {
                foreach (var y in _input)
                {
                    if (x + y != 2020)
                        continue;

                    TestContext.WriteLine($"{x} + {y} = 2020");
                    TestContext.WriteLine($"Answer = {x * y}");
                    return;
                }
            }
        }

        [Test]
        public void Part2()
        {
            foreach (var x in _input)
            {
                foreach (var y in _input)
                {
                    foreach (var z in _input)
                    {
                        if (x + y + z != 2020)
                            continue;

                        TestContext.WriteLine($"{x} + {y} + {z} = 2020");
                        TestContext.WriteLine($"Answer = {x * y * z}");
                        return;
                    }
                }
            }
        }
    }
}