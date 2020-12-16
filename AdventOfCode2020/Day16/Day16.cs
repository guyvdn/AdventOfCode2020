using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace AdventOfCode2020.Day16
{
    public class Day16
    {
        private string[] _testData1;
        private string[] _testData2;
        private string[] _input;

        [OneTimeSetUp]
        public void SetUp()
        {
            _testData1 = File.ReadAllText("Data/Day16_testdata1.txt").Split(Environment.NewLine + Environment.NewLine);
            _testData2 = File.ReadAllText("Data/Day16_testdata2.txt").Split(Environment.NewLine + Environment.NewLine);
            _input = File.ReadAllText("Data/Day16_input.txt").Split(Environment.NewLine + Environment.NewLine);
        }

        [Test]
        public void Part1WithTestData()
        {
            var ticketValidator = new TicketTranslator(_testData1);
            ticketValidator.GetErrorRate().ShouldBe(71);
        }

        [Test]
        public void Part1()
        {
            var ticketValidator = new TicketTranslator(_input);
            var answer = ticketValidator.GetErrorRate();
            TestContext.WriteLine($"Answer = {answer}");
        }

        [Test]
        public void Part2WithTestData()
        {
            var ticketValidator = new TicketTranslator(_testData2);
            var fieldMaps = ticketValidator.GetFieldMap().ToList();
            var myTicket = ticketValidator.MyTicket;

            int GetTicketValue(string fieldName)
            {
                return myTicket.Values[fieldMaps.Single(fm => fm.FieldName == fieldName).FieldIndex];
            }

            GetTicketValue("class").ShouldBe(12);
            GetTicketValue("row").ShouldBe(11);
            GetTicketValue("seat").ShouldBe(13);
        }

        [Test]
        public void Part2()
        {
            var ticketValidator = new TicketTranslator(_input);
            var fieldMaps = ticketValidator.GetFieldMap();
            var myTicket = ticketValidator.MyTicket;
            
            var answer = fieldMaps
                .Where(fm => fm.FieldName.StartsWith("departure"))
                .Aggregate(1L, (l, fieldMap) => l * myTicket.Values[fieldMap.FieldIndex]);

            TestContext.WriteLine($"Answer = {answer}");
        }
    }
}