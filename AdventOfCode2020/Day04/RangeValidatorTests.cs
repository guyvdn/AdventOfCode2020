using NUnit.Framework;

namespace AdventOfCode2020.Day04
{
    public class RangeValidatorTests
    {
        private RangeValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new RangeValidator(1920, 2002);
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase("200", ExpectedResult = false)]
        [TestCase("20000", ExpectedResult = false)]
        [TestCase("1919", ExpectedResult = false)]
        [TestCase("1920", ExpectedResult = true)]
        [TestCase("1921", ExpectedResult = true)]
        [TestCase("2001", ExpectedResult = true)]
        [TestCase("2002", ExpectedResult = true)]
        [TestCase("2003", ExpectedResult = false)]
        public bool It_should_validate_correctly(string value)
        {
            var validationResult = _validator.Validate(value);
            TestContext.WriteLine(validationResult.ToString());
            return validationResult.IsValid;
        }
    }
}