using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day11
{
    public class Seats
    {
        private readonly Seat[] _seats;

        public Seats(IReadOnlyList<string> arrangement)
        {
            var height = arrangement.Count;
            var width = arrangement.First().Length;
            var seats = new List<Seat>();

            for (var rowIndex = 0; rowIndex < height; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < width; columnIndex++)
                {
                    var value = arrangement[rowIndex][columnIndex];
                    if (value != '.')
                        seats.Add(new Seat(value, rowIndex, columnIndex));
                }
            }

            _seats = seats.ToArray();
        }

        public int ChangeSeats(Func<Seat[], Seat, int> visibilityFunction, int tolerance)
        {
            var seatsHaveChanged = true;
           
            while (seatsHaveChanged)
            {
                seatsHaveChanged = false;

                Parallel.ForEach(_seats, seat =>
                {
                    switch (seat.Value)
                    {
                        case 'L' when visibilityFunction(_seats, seat) == 0:
                            seat.NewValue = '#';
                            seatsHaveChanged = true;
                            break;
                        case '#' when visibilityFunction(_seats, seat) >= tolerance:
                            seat.NewValue = 'L';
                            seatsHaveChanged = true;
                            break;
                    }
                });

                Parallel.ForEach(_seats, seat => seat.Commit());
            }

            return _seats.Count(seat => seat.IsOccupied);
        }


        public static int GetOccupiedAdjacentSeats(Seat[] seats, Seat seat)
        {
            return seats.Count(s => s.IsOccupied && s.IsAdjacentTo(seat));
        }

        public static int GetVisibleAdjacentSeats(IEnumerable<Seat> seats, Seat seat)
        {
            var count = 0;

            // Look NW
            if (seats.Where(s => s.Diagonal1 == seat.Diagonal1 && s.Diagonal2 < seat.Diagonal2).OrderByDescending(s => s.Diagonal2).FirstOrDefault()?.Value == '#')
                count++;

            // Look N
            if (seats.Where(s => s.Column == seat.Column && s.Row < seat.Row).OrderByDescending(s => s.Row).FirstOrDefault()?.Value == '#')
                count++;

            // Look NE
            if (seats.Where(s => s.Diagonal2 == seat.Diagonal2 && s.Diagonal1 > seat.Diagonal1).OrderBy(s => s.Diagonal1).FirstOrDefault()?.Value == '#')
                count++;

            // Look E
            if (seats.Where(s => s.Row == seat.Row && s.Column > seat.Column).OrderBy(s => s.Column).FirstOrDefault()?.Value == '#')
                count++;

            // Look SE
            if (seats.Where(s => s.Diagonal1 == seat.Diagonal1 && s.Diagonal2 > seat.Diagonal2).OrderBy(s => s.Diagonal2).FirstOrDefault()?.Value == '#')
                count++;

            // Look S
            if (seats.Where(s => s.Column == seat.Column && s.Row > seat.Row).OrderBy(s => s.Row).FirstOrDefault()?.Value == '#')
                count++;

            // Look SW
            if (seats.Where(s => s.Diagonal2 == seat.Diagonal2 && s.Diagonal1 < seat.Diagonal1).OrderByDescending(s => s.Diagonal1).FirstOrDefault()?.Value == '#')
                count++;
            
            // Look W
            if (seats.Where(s => s.Row == seat.Row && s.Column < seat.Column).OrderByDescending(s => s.Column).FirstOrDefault()?.Value == '#')
                count++;

            return count;
        }
    }
}