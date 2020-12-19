using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day19
{
    public class MonsterMessages
    {
        private readonly Dictionary<int, string> _rules = new();
        private readonly MemoryCache _parsedRules = new(new MemoryCacheOptions());

        public MonsterMessages(IEnumerable<string> input)
        {
            foreach (var s in input)
            {
                var split = s.Split(':');
                var ruleNumber = int.Parse(split[0]);

                var rule = split[1].Replace("\"", "");
                if (rule.Contains("|"))
                    rule = $"({rule})";

                _rules.Add(ruleNumber, rule);
            }

            ParsedRule = $"^{GetParsedRule(0).Replace(" ", "")}$";
        }

        public string ParsedRule { get; }

        private string GetParsedRule(int ruleNumber)
        {
            if (_parsedRules.TryGetValue<string>(ruleNumber, out var cachedValue))
                return cachedValue;

            var rule = _rules[ruleNumber];

            while (true)
            {
                var numbers = Regex.Matches(rule, @"\d+").Select(x => int.Parse(x.Value)).ToList();
                if (!numbers.Any())
                {
                    _parsedRules.Set(ruleNumber, rule);
                    return rule;
                }

                var number = numbers.First();
                var regex = new Regex(Regex.Escape($" {number}"));
                rule = regex.Replace(rule, GetParsedRule(number), 1);
            }
        }

        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, ParsedRule);
        }
    }

    public class Day19
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day19_testdata.txt").Split(Environment.NewLine + Environment.NewLine);
            _input = File.ReadAllText("Data/Day19_input.txt").Split(Environment.NewLine + Environment.NewLine);
        }

        [TestCase("ababbb", ExpectedResult = true)]
        [TestCase("bababa", ExpectedResult = false)]
        [TestCase("abbbab", ExpectedResult = true)]
        [TestCase("aaabbb", ExpectedResult = false)]
        [TestCase("aaaabbb", ExpectedResult = false)]
        public bool Part1WithTestData(string value)
        {
            var monsterMessages = new MonsterMessages(_testData[0].Split(Environment.NewLine));
            monsterMessages.ParsedRule.ShouldBe("^a((aa|bb)(ab|ba)|(ab|ba)(aa|bb))b$");
            return monsterMessages.IsValid(value);
        }

        [Test]
        public void Part1()
        {
            var monsterMessages = new MonsterMessages(_input[0].Split(Environment.NewLine));
            var answer = _input[1].Split(Environment.NewLine).Count(monsterMessages.IsValid);
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}