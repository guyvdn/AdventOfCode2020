using NUnit.Framework;

namespace AdventOfCode2020.Day04
{
    public class HeightValidatorTests
    {
        private HeightValidator _validator;

        [OneTimeSetUp]
        public void SetUp()
        {
            _validator = new HeightValidator();
        }

        [TestCase("", ExpectedResult = false)]
        [TestCase("150", ExpectedResult = false)]
        [TestCase("abc", ExpectedResult = false)]
        [TestCase("abccm", ExpectedResult = false)]
        [TestCase("abcin", ExpectedResult = false)]
        [TestCase("149cm", ExpectedResult = false)]
        [TestCase("150cm", ExpectedResult = true)]
        [TestCase("151cm", ExpectedResult = true)]
        [TestCase("192cm", ExpectedResult = true)]
        [TestCase("193cm", ExpectedResult = true)]
        [TestCase("194cm", ExpectedResult = false)]
        [TestCase("58in", ExpectedResult = false)]
        [TestCase("59in", ExpectedResult = true)]
        [TestCase("60in", ExpectedResult = true)]
        [TestCase("75in", ExpectedResult = true)]
        [TestCase("76in", ExpectedResult = true)]
        [TestCase("77in", ExpectedResult = false)]
        public bool It_should_validate_correctly(string value)
        {
            var validationResult = _validator.Validate(value);
            TestContext.WriteLine(validationResult.ToString());
            return validationResult.IsValid;
        }
    }
}