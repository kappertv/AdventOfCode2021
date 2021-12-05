using System;
using AdventOfCode2021.Day1Sonardepth;
using AdventOfCode2021.Day2Dive;
using AdventOfCode2021.Day3BinaryDiagnostic;
using AdventOfCode2021.Day4;

namespace AdventOfCode2021
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Day 1");
            //new AnalyseSonarDepth().CountSonarIncreases();

            //Console.WriteLine("Day 2:" +
            //    new Dive().MultiplyDepthAndHorizontalPosition()
            //);

            //Console.Write("Day 3: " + DiagnosticReport.GetPowerConsumption());

            //Console.Write("Day 3 - Part 2:" + DiagnosticReport.GetLifeSupportRatingFromInpu());

            Console.WriteLine("Day 4 - Part 1: " + BingoSystem.GetFinalScoreFromInput());
        }
    }
}
