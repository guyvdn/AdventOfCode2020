using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day18
{
    public static class Math
    {
        public static long Calculate(string input)
        {
            input = RemoveParentheses(input, Calculate);
            input = RemoveSets(input, "+*");
            return long.Parse(input);
        }

        public static long CalculateAdvanced(string input)
        {
            input = RemoveParentheses(input, CalculateAdvanced);
            input = RemoveSets(input, "+");
            input = RemoveSets(input, "*");
            return long.Parse(input);
        }

        private static string RemoveParentheses(string input, Func<string, long> calculate)
        {
            while (input.Contains('('))
            {
                var firstClosing = input.IndexOf(')');
                var firstOpening = input.Substring(0, firstClosing).LastIndexOf('(');
                var subSet = input.Substring(firstOpening, firstClosing - firstOpening + 1);
                var subResult = calculate(subSet.Substring(1, subSet.Length - 2)).ToString();
                input = input.Replace(subSet, subResult);
            }

            return input;
        }

        private static string RemoveSets(string input, string pattern)
        {
            while (true)
            {
                var sets = Regex.Match(input, @$"(\d+ [{pattern}] \d+)");
                if (!sets.Success) 
                    return input;

                var firstSet = sets.Captures[0].Value;
                var setResult = CalculateSet(firstSet.Split(" "));

                var regex = new Regex(Regex.Escape(firstSet));
                input = regex.Replace(input, setResult.ToString(), 1);
            }
        }

        private static long CalculateSet(IReadOnlyList<string> input)
        {
            if (input.Count != 3)
                throw new ArgumentException("Input should have a length of 3");

            var value1 = long.Parse(input[0]);
            var value2 = long.Parse(input[2]);

            return input[1] switch
            {
                "*" => value1 * value2,
                "+" => value1 + value2,
                _ => throw new ArgumentException($"Invalid operator found: {input[1]}")
            };
        }

    }
}