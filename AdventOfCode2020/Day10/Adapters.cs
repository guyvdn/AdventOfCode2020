using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Caching.Memory;

namespace AdventOfCode2020.Day10
{
    public class Adapters
    {
        private readonly List<int> _jolts;
        private readonly int _maxJolt;
        private readonly MemoryCache _cache = new(new MemoryCacheOptions());

        public Adapters(IReadOnlyCollection<int> jolts)
        {
            _jolts = new List<int> { 0 };
            _jolts.AddRange(jolts);
            _maxJolt = jolts.Max() + 3;
            _jolts.Add(_maxJolt);
            _jolts = _jolts.OrderBy(jolt => jolt).ToList();
        }

        public int CountDifference(int jolt)
        {
            var count = 0;

            for (var index = 0; index < _jolts.Count - 1; index++)
            {
                if (_jolts[index + 1] - _jolts[index] == jolt)
                    count++;
            }

            return count;
        }

        public long CountPossibleCombinations(long startValue = 0)
        {
            var count = 0L;

            foreach (var jolt in _jolts.Where(jolt => jolt > startValue && jolt <= startValue + 3))
            {
                if (jolt == _maxJolt)
                    return 1;

                count += _cache.GetOrCreate(jolt, _ => CountPossibleCombinations(jolt));
            }

            return count;
        }
    }
}