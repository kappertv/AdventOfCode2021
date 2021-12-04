using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    public class Column
    {
        public IEnumerable<int> numbers { get; }
        private List<int> markedNumbers = new List<int>();

        public Column(IEnumerable<int> column)
        {
            numbers = column;
            if (numbers.Count() != 5) throw new Exception("row does not have 5 numbers");

        }

        public void MarkNumber(int drawnNumber)
        {
            if (numbers.Contains(drawnNumber))
            {
                markedNumbers.Add(drawnNumber);
            }
            else
            {
                throw new InvalidOperationException("not expected");
            }
        }

        public bool AllMarked()
        {
            foreach (var number in numbers)
            {
                if (!markedNumbers.Contains(number)) return false;
            }

            return true;
        }

    }
}
