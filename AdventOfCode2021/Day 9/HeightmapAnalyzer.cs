using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day9
{
    public class HeightmapAnalyzer
    {
        public int[,] heightmap;
        private int maxY;
        private int maxX;
        public HeightmapAnalyzer(string[] lines)
        {
            maxX = lines.First().Length;
            maxY = lines.Length;

            heightmap = new int[maxY, maxX];
            for (int y=0;y<maxY;y++)
            {
                for (int x=0;x<maxX;x++)
                {
                    heightmap[y, x] = int.Parse(lines[y][x].ToString());
                }
            }
        }

        public int[] GetLowPoints()
        {
            var result = new List<int>();
            for (int y=0;y<maxY;y++)
            {
                for (int x=0;x<maxX;x++)
                {
                    var p = heightmap[y, x];
                    var surrounding = GetSurroundingHeights(y, x);
                    if (p < surrounding.Min())
                    {
                        result.Add(p);
                    }
                }
            }

            return result.ToArray();
        }

        public List<List<int>> GetBassins()
        {
            var result = new List<List<int>>();
            for (int y = 0; y < maxY; y++)
            {
                for (int x = 0; x < maxX; x++)
                {
                    var p = heightmap[y, x];
                    var surrounding = GetSurroundingHeights(y, x);
                    if (p < surrounding.Min())
                    {
                        var bassin = GetBassin(y, x);
                        
                    }
                }
            }

            return result;
        }

        private int[] GetBassin(int y, int x)
        {
            var result = new List<int>();

            if (y != 0)
            {
                var h = heightmap[y - 1, x];
                if (h != 9)
                {
                    result.Add(heightmap[y - 1, x]);
                }
            }
            if (y != (maxY - 1))
            {
                result.Add(heightmap[y + 1, x]);
            }
            if (x != (maxX - 1))
            {
                result.Add(heightmap[y, x + 1]);
            }
            if (x != 0)
            {
                result.Add(heightmap[y, x - 1]);
            }
            return result.ToArray();
        }

        public object GetThreeLargestBassinsMultiplied()
        {
            var bassins = GetBassins();
            return true;
        }

        private int[] GetSurroundingHeights(int y, int x)
        {
            var result = new List<int>();

            if (y != 0)
            {
                result.Add(heightmap[y - 1, x]);
            }
            if (y != (maxY-1))
            {
                result.Add(heightmap[y + 1, x]);
            }
            if (x != (maxX-1))
            {
                result.Add(heightmap[y, x + 1]);
            }
            if (x != 0)
            {
                result.Add(heightmap[y, x - 1]);
            }
            return result.ToArray();
        }

        public int GetSumOfRiskLevels()
        {
            var lowpoints = GetLowPoints();
            return lowpoints.Sum() + lowpoints.Count();
        }
    }
}
