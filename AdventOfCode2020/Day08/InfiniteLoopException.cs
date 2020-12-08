using System;

namespace AdventOfCode2020.Day08
{
    [Serializable]
    public sealed class InfiniteLoopException : Exception
    {
        public int Accumulator { get; init; }
    }
}