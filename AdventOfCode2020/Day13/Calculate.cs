namespace AdventOfCode2020.Day13
{
    public static class Calculate
    {
        public static long GreatestCommonDivisor(long a, long b)
        {
            if (b == 0)
                return a;

            return GreatestCommonDivisor(b, a % b);
        }

        public static long LeastCommonMultiple(long a, long b)
        {
            return a * b / GreatestCommonDivisor(a, b);
        }
    }
}