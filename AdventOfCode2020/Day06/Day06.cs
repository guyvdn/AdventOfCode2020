using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day06
{
    public class Day06
    {
        private string[] _testData;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData = File.ReadAllText("Data/Day06_testdata.txt").Split(Environment.NewLine + Environment.NewLine);
            _input = File.ReadAllText("Data/Day06_input.txt").Split(Environment.NewLine + Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            _testData.Length.ShouldBe(5);
            var questionnaires = _testData.Select(data => new Questionnaire(data));
            questionnaires.Sum(q => q.NumberOfQuestionsAnsweredYes()).ShouldBe(11);
        }


        [Test]
        public void Part1()
        {
            _testData.Length.ShouldBe(5);
            var questionnaires = _input.Select(data => new Questionnaire(data));
            var answer = questionnaires.Sum(q => q.NumberOfQuestionsAnsweredYes());
            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2WithTestData()
        {
            _testData.Length.ShouldBe(5);
            var questionnaires = _testData.Select(data => new Questionnaire(data));
            questionnaires.Sum(q => q.NumberOfQuestionsAnsweredYesByEveryone()).ShouldBe(6);
        }

        [Test]
        public void Part2()
        {
            _testData.Length.ShouldBe(5);
            var questionnaires = _input.Select(data => new Questionnaire(data));
            var answer = questionnaires.Sum(q => q.NumberOfQuestionsAnsweredYesByEveryone());
            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}