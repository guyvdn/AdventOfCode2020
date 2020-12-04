using System;
using System.Text.Json;

namespace AdventOfCode2020.Day04
{
    static class PassportFactory
    {
        public static Passport CreatePassport(string data)
        {
            var jsonData = $"{{\"{data}\"}}"
                .Replace(Environment.NewLine, " ")
                .Replace(" ", "\",\"")
                .Replace(":", "\":\"");

            return JsonSerializer.Deserialize<Passport>(jsonData);
        }
    }
}