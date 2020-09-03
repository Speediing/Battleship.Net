using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class BoardDimentions
    {
        private static List<string> columns;
        private static List<string> rows;

        public static List<string> GetRows() => rows;
        public static List<string> GetColumns() => columns;

        public static void GenerateDimentionsBySize(int size)
        {
            columns = new List<string>();
            rows = new List<string>();
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string alphabetSubset = alphabet.Substring(0, size);
            foreach (char letter in alphabetSubset)
            {
                rows.Add(letter.ToString());
            }
            foreach (int value in Enumerable.Range(1, size))
            {
                columns.Add(value.ToString());
            }
        }

    }
}
