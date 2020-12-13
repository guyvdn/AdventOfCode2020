namespace AdventOfCode2020.Day12
{
    public class WayPoint
    {
        public int NorthSouth { get; set; }
        public int EastWest { get; set; }

        internal WayPoint Clone() => new() { NorthSouth = NorthSouth, EastWest = EastWest };
    }
}