namespace AdventOfCode2020.Day07
{
    public sealed record BagContent
    {
        public BagContent(int numberOfBags, string bagName) => (NumberOfBags, BagName) = (numberOfBags, bagName);

        public int NumberOfBags { get; }
        public string BagName { get; }
    }
}