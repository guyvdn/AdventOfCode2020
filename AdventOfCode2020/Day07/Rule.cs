using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day07
{
    public class Rule
    {
        public string Name { get; }

        public List<BagContent> Contents { get; } = new();

        public Rule(string value)
        {
            var subValues = value.Split(" bags contain ");

            Name = subValues[0];

            var contents = Regex.Matches(subValues[1], @"(\d) (.*?)(?= bag)");
            foreach (Match content in contents)
            {
                Contents.Add(new BagContent(int.Parse(content.Groups[1].Value), content.Groups[2].Value));
            }
        }
    }
}