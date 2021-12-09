using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day8
{
    public class SevenSegmentSearch
    {
        Dictionary<int, char[]> sevenSegmentDigit = new Dictionary<int, char[]>()
        {
            {0, new char[]{'a', 'b', 'c', 'e', 'f', 'g'} },
            {1, new char[]{'c', 'f'} },
            {2, new char[]{'a', 'c','d','e','g'} },
            {3, new char[]{'a', 'c','d','f','g'} },
            {4, new char[]{'b', 'c','d','f'} },
            {5, new char[]{'a', 'b', 'd', 'f', 'g'} },
            {6, new char[]{'a', 'b', 'd', 'e', 'f', 'g'} },
            {7, new char[]{'a', 'c', 'f'} },
            {8, new char[]{'a', 'b', 'c', 'd', 'e', 'f', 'g'} },
            {9, new char[]{'a', 'b', 'c', 'd', 'f', 'g'} }

        };

        List<Entry> entries = new List<Entry>();

        public SevenSegmentSearch(string[] lines)
        {
            foreach (var line in lines)
            {
                var p = line.Split(" | ");
                var signalPatterns = p[0].Split(" ").Select(s => s.Trim()).ToArray();
                var outputvalues = p[1].Split(" ").Select(s => s.Trim()).ToArray();
                var entry = new Entry(signalPatterns, outputvalues);
                entries.Add(entry);
            }
        }

        public long GetNumberOfEasyDigits()
        {
            return entries.Sum(e => e.GetNumberOfEasyValues());
        }
    }
}
