using System.Linq;

namespace AdventOfCode2020.Day02
{
    public class Password
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
}