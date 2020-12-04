using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class PassportValidator1: AbstractValidator<Passport>
    {
        public PassportValidator1()
        {
            RuleFor(x => x.BirthYear).NotEmpty();
            RuleFor(x => x.IssueYear).NotEmpty();
            RuleFor(x => x.ExpirationYear).NotEmpty();
            RuleFor(x => x.Height).NotEmpty();
            RuleFor(x => x.HairColor).NotEmpty();
            RuleFor(x => x.EyeColor).NotEmpty();
            RuleFor(x => x.PassportId).NotEmpty();
        }
    }
}