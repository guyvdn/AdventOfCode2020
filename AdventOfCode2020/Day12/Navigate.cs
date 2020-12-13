using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day12
{
    public class Navigate
    {
        private readonly Instruction[] _instructions;
        private readonly CurrentPosition _currentPosition = new();

        public Navigate(IEnumerable<string> instructions)
        {
            _instructions = instructions.Select(Instruction.Create).ToArray();
        }

        public int ToDestination()
        {
            foreach (var instruction in _instructions)
            {
                instruction.Execute(_currentPosition);
            }

            return _currentPosition.NorthSouth + _currentPosition.EastWest;
        }

        public int ToWayPoint()
        {
            var wayPoint = new WayPoint { EastWest = 10, NorthSouth = -1 };

            foreach (var instruction in _instructions)
            {
                instruction.Execute(_currentPosition, wayPoint);
            }

            return _currentPosition.NorthSouth + _currentPosition.EastWest;
        }
    }
}