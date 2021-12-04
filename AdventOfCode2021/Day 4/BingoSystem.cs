using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    public class BingoSystem
    {
        List<BingoBoard> bingoBoards = new List<BingoBoard>();
        IEnumerable<int> numbersDrawn;
        BingoBoard winningBoard;
        BingoBoard lastWinningBoard;
        int lastDrawnNumber;
        int lastDrawnNumberForLastWinningBoard;
        public BingoSystem(string[] lines)
        {
            numbersDrawn = lines.First().Split(",").Select(s => int.Parse(s));
            ReadBingoBoards(lines.Skip(1));
        }

        private void ReadBingoBoards(IEnumerable<string> lines)
        {
            var linesArr = lines.ToArray();
            for (int i=0;i< linesArr.Count();i+=6)
            {
                List<string> board = new List<string>();
                for (int j = i + 1; j < i + 6; j++)
                {
                    board.Add(linesArr[j]);
                }
                bingoBoards.Add(new BingoBoard(board.ToArray()));
            }
        }

        public int GetScoreOfWinningBoard()
        {
            if (winningBoard == default(BingoBoard))
            {
                GetLastDrawnNumberBeforeWin();
            }

            return winningBoard.GetScore();
        }

        public int GetFinalScore()
        {
            return GetLastDrawnNumberBeforeWin() * GetScoreOfWinningBoard();
        }

        public int GetNumberCalledForLastWinningBoard()
        {
            if (lastDrawnNumberForLastWinningBoard != default(int)) return lastDrawnNumberForLastWinningBoard;
            var winningBoards = 0;

            foreach (var drawNumber in numbersDrawn)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    if (bingoBoard.Wins()) continue;
                    bingoBoard.AddDrawnNumber(drawNumber);

                    if (bingoBoard.Wins())
                    {
                        winningBoards++;
                    }
                    if (winningBoards == bingoBoards.Count())
                    {
                        lastDrawnNumberForLastWinningBoard = drawNumber;
                        lastWinningBoard = bingoBoard;
                        return drawNumber;
                    }
                }
            }
            throw new Exception("no winning board found");
        }

        public int GetFinalScoreLastBoardToWin()
        {
            var lastdrawnnumber = GetNumberCalledForLastWinningBoard();
            return lastdrawnnumber * lastWinningBoard.GetScore();
        }

        public static int GetFinalScoreFromInput()
        {
            var bs = new BingoSystem(File.ReadAllLines("Day 4//myinput.txt"));

            return bs.GetFinalScore();
        }

        public int GetLastDrawnNumberBeforeWin()
        {
            if (lastDrawnNumber != default(int)) return lastDrawnNumber;

            foreach (var drawNumber in numbersDrawn)
            {
                foreach (var bingoBoard in bingoBoards)
                {
                    bingoBoard.AddDrawnNumber(drawNumber);

                    if (bingoBoard.Wins())
                    {
                        winningBoard = bingoBoard;
                        lastDrawnNumber = drawNumber;
                    }
                }
                if (winningBoard != default)
                    return drawNumber;
            }
            throw new Exception("no winning board found");
        }
    }
}
