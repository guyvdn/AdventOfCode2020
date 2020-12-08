namespace AdventOfCode2020.Day08
{
    public sealed record Command
    {
        public Command(string operation, int argument) => (Operation, Argument) = (operation, argument);

        public string Operation { get; private set; }
        public int Argument { get; }
        public bool IsExecuted { get; set; }

        public bool Switch()
        {
            switch (Operation)
            {
                case "nop":
                    Operation = "jmp";
                    return true;
                case "jmp":
                    Operation = "nop";
                    return true;
                default:
                    return false;
            }
        }
    }
}