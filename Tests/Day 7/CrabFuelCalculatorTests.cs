using System;
using System.IO;
using System.Linq;
using AdventOfCode2021.Day7;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day7
{
    [TestClass]
    public class CrabFuelCalculatorTests
    {
        CrabFuelCalculator _sut;
        CrabFuelCalculator _sutmyinput;

        [TestInitialize]
        public void Initialize()
        {
            var line = File.ReadAllLines("Day 7//sampleinput.txt").Single();
            _sut = new CrabFuelCalculator(line);

            var myline = File.ReadAllLines("Day 7//myinput.txt").Single();
            _sutmyinput = new CrabFuelCalculator(myline);
        }

        [TestMethod]
        public void ResultOfSampleInputIsPosition2AndConsumption37()
        {
            var result = _sut.GetCheapestPositionToAllign(false);

            result[0].ShouldBe(37);
            result[1].ShouldBe(2);
        }

        [TestMethod]
        public void ResultOfSampleIncreasingConsumption()
        {
            var result = _sut.GetCheapestPositionToAllign(true);

            result[0].ShouldBe(168);
            result[1].ShouldBe(5);
        }

        [TestMethod]
        public void ResultOfMyInpuInput()
        {
            var result = _sutmyinput.GetCheapestPositionToAllign(true);

            result[0].ShouldBe(0);
            result[1].ShouldBe(2);
        }
    }
}
