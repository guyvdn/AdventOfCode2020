using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class HeightValidator : AbstractValidator<string>
    {
        public HeightValidator()
        {
            RuleFor(x => x)
                .Must(x => x.EndsWith("cm") || x.EndsWith("in"))
                .WithMessage("{PropertyName} must end with 'cm' or 'in'");

            RuleFor(x => x.Substring(0, x.Length - 2))
                .MustBeBetween(150, 193)
                .When(x => x.EndsWith("cm"));

            RuleFor(x => x.Substring(0, x.Length - 2))
                .MustBeBetween(59, 76)
                .When(x => x.EndsWith("in"));
        }
    }
}