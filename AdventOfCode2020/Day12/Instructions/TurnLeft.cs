using System.Linq;

namespace AdventOfCode2020.Day12.Instructions
{
    public class TurnLeft : Instruction
    {
        public override void Execute(CurrentPosition currentPosition)
        {
            var currentDirection = Directions.Single(x => x.Value == currentPosition.Direction).Key;
            var newDirection = (currentDirection + 4 - (Units / 90)) % 4;
            currentPosition.Direction = Directions[newDirection];
        }

        public override void Execute(CurrentPosition currentPosition, WayPoint wayPoint)
        {
            var currentWayPoint = wayPoint.Clone();

            switch (Units)
            {
                case 90:
                {
                    wayPoint.NorthSouth = -currentWayPoint.EastWest;
                    wayPoint.EastWest = currentWayPoint.NorthSouth;
                    break;
                }
                case 180:
                {
                    wayPoint.NorthSouth = -currentWayPoint.NorthSouth;
                    wayPoint.EastWest = -currentWayPoint.EastWest;
                    break;
                }
                case 270:
                {
                    wayPoint.NorthSouth = currentWayPoint.EastWest;
                    wayPoint.EastWest = -currentWayPoint.NorthSouth;
                    break;
                }
            }
        }
    }
}