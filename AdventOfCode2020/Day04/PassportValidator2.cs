using FluentValidation;

namespace AdventOfCode2020.Day04
{
    public class PassportValidator2 : AbstractValidator<Passport>
    {
        public PassportValidator2()
        {
            RuleFor(x => x.BirthYear).NotNull().SetValidator(new RangeValidator(1920, 2002));
            RuleFor(x => x.IssueYear).NotNull().SetValidator(new RangeValidator(2010, 2020));
            RuleFor(x => x.ExpirationYear).NotNull().SetValidator(new RangeValidator(2020, 2030));
            RuleFor(x => x.Height).NotNull().SetValidator(new HeightValidator());
            RuleFor(x => x.HairColor).NotNull().SetValidator(new HairColorValidator());
            RuleFor(x => x.EyeColor).NotNull().SetValidator(new EyeColorValidator());
            RuleFor(x => x.PassportId).NotNull().SetValidator(new PassportIdValidator());
        }
    }
}