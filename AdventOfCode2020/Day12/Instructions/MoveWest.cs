namespace AdventOfCode2020.Day12.Instructions
{
    public class MoveWest : Instruction
    {
        public override void Execute(CurrentPosition currentPosition)
        {
            currentPosition.EastWest -= Units;
        }

        public override void Execute(CurrentPosition currentPosition, WayPoint wayPoint)
        {
            wayPoint.EastWest -= Units;
        }
    }
}