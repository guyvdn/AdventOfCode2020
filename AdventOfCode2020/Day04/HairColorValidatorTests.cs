using NUnit.Framework;

namespace AdventOfCode2020.Day04
{
    public class HairColorValidatorTests
    {
        private HairColorValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new HairColorValidator();
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("#123abc", ExpectedResult = true)]
        [TestCase("#123abcd", ExpectedResult = false)]
        [TestCase("##23abc", ExpectedResult = false)]
        [TestCase("#abc123", ExpectedResult = true)]
        [TestCase("#123abf", ExpectedResult = true)]
        [TestCase("#123_bc", ExpectedResult = false)]
        [TestCase("#123_bg", ExpectedResult = false)]
        [TestCase("#123abz", ExpectedResult = false)]
        [TestCase("123abc", ExpectedResult = false)]
        public bool It_should_validate_correctly(string value)
        {
            var validationResult = _validator.Validate(value);
            TestContext.WriteLine(validationResult.ToString());
            return validationResult.IsValid;
        }
    }
}