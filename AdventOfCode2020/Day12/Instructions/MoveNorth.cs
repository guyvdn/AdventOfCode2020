namespace AdventOfCode2020.Day12.Instructions
{
    public class MoveNorth : Instruction
    {
        public override void Execute(CurrentPosition currentPosition)
        {
            currentPosition.NorthSouth -= Units;
        }

        public override void Execute(CurrentPosition currentPosition, WayPoint wayPoint)
        {
            wayPoint.NorthSouth -= Units;
        }
    }
}