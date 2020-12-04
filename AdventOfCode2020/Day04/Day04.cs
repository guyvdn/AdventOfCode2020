using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day04
{
    class Day04
    {
        private string[] _testData;
        private string[] _validPassportData;
        private string[] _invalidPassportData;
        private string[] _input;
        private PassportValidator1 _validator1;
        private PassportValidator2 _validator2;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day04_testdata.txt").Split(Environment.NewLine + Environment.NewLine);
            _validPassportData = File.ReadAllText("Data/Day04_valid_passports.txt").Split(Environment.NewLine + Environment.NewLine);
            _invalidPassportData = File.ReadAllText("Data/Day04_invalid_passports.txt").Split(Environment.NewLine + Environment.NewLine);
            _input = File.ReadAllText("Data/Day04_input.txt").Split(Environment.NewLine + Environment.NewLine);
            _validator1 = new PassportValidator1();
            _validator2 = new PassportValidator2();
        }
        
        [Test]
        public void Part1WithTestData()
        {
            _testData.Length.ShouldBe(4);
            _testData.Count(x =>
            {
                var passport = PassportFactory.CreatePassport(x);
                return _validator1.Validate(passport).IsValid;
            }).ShouldBe(2);
        }

        [Test]
        public void Part1()
        {
            var validCount = _input.Count(x =>
            {
                var passport = PassportFactory.CreatePassport(x);
                return _validator1.Validate(passport).IsValid;
            });
            TestContext.WriteLine($"Answer = {validCount}");
        }   
        
        [Test]
        public void Part2WithValidPasswords()
        {
            var validCount = _validPassportData.Count(x =>
            {
                var passport = PassportFactory.CreatePassport(x);
                return _validator2.Validate(passport).IsValid;
            });
            validCount.ShouldBe(4);
        }

        [Test]
        public void Part2WithInvalidPasswords()
        {
            var validCount = _invalidPassportData.Count(x =>
            {
                var passport = PassportFactory.CreatePassport(x);
                return _validator2.Validate(passport).IsValid;
            });
            validCount.ShouldBe(0);
        }

        [Test]
        public void Part2()
        {
            var validPassports = _input
                .Select(PassportFactory.CreatePassport)
                .Where(passport => _validator2.Validate(passport).IsValid)
                .ToList();

            TestContext.WriteLine($"Answer = {validPassports.Count}");
        }
    }
}
