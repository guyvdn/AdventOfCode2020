namespace AdventOfCode2020.Day12
{
    public class CurrentPosition
    {
        public CurrentPosition()
        {
            Direction = 'E';
            NorthSouth = 0;
            EastWest = 0;
        }

        public char Direction { get; set; }
        public int NorthSouth { get; set; }
        public int EastWest { get; set; }
    }
}