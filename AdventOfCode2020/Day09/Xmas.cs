using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day09
{
    public class Xmas
    {
        private readonly long[] _data;

        public Xmas(IEnumerable<string> data)
        {
            _data = data.Select(long.Parse).ToArray();
        }

        public long GetInvalidNumber(int preamble)
        {
            for (var index = preamble; index < _data.Length; index++)
            {
                var valueToValidate = _data[index];
                var preambleData = _data.Skip(index - preamble).Take(preamble).ToList();
                if (!preambleData.Any(x => preambleData.Any(y => x + y == valueToValidate)))
                    return valueToValidate;
            }

            return -1;
        }

        public long FindWeakness(long invalidNumber)
        {
            for (var index = 0; index < _data.Length; index++)
            {
                var sum = 0L;
                var numbersToTake = 1;
                while (sum < invalidNumber)
                {
                    var numbers = _data.Skip(index).Take(numbersToTake).ToList();
                    sum = numbers.Sum();
                    if (sum == invalidNumber)
                    {
                        return numbers.Min() + numbers.Max();
                    }
                    numbersToTake++;
                }
            }

            return -1;
        }
    }
}