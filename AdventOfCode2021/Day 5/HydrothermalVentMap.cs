using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day5
{
    public class HydrothermalVentMap
    {
        private List<VentLine> _ventlines;
        private List<DangerPoint> _dangerpoints = new List<DangerPoint>();
        public HydrothermalVentMap(List<VentLine> ventlines) 
        {
            _ventlines = ventlines;
            BuildDangerPoints();
        }

        private void BuildDangerPoints()
        {
            foreach (var ventline in _ventlines)
            {
                if (ventline.IsHorizontal() || ventline.IsVertical())
                {
                    ProcessHorizontalOrVerticalVentline(ventline);
                }
                else
                {
                    ProcessDiagonalVentline(ventline);
                }
            }
        }

        private void ProcessDiagonalVentline(VentLine ventLine)
        {
            var distanceX = ventLine.HighestX() - ventLine.LowestX();
            var distancey = ventLine.HighestY() - ventLine.LowestY();
            if (distanceX != distancey) throw new Exception("unexpected diagonal distance");

            foreach (var point in ventLine.GetPointsForDiagonalLine())
            {
                var dp = GetOrAddDangerPoint(point.X, point.Y);
                dp.IncreaseDanger();
            }
        }

        private void ProcessHorizontalOrVerticalVentline(VentLine ventLine)
        {
            for (int i = ventLine.LowestX(); i <= ventLine.HighestX(); i++)
            {
                for (int j = ventLine.LowestY(); j <= ventLine.HighestY(); j++)
                {
                    var dp = GetOrAddDangerPoint(i, j);
                    dp.IncreaseDanger();
                }
            }
        }

        private DangerPoint GetOrAddDangerPoint(int x, int y)
        {
            var result = _dangerpoints.SingleOrDefault(dp => dp.X == x && dp.Y == y);

            if (result == default(DangerPoint))
            {
                result = new DangerPoint(x, y);
                _dangerpoints.Add(result);
            }

            return result;
        }

        public List<DangerPoint> GetDangerPoints()
        {
            return _dangerpoints;
        }
    }
}
