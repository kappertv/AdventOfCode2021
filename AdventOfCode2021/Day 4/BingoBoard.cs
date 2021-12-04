using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Day4
{
    public class BingoBoard
    {
        IEnumerable<Row> rows;
        List<Column> columns = new List<Column>();
        public BingoBoard(string[] lines)
        {
            if (lines.Length != 5) throw new Exception("invalid input");

            rows = lines.Select(s => new Row(s)).ToList();

            for (int i=0; i<5; i++)
            {
                var column = rows.Select(s => s.numbers[i]).ToList();
                columns.Add(new Column(column));
            }

            if (columns.Count() != 5) throw new Exception("invalid input");
        }

        public void AddDrawnNumber(int drawnNumber)
        {
            foreach (var row in rows)
            {
                if (row.numbers.Contains(drawnNumber)) {
                    row.MarkNumber(drawnNumber);
                }
            }

            foreach (var col in columns)
            {
                if (col.numbers.Contains(drawnNumber))
                {
                    col.MarkNumber(drawnNumber);
                }
            }
        }

        public bool Wins()
        {
            foreach (var row in rows)
            {
                if (row.AllMarked()) return true;
            }

            foreach (var col in columns)
            {
                if (col.AllMarked()) return true;
            }
            return false;
        }

        public int GetScore()
        {
            return rows.Select(row => row.GetScore()).Sum();   
        }
    }
}
