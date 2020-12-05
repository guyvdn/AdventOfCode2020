using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day05
{
    public static class RegexExtensions
    {
        public static string RegexReplace(this string value, string pattern, string replacement)
        {
            return Regex.Replace(value, pattern, replacement);
        }
    }
}