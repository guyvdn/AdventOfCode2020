using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class PassportIdValidator: AbstractValidator<string>
    {
        public PassportIdValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .Matches("^[0-9]{9}$");
        }
    }
}