using System;
using System.IO;
using AdventOfCode2021.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day5
{
    [TestClass]
    public class HydrothermalVentsAnalyzerTests
    {

        HydrothermalVentAnalyzer _sut;

        HydrothermalVentAnalyzer _sutWithMyInput;

        [TestInitialize]
        public void Initialize()
        {
            var lines = File.ReadAllLines("Day 5//sampleInput.txt");
            _sut = new HydrothermalVentAnalyzer(lines);

            var mylines = File.ReadAllLines("Day 5//myinput.txt");
            _sutWithMyInput = new HydrothermalVentAnalyzer(mylines);
        }

        [TestMethod]
        public void GetNumberOfMostDangerousPositions_Returns_5()
        {
            var result = _sut.GetNumberOfMostDangerousPointsOnlyConsiderHorizontalAndVerticalVents();

            result.ShouldBe(5);
        }

        [TestMethod]
        public void GetNumberOfMostDangerousPositionsAlllines_Returns_12()
        {
            var result = _sut.GetNumberOfMostDangerousPointsAllLines();

            result.ShouldBe(12);
        }

        //[TestMethod]
        //public void GetNumverOfMostDangerousPosition_ForMyInput()
        //{
        //    var result = _sutWithMyInput.GetNumberOfMostDangerousPointsOnlyConsiderHorizontalAndVerticalVents();

        //    result.ToString().ShouldBe("ik ben benieuwd..");
        //}

        [TestMethod]
        public void GetNumverOfMostDangerousPositionAllLines_ForMyInput()
        {
            var result = _sutWithMyInput.GetNumberOfMostDangerousPointsAllLines();

            result.ShouldBe(21406);
        }

    }
}
