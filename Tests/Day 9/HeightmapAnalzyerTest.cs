using System;
using System.IO;
using AdventOfCode2021.Day9;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day9
{
    [TestClass]
    public class HeightmapAnalyzerTest
    {
        HeightmapAnalyzer _sut;
        HeightmapAnalyzer _sutmyinput;
        [TestInitialize]
        public void Initialize()
        {
            var line = File.ReadAllLines("Day 9//sampleinput.txt");
            _sut = new HeightmapAnalyzer(line);

            var myline = File.ReadAllLines("Day 9//myinput.txt");
            _sutmyinput = new HeightmapAnalyzer(myline);
        }

        [TestMethod]
        public void GetSumOfRiskLevels()
        {
            var result = _sut.GetSumOfRiskLevels();

            result.ShouldBe(15);
        }

        [TestMethod]
        public void GetSumOfRiskLevelsMyInput()
        {
            var result = _sutmyinput.GetSumOfRiskLevels();

            result.ShouldBe(15);
        }
    }
}
