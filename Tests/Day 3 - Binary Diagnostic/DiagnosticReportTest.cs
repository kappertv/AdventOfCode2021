using System.IO;
using AdventOfCode2021.Day3BinaryDiagnostic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests
{
    [TestClass]
    public class DiagnosticReportTest
    {
        DiagnosticReport _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            var lines = File.ReadAllLines("Day 3 - Binary Diagnostic//test-input.txt");
            _sut = new DiagnosticReport(lines);

        }

        [TestMethod]
        public void GetGammaRate()
        {
            var result = _sut.GetGammaRate();

            result.ShouldBe(22);
        }

        [TestMethod]
        public void GetEpsilonRate()
        {
            var result = _sut.GetEpsilonRate();

            result.ShouldBe(9);
        }

        [TestMethod]
        public void GetOxygenGeneratorRating()
        {
            var result = _sut.GetOxygenGeneratorRating();

            result.ShouldBe(23);
        }

        [TestMethod]
        public void GetCO2ScrubberRating()
        {
            var result = _sut.GetCO2ScrubberRating();
            result.ShouldBe(10);
        }

        [TestMethod]
        public void GetLifeSupportRating()
        {
            var result = _sut.GetLifeSupportRating();

            result.ShouldBe(230);
        }
    }
}
