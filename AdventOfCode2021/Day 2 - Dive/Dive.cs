using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day2Dive
{
    public class Dive
    {
        public Dive()
        {
        }

        public long MultiplyDepthAndHorizontalPosition()
        {
            var lines = File.ReadAllLines("Day 2 - Dive//input.txt");
            var diveInputs = ParseDiveInput(lines);
            var depth = CalculateDepth(diveInputs);
            var forward = diveInputs.Where(di => di.Direction == DiveInput.DirectionEnum.Forward).
                Sum(d => d.Distance);

            return depth * forward;
        }

        private long CalculateDepth(IEnumerable<DiveInput> diveInputs)
        {
            long depth = 0;
            long aim = 0;
            foreach (var diveinput in diveInputs)
            {
                if (diveinput.Direction == DiveInput.DirectionEnum.Down)
                {
                    aim += diveinput.Distance;
                }
                else if (diveinput.Direction == DiveInput.DirectionEnum.Up)
                {
                    aim -= diveinput.Distance;
                }
                else if (diveinput.Direction == DiveInput.DirectionEnum.Forward)
                {
                    depth += aim * diveinput.Distance;
                }
                else
                {
                    throw new Exception("unexpected inpu");
                }
            }
            return depth;
        }

        private static IEnumerable<DiveInput> ParseDiveInput(string[] lines)
        {
            return lines.Select(s => new DiveInput(s));
        }
    }
}
