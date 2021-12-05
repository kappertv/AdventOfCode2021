using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day5
{
    public class VentLine
    {
        public int X1 { get; }
        public int Y1 { get; }

        public int X2 { get; }
        public int Y2 { get; }
        public VentLine(string line)
        {
            var positons = line.Split(" -> ");
            var pos1 = positons[0].Split(",");
            X1 = int.Parse(pos1[0]);
            Y1 = int.Parse(pos1[1]);

            var pos2 = positons[1].Split(",");
            X2 = int.Parse(pos2[0]);
            Y2 = int.Parse(pos2[1]);
        }

        public List<Point> GetPointsForDiagonalLine()
        {
            if (IsHorizontal() || IsVertical()) throw new NotImplementedException("only diagonal ventlines");

            var xpoints = GetXPoints().ToList();
            var ypoints = GetYPoints().ToList();

            var result = new List<Point>();
            for (int i = 0; i<xpoints.Count;i++)
            {
                result.Add(new Point(xpoints[i], ypoints[i]));
            }
            return result;
        }

        private IEnumerable<int> GetXPoints()
        {
            if (X1 < X2)
            {
                for (int i = X1; i<= X2; i++)
                {
                    yield return i;
                }
            }
            else if(X1 > X2)
            {
                for (int i = X1; i >= X2; i--)
                {
                    yield return i;
                }
            }
            else
            {
                throw new Exception("not expected");
            }
        }

        private IEnumerable<int> GetYPoints()
        {
            if (Y1 < Y2)
            {
                for (int i = Y1; i <= Y2; i++)
                {
                    yield return i;
                }
            }
            else if (Y1 > Y2)
            {
                for (int i = Y1; i >= Y2; i--)
                {
                    yield return i;
                }
            }
            else
            {
                throw new Exception("not expected");
            }
        }

        public bool IsHorizontal()
        {
            return X1 == X2;
        }

        public bool IsVertical()
        {
            return Y1 == Y2;
        }

        public int LowestX()
        {
            return Math.Min(X1, X2);
        }

        public int HighestX()
        {
            return Math.Max(X1, X2);
        }

        public int LowestY()
        {
            return Math.Min(Y1, Y2);
        }

        public int HighestY()
        {
            return Math.Max(Y1, Y2);
        }

        public override string ToString()
        {
            return string.Format("{0},{1} -> {2}, {3}",X1,Y1,X2,Y2);
        }
    }
}
