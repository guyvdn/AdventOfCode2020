using System;
using System.Linq;

namespace AdventOfCode2020.Day06
{
    public class Questionnaire
    {
        private readonly string[] _values;

        public Questionnaire(string values)
        {
            _values = values.Split(Environment.NewLine);
        }

        public int NumberOfQuestionsAnsweredYes()
        {
            return string
                .Join("", _values)
                .Distinct()
                .Count();
        }
        
        public int NumberOfQuestionsAnsweredYesByEveryone()
        {
            var numberOfPeopleInGroup = _values.Length;
            return string
                .Join("", _values)
                .GroupBy(x => x)
                .Count(group => group.Count() == numberOfPeopleInGroup);
        }
    }
}