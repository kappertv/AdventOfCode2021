using System;
namespace AdventOfCode2021.Day8
{
    public class Entry
    {
        public Entry(string[] signalPatterns, string[] outputvalues)
        {
            SignalPatterns = signalPatterns;
            Outputvalues = outputvalues;
        }

        public string[] SignalPatterns { get; }
        public string[] Outputvalues { get; }

        public int GetNumberOfEasyValues()
        {
            var result = 0;
            foreach (var output in Outputvalues)
            {
                if (IsEasyOutput(output))
                {
                    result++;
                }
            }
            return result;
        }

        private static bool IsEasyOutput(string output)
        {
            var count = output.Length;
            return count == 2 || count == 4 || count == 3 || count == 7;
        }
    }
}
