using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public static class ValidationExtensions
    {
        public static IRuleBuilder<T, int?> TransformToInt<T>(this IRuleBuilderInitial<T, string> ruleBuilder)
        {
            return ruleBuilder.Transform(value => int.TryParse(value, out int val) ? (int?)val : null);
        }

        public static IRuleBuilderOptions<T, string> MustBeBetween<T>(this IRuleBuilderInitial<T, string> ruleBuilder, int minValue, int maxValue)
        {
            return ruleBuilder.SetValidator(new RangeValidator(minValue, maxValue));
        }
    }
}