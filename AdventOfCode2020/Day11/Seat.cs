namespace AdventOfCode2020.Day11
{
    public sealed class Seat
    {
        public Seat(char value, int row, int column)
        {
            Value = value;
            NewValue = value;
            IsOccupied = Value == '#';
            IsEmpty = Value == 'L';
            Row = row;
            Column = column;
            Diagonal1 = column - row;
            Diagonal2 = column + row;
        }

        public char Value { get; private set; }
        public char NewValue { get; set; }
        public int Row { get; }
        public int Column { get; }
        public int Diagonal1 { get; }
        public int Diagonal2 { get; }

        public void Commit()
        {
            Value = NewValue;
            IsOccupied = Value == '#';
            IsEmpty = Value == 'L';
        }

        public bool IsAdjacentTo(Seat seat)
        {
            return this != seat &&
                   Row >= seat.Row - 1 && Row <= seat.Row + 1 &&
                   Column >= seat.Column - 1 && Column <= seat.Column + 1;
        }

        public bool IsOccupied { get; private set; }

        public bool IsEmpty { get; private set; }
    }
}