using System;
using System.IO;
using System.Linq;
using AdventOfCode2021.Day6;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day6
{
    [TestClass]
    public class LanternFishSimulatorTests
    {
        LanternFishSimulator _sut;

        LanternFishSimulator _myinputSut;

        [TestInitialize]
        public void Initialize()
        {
            var line = File.ReadAllLines("Day 6//sampleinput.txt").Single();
            _sut = new LanternFishSimulator(line);

            var myline = File.ReadAllLines("Day 6//myinput.txt").Single();
            _myinputSut = new LanternFishSimulator(myline);
        }

        [TestMethod]
        public void NumberOfFishAfter18Days()
        {
            var result = _sut.GetNumberOfFishAfterNDays(18);

            result.ShouldBe(26);
        }

        [TestMethod]
        public void NumberOfFishAfter80Days()
        {
            var result = _sut.GetNumberOfFishAfterNDays(80);

            result.ShouldBe(5934);
        }

        [TestMethod]
        public void NumberOfFishAfter256Days()
        {
            var result = _sut.GetNumberOfFishAfterNDays(256);

            result.ShouldBe(26984457539);
        }

        [TestMethod]
        public void NumberOfFishAfter80DaysMyInput()
        {
            var result = _myinputSut.GetNumberOfFishAfterNDays(80);

            result.ShouldBe(5934); // ik ben benieuwd!
        }

        [TestMethod]
        public void NumberOfFishAfter256DaysMyInput()
        {
            var result = _myinputSut.GetNumberOfFishAfterNDays(256);

            result.ShouldBe(5934); // ik ben benieuwd!
        }

        [TestMethod]
        public void CalculateNumberOfFish_WithTimer3_18Days()
        {
            var simulateOne = new LanternFishSimulator("3");
            var result = simulateOne.GetNumberOfFishAfterNDays(18);
            var calculatedresult = _sut.CalculateNumberOfBornFishIncludeParent(3, 18);

            calculatedresult.ShouldBe(result);
        }

        [TestMethod]
        public void CalculateNumberOfFish_WithTimer3_80Days()
        {
            var simulateOne = new LanternFishSimulator("3");
            var result = simulateOne.GetNumberOfFishAfterNDays(80);
            var calculatedresult = _sut.CalculateNumberOfBornFishIncludeParent(3, 80);

            calculatedresult.ShouldBe(result);
        }

        [TestMethod]
        public void CalculateNumberOfFish_WithTimer3_256Days()
        {
            var simulateOne = new LanternFishSimulator("3");
            var result = simulateOne.GetNumberOfFishAfterNDays(256);
            var calculatedresult = _sut.CalculateNumberOfBornFishIncludeParent(3, 80);

            calculatedresult.ShouldBe(result);
        }

    }
}
