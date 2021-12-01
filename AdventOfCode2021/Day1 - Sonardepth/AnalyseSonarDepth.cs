using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day1Sonardepth
{
    public class AnalyseSonarDepth
    {
        public AnalyseSonarDepth()
        {
            
        }

        public long CountSonarIncreases()
        {
            var lines = File.ReadAllLines("Day1 - Sonardepth//input.txt");
            var sonarDepths = lines.Select(s => long.Parse(s.Trim()));
            Console.WriteLine("Total lines:" + sonarDepths.Count());
            var slidingWindows = GetSlidingWindows(sonarDepths);
            Console.WriteLine("Total windows:" + slidingWindows.Count());
            var result =  CountNumberOfIncreases(slidingWindows);
            Console.WriteLine("Increased lines:" + result);
            return result;
        }

        private IEnumerable<long> GetSlidingWindows(IEnumerable<long> sonarDepths)
        {
            var sonarDepthArray = sonarDepths.ToArray();
            var result = new List<long>();
            for (int i=0; i<sonarDepthArray.Length - 2; i++)
            {
                var window = sonarDepthArray[i] + sonarDepthArray[i + 1] + sonarDepthArray[i + 2];
                result.Add(window);
            }
            return result;
        }

        private long CountNumberOfIncreases(IEnumerable<long> sonarDepths)
        {
            var result = 0;
            var previous = long.MaxValue;
            foreach (var sd in sonarDepths)
            {
                if (sd > previous)
                {
                    result++;
                }
                previous = sd;
            }
            return result;
        }
    }
}
