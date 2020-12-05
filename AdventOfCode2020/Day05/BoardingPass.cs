using System;

namespace AdventOfCode2020.Day05
{
    public class BoardingPass
    {
        private readonly string _value;

        public BoardingPass(string value)
        {
            _value = value;
        }

        private string ToBinary()
        {
            return _value
                .RegexReplace("[FL]", "0")
                .RegexReplace("[BR]", "1");
        }

        public int SeatId => Convert.ToInt32(ToBinary(), 2);
    }
}