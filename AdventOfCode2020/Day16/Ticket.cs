using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class Ticket
    {
        public int[] Values { get; }

        public Ticket(string note)
        {
            Values = note
                .Split(",")
                .Select(int.Parse)
                .ToArray();
        }

        public static Ticket Create(string note) => new Ticket(note);

        public int GetErrorRate(Rule[] rules)
        {
            return Values.Where(value => !rules.Any(rule => rule.IsValid(value))).Sum();
        }

        public bool IsValid(Rule[] rules) => GetErrorRate(rules) == 0;
    }
}