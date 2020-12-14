using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day14
{
    public static class Extensions
    {
        public static long ApplyMask(this long value, string mask)
        {
            var bits = new BitArray(BitConverter.GetBytes(value)) { Length = mask.Length };

            for (var index = 0; index < mask.Length; index++)
            {
                var m = mask[^(index + 1)];
                if (m == 'X')
                    continue;

                bits.Set(index, m == '1');
            }

            return bits.ToInt64();
        }

        public static long[] ApplyFloatingMask(this long value, string mask)
        {
            var bits = new BitArray(BitConverter.GetBytes(value)) { Length = mask.Length };
            var results = new List<BitArray> { bits };

            for (var index = 0; index < mask.Length; index++)
            {
                switch (mask[^(index + 1)])
                {
                    case '1':
                        {
                            foreach (var r in results) r.Set(index, true);
                            break;
                        }
                    case 'X':
                        {
                            var clones = new List<BitArray>();

                            foreach (var r in results)
                            {
                                r.Set(index, true);
                                var clone = (BitArray)r.Clone();
                                clone.Set(index, false);
                                clones.Add(clone);
                            }

                            results.AddRange(clones);
                            break;
                        }
                }
            }

            return results.Select(x => x.ToInt64()).ToArray();
        }

        public static long ToInt64(this BitArray bits)
        {
            var output = new byte[8];
            bits.CopyTo(output, 0);
            return BitConverter.ToInt64(output, 0);
        }
    }
}