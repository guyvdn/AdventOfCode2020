using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Caching.Memory;

namespace AdventOfCode2020.Day19
{
    public class MonsterMessages
    {
        private readonly Dictionary<int, string> _rules = new();
        private readonly MemoryCache _parsedRules = new(new MemoryCacheOptions());
        private readonly Dictionary<int, int> _recursionCount = new();

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
            
            if (_recursionCount.ContainsKey(ruleNumber) && _recursionCount[ruleNumber] > 4)
                return "";

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
                if (number == ruleNumber)
                    _recursionCount[number] = _recursionCount.ContainsKey(ruleNumber) ? _recursionCount[number] + 1 : 1;
                
                var regex = new Regex(Regex.Escape($" {number}"));
                rule = regex.Replace(rule, GetParsedRule(number), 1);
            }
        }

        public bool IsValid(string value)
        {
            return Regex.IsMatch(value, ParsedRule);
        }
    }
}