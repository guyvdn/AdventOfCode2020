using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class EyeColorValidator: AbstractValidator<string>
    {
        public EyeColorValidator()
        {
            RuleFor(x => x)
                .IsEnumName(typeof(EyeColorEnum), caseSensitive: false);
        }
    }
}