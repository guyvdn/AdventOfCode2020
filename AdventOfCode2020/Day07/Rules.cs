using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day07
{
    public class Rules
    {
        private readonly List<Rule> _rules;

        public Rules(IEnumerable<string> rules)
        {
            _rules = rules.Select(x => new Rule(x)).ToList();
        }

        public IEnumerable<Rule> GetParents(string bagName)
        {
            var result = new List<Rule>();

            var parents = _rules.Where(r => r.Contents.Any(x => x.BagName == bagName)).ToList();
            result.AddRange(parents);

            foreach (var parent in parents)
            {
                result.AddRange(GetParents(parent.Name));
            }

            return result;
        }

        public long GetContentCount(string bagName)
        {
            return 1 + _rules
                .Single(r => r.Name == bagName)
                .Contents.Sum(bagContent => bagContent.NumberOfBags * GetContentCount(bagContent.BagName));
        }
    }
}