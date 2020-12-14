using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day14
{
    public class Decoder
    {
        private readonly string[] _program;

        public Decoder(string[] program)
        {
            _program = program;
        }

        public void Execute(Action<string, long, long> function)
        {
            var mask = "";

            foreach (var command in _program)
            {
                if (command.StartsWith("mask"))
                {
                    mask = command[7..];
                    continue;
                }

                var contents = Regex.Matches(command, @"\d+");
                var address = long.Parse(contents[0].Value);
                var value = long.Parse(contents[1].Value);

                function(mask, address, value);
            }
        }

        public void ValueDecoding(string mask, long address, long value)
        {
            var decoded = value.ApplyMask(mask);
            Memory[address] = decoded;
        }

        public void AddressDecoding(string mask, long address, long value)
        {
            var addresses = address.ApplyFloatingMask(mask);
            foreach (var a in addresses)
            {
                Memory[a] = value;
            }
        }

        public Dictionary<long, long> Memory { get; } = new();
    }
}