using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day5
{
    public class HydrothermalVentAnalyzer
    {
        List<VentLine> _ventLines;
        public HydrothermalVentAnalyzer(string[] lines)
        {
            _ventLines = lines.Select(l => new VentLine(l)).ToList();
        }

        public int GetNumberOfMostDangerousPointsOnlyConsiderHorizontalAndVerticalVents()
        {
            var horizontalAndVerticalVents = _ventLines.Where(vl => vl.IsHorizontal() || vl.IsVertical()).ToList();
            var hydrothermalVentMap = new HydrothermalVentMap(horizontalAndVerticalVents);

            var result = hydrothermalVentMap.GetDangerPoints().Where(dp => dp.GetDangerCount() >= 2).Count();
            return result;
        }

        public int GetNumberOfMostDangerousPointsAllLines()
        {
            var hydrothermalVentMap = new HydrothermalVentMap(_ventLines);

            var result = hydrothermalVentMap.GetDangerPoints().Where(dp => dp.GetDangerCount() >= 2).Count();
            return result;
        }
    }
}
