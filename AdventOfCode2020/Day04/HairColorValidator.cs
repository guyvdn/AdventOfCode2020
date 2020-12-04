using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class HairColorValidator : AbstractValidator<string>
    {
        public HairColorValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Matches("^#[a-f0-9]{6}$");
        }
    }
}