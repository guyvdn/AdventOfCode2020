using NUnit.Framework;

namespace AdventOfCode2020.Day04
{
    public class PassportIdValidatorTests
    {
        private PassportIdValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new PassportIdValidator();
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("aaaaaaaaa", ExpectedResult = false)]
        [TestCase("000000001", ExpectedResult = true)]
        [TestCase("0123456789", ExpectedResult = false)]
        public bool It_should_validate_correctly(string value)
        {
            var validationResult = _validator.Validate(value);
            TestContext.WriteLine(validationResult.ToString());
            return validationResult.IsValid;
        }
    }
}