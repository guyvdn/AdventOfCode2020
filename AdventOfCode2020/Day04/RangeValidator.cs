using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class RangeValidator : AbstractValidator<string>
    {
        public RangeValidator(int minValue, int maxValue)
        {
            RuleFor(x => x)
                .TransformToInt()
                .NotNull().WithMessage("must be numeric")
                .InclusiveBetween(minValue, maxValue);
        }
    }
}