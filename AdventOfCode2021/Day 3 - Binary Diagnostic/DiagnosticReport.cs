using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCode2021.Day3BinaryDiagnostic
{
    public class DiagnosticReport
    {
        private string[] _input;
        public DiagnosticReport(string[] linesInput)
        {
            _input = linesInput;
        }

        public int GetGammaRate()
        {
            var gammaRateBit = "";
            for (int i = 0; i < _input[0].Length; i++)
            {
                gammaRateBit += GetMostCommonBitOnPosition(i, _input);
            }

            return Convert.ToInt32(gammaRateBit, 2);
        }

        public int GetEpsilonRate()
        {
            var epsilonRateBit = "";
            for (int i = 0; i < _input[0].Length; i++)
            {
                epsilonRateBit += GetMostUncommonBitOnPosition(i, _input);
            }

            return Convert.ToInt32(epsilonRateBit, 2);
        }

        public int GetOxygenGeneratorRating()
        {
            var remainingNumbers = new List<string>(_input);

            for (int i = 0; i < _input[0].Length; i++)
            {
                var x = GetMostCommonBitOnPosition(i, remainingNumbers);

                remainingNumbers = new List<string>(remainingNumbers.Where(s => s[i].ToString() == x));
                if (remainingNumbers.Count() == 1)
                {
                    return Convert.ToInt32(remainingNumbers.Single(), 2);
                }
            }

            return 0;
        }

        public int GetCO2ScrubberRating()
        {
            var remainingNumbers = new List<string>(_input);

            for (int i = 0; i < _input[0].Length; i++)
            {
                var x = GetMostUncommonBitOnPosition(i, remainingNumbers);

                remainingNumbers = new List<string>(remainingNumbers.Where(s => s[i].ToString() == x));
                if (remainingNumbers.Count() == 1)
                {
                    return Convert.ToInt32(remainingNumbers.Single(), 2);
                }
            }

            return 0;
        }

        private string GetMostCommonBitOnPosition(int index, IEnumerable<string> input)
        {
            List<int> numbers = new List<int>();
            foreach (var line in input)
            {
                var charAtIndex = line[index];
                numbers.Add(int.Parse(charAtIndex.ToString()));
            }

            var zeros = numbers.Count(n => n == 0);
            var ones = numbers.Count(n => n == 1);
            if (zeros == ones)
            {
                return "1";
            }

            if (zeros < ones)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        public int GetLifeSupportRating()
        {
            return GetCO2ScrubberRating() * GetOxygenGeneratorRating();
        }

        private string GetMostUncommonBitOnPosition(int index, IEnumerable<string> input)
        {
            List<int> numbers = new List<int>();
            foreach (var line in input)
            {
                var charAtIndex = line[index];
                numbers.Add(int.Parse(charAtIndex.ToString()));
            }

            var zeros = numbers.Count(n => n == 0);
            var ones = numbers.Count(n => n == 1);
            if (zeros == ones)
            {
                return "0";
            }

            if (zeros < ones)
            {
                return "0";
            }
            else
            {
                return "1";
            }
        }

        public static long GetLifeSupportRatingFromInpu()
        {
            var dp = new DiagnosticReport(File.ReadAllLines("Day 3 - Binary Diagnostic//myinput.txt"));

            return dp.GetLifeSupportRating();
        }

        public static long GetPowerConsumption()
        {
            var dp = new DiagnosticReport(File.ReadAllLines("Day 3 - Binary Diagnostic//myinput.txt"));

            return dp.GetGammaRate() * dp.GetEpsilonRate();
        }
    }
}
