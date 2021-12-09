using System;
using System.IO;
using System.Linq;
using AdventOfCode2021.Day8;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day8
{
    [TestClass]
    public class SevenSegmentSearchTests
    {
        SevenSegmentSearch _sut;
        SevenSegmentSearch _sutmyinput;

        public SevenSegmentSearchTests()
        {
            var line = File.ReadAllLines("Day 8//sampleinput.txt");
            _sut = new SevenSegmentSearch(line);

            var myline = File.ReadAllLines("Day 8//myinput.txt");
            _sutmyinput = new SevenSegmentSearch(myline);
        }

        [TestMethod]
        public void GetEasyNumbers()
        {
            var result = _sut.GetNumberOfEasyDigits();

            result.ShouldBe(26);
        }

        [TestMethod]
        public void GetEasyNumbersMyInput()
        {
            var result = _sutmyinput.GetNumberOfEasyDigits();

            result.ShouldBe(26);
        }
    }
}
