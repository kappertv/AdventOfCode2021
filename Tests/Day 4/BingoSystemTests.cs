using System;
using System.IO;
using AdventOfCode2021.Day4;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Tests.Day4
{
    [TestClass]
    public class BingoSystemTests
    {
        BingoSystem _sut;
        BingoSystem _sut2;

        [TestInitialize]
        public void TestInitialize()
        {
            var lines = File.ReadAllLines("Day 4//input.txt");
            _sut = new BingoSystem(lines);

            var lines2 = File.ReadAllLines("Day 4//myinput.txt");
            _sut2 = new BingoSystem(lines2);
        }

        [TestMethod]
        public void GetLastNumberCalledBeforeFirstWinningBoard()
        {
            var result = _sut.GetLastDrawnNumberBeforeWin();

            result.ShouldBe(24);
        }

        [TestMethod]
        public void GetScoreOfWinningBoard()
        {
            var result = _sut.GetScoreOfWinningBoard();

            result.ShouldBe(188);
        }

        [TestMethod]
        public void GetFinalSCore()
        {
            var result = _sut.GetFinalScore();

            result.ShouldBe(4512);
        }

        [TestMethod]
        public void GetLastNumberCalledForLastWinningBoard()
        {
            var result = _sut.GetNumberCalledForLastWinningBoard();

            result.ShouldBe(13);
        }

        [TestMethod]
        public void GetFinalSCoreLastBoardToWin()
        {
            var result = _sut.GetFinalScoreLastBoardToWin();

            result.ShouldBe(1924);
        }


        [TestMethod]
        public void GetLastNumberCalledBeforeFirstWinningBoard2()
        {
            var result = _sut2.GetLastDrawnNumberBeforeWin();

            result.ShouldBe(42);
        }

        [TestMethod]
        public void GetScoreOfWinningBoard2()
        {
            var result = _sut2.GetScoreOfWinningBoard();

            result.ShouldBe(751);
        }

        [TestMethod]
        public void GetFinalSCore2()
        {
            var result = _sut2.GetFinalScore();

            result.ShouldBe(31542);
        }

        [TestMethod]
        public void GetFinalSCore2LastWinning()
        {
            var result = _sut2.GetFinalScoreLastBoardToWin();

            result.ShouldBe(31542);
        }

    }
}
