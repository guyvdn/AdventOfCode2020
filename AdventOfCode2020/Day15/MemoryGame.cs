using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day15
{
    public class MemoryGame
    {
        private readonly Dictionary<int, int> _memory = new();
        private readonly int[] _startingNumbers;

        public MemoryGame(string startingNumbers)
        {
            _startingNumbers = startingNumbers.Split(",").Select(int.Parse).ToArray();
        }

        public int NumberAtTurn(int turns)
        {
            var turn = 1;
            var value = 0;

            while (turn <= _startingNumbers.Length && turn <= turns)
            {
                value = _startingNumbers[turn - 1];
                _memory[value] = turn;
                turn++;
            }

            while (turn <= turns)
            {
                if (_memory.TryGetValue(value, out var lastIndex))
                {
                    EndTurn(turn - 1 - lastIndex);
                }
                else
                {
                    EndTurn(0);
                }
            }

            void EndTurn(int newValue)
            {
                _memory[value] = turn - 1;
                value = newValue;
                turn++;
            }

            return value;
        }
    }
}