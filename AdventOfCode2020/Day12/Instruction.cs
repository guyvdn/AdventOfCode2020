using System;
using System.Collections.Generic;
using AdventOfCode2020.Day12.Instructions;

namespace AdventOfCode2020.Day12
{
    public abstract class Instruction
    {
        protected static readonly Dictionary<int, char> Directions = new() { { 0, 'N' }, { 1, 'E' }, { 2, 'S' }, { 3, 'W' } };
        protected int Units { get; private init; }

        public static Instruction Create(string instruction)
        {
            var direction = instruction[0];
            var units = int.Parse(instruction[1..]);

            return direction switch
            {
                'N' => new MoveNorth { Units = units },
                'S' => new MoveSouth { Units = units },
                'E' => new MoveEast { Units = units },
                'W' => new MoveWest { Units = units },
                'L' => new TurnLeft { Units = units },
                'R' => new TurnRight { Units = units },
                'F' => new MoveForward { Units = units },
                _ => throw new ArgumentOutOfRangeException(nameof(instruction))
            };
        }
        public abstract void Execute(CurrentPosition currentPosition);
        public abstract void Execute(CurrentPosition currentPosition, WayPoint wayPoint);
    }
}