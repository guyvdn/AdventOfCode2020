namespace AdventOfCode2020.Day12.Instructions
{
    public class MoveForward : Instruction
    {
        public override void Execute(CurrentPosition currentPosition)
        {
            currentPosition.NorthSouth += currentPosition.Direction switch
            {
                'N' => -Units,
                'S' => Units,
                _ => 0
            };

            currentPosition.EastWest += currentPosition.Direction switch
            {
                'E' => Units,
                'W' => -Units,
                _ => 0
            };
        }

        public override void Execute(CurrentPosition currentPosition, WayPoint wayPoint)
        {
            currentPosition.NorthSouth += wayPoint.NorthSouth * Units;
            currentPosition.EastWest += wayPoint.EastWest * Units;
        }
    }
}