using System;
using AdventOfCode2021.Day1Sonardepth;
using AdventOfCode2021.Day2Dive;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Day 1");
            new AnalyseSonarDepth().CountSonarIncreases();

            Console.WriteLine("Day 2:" +
                new Dive().MultiplyDepthAndHorizontalPosition()
            );
        }
    }
}
