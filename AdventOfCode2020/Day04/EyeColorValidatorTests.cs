using NUnit.Framework;

namespace AdventOfCode2020.Day04
{
    public class EyeColorValidatorTests
    {
        private EyeColorValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new EyeColorValidator();
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("amb", ExpectedResult = true)]
        [TestCase("blu", ExpectedResult = true)]
        [TestCase("brn", ExpectedResult = true)]
        [TestCase("gry", ExpectedResult = true)]
        [TestCase("grn", ExpectedResult = true)]
        [TestCase("hzl", ExpectedResult = true)]
        [TestCase("oth", ExpectedResult = true)]
        public bool It_should_validate_correctly(string value)
        {
            var validationResult = _validator.Validate(value);
            TestContext.WriteLine(validationResult.ToString());
            return validationResult.IsValid;
        }
    }
}