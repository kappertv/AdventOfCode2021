using System;
using System.Linq;

namespace AdventOfCode2021.Day7
{
    public class CrabFuelCalculator
    {
        int[] crabposition;
        int max;
        int min;
        public CrabFuelCalculator(string line)
        {
            var parts = line.Split(",");
            var crabpositions = parts.Select(s => int.Parse(s)).ToArray();
            crabposition = crabpositions;
            max = crabposition.Max();
            min = crabposition.Min();
            var result = Enumerable.Range(min, max - min).Select(height => (height, fuel: crabposition.Sum(i => Math.Abs(i - height)))).Min(t => t.fuel);
        }

        public long[] GetCheapestPositionToAllign(bool increasingconsumption)
        {

            long[] lowestFuelAtPosition = new long[2];
            lowestFuelAtPosition[0] = long.MaxValue; //fuel
            lowestFuelAtPosition[1] = 0; // position


            for (int i = min; i <= max; i++)
            {
                var neededFuel = GetNeededFuelForPosition(i, increasingconsumption);
                if (lowestFuelAtPosition[0] == neededFuel) throw new Exception("equal distance");
                if (lowestFuelAtPosition[0] > neededFuel)
                {
                    lowestFuelAtPosition[0] = neededFuel;
                    lowestFuelAtPosition[1] = i;
                }
            }

            return lowestFuelAtPosition;
        }

        private int GetIncreasingFuel(int neededFuel)
        {
            var result = 0;
            for (int i = 1; i <= neededFuel; i++)
            {
                result += i;
            }
            return result;
        }

        private long GetNeededFuelForPosition(int position, bool inc)
        {
            long result = 0;
            for (int i = 0; i < crabposition.Length;i++)
            {
                var distance = Math.Abs(crabposition[i] - position);
                if (inc)
                {
                    distance = GetIncreasingFuel(distance);
                }
                result += distance;
            }
            return result;
        }
    }
}
