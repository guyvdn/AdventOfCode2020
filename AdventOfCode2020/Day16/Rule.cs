using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day16
{
    public class Rule
    {
        public string Name { get; }
        private readonly int[] _numbers;

        public Rule(string note)
        {
            Name = note.Substring(0, note.IndexOf(':'));

            _numbers = Regex
                .Matches(note, @"\d+")
                .Select(n => int.Parse((string) n.Value))
                .ToArray();
        }

        public static Rule Create(string note) => new Rule(note);

        public bool IsValid(int value)
        {
            return (value >= _numbers[0] && value <= _numbers[1] ||
                    value >= _numbers[2] && value <= _numbers[3]);
        }

        public override string ToString() => Name;
    }
}