using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day16
{
    public class TicketTranslator
    {
        private readonly Rule[] _rules;
        private readonly Ticket[] _nearbyTickets;
        public Ticket MyTicket { get; }

        public TicketTranslator(IReadOnlyList<string> notes)
        {
            _rules = notes[0].Split(Environment.NewLine).Select(Rule.Create).ToArray();
            MyTicket = new Ticket(notes[1].Split(Environment.NewLine).Last());
            _nearbyTickets = notes[2].Split(Environment.NewLine).Skip(1).Select(Ticket.Create).ToArray();
        }

        public int GetErrorRate()
        {
            return _nearbyTickets.Sum(ticket => ticket.GetErrorRate(_rules));
        }

        public IEnumerable<FieldMap> GetFieldMap()
        {
            var validTickets = _nearbyTickets.Where(ticket => ticket.IsValid(_rules)).ToList();
            var numberOfFields = MyTicket.Values.Length;
            var validRuleFieldCombo = new List<FieldMap>();

            foreach (var rule in _rules)
            {
                for (var field = 0; field < numberOfFields; field++)
                {
                    if (validTickets.All(ticket => rule.IsValid(ticket.Values[field])))
                    {
                        validRuleFieldCombo.Add(new FieldMap(rule.Name, field));
                    }
                }
            }

            while (validRuleFieldCombo.Count > 0)
            {
                var fieldMap = validRuleFieldCombo
                    .GroupBy(x => x.FieldName)
                    .First(x => x.Count() == 1)
                    .First();

                yield return fieldMap;

                validRuleFieldCombo.RemoveAll(x => x.FieldIndex == fieldMap.FieldIndex);
            }
        }
    }
}