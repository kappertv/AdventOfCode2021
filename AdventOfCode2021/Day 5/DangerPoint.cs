using System;
namespace AdventOfCode2021.Day5
{
    public class DangerPoint: IEquatable<DangerPoint>
    {
        public int X { get; }
        public int Y { get; }
        private int dangerCount = 0;
        public DangerPoint(int px, int py)
        {
            X = px;
            Y = py;
        }

        public bool Equals(DangerPoint other)
        {
            return (this.X == other.X) && (this.Y == other.Y);
        }

        public void IncreaseDanger()
        {
            dangerCount++;
        }

        public int GetDangerCount()
        {
            return dangerCount;
        }
    }
}
