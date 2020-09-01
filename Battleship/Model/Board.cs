using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        private List<string> columns;
        private List<string> rows;
        Dictionary<string, Dictionary<string, string>> boardValue;

        public Board()
        {
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            boardValue = this.InitializeDictionary();
        }

        public Dictionary<string, Dictionary<string, string>> ReturnBoard => this.boardValue;

        public void PlaceItem(string row, string column, string orientation, string item)
        {
            int rowIndex = rows.IndexOf(row);
            int columnIndex = columns.IndexOf(column);
            string debug1 = this.rows[rowIndex + 1];
            if (orientation == "x")
            {
                this.boardValue[row][column] = item;
                this.boardValue[this.rows[rowIndex + 1]][column] = item;
                this.boardValue[this.rows[rowIndex + 2]][column] = item;
            }
            if (orientation == "y")
            {
                this.boardValue[row][column] = item;
                this.boardValue[row][this.columns[columnIndex + 1]] = item;
                this.boardValue[row][this.columns[columnIndex + 2]] = item;
            }

        }

        private Dictionary<string, Dictionary<string, string>> InitializeDictionary()
        {
            var board = new Dictionary<string, Dictionary<string, string>>() { };
            foreach (string i in this.rows)
            {
                board.Add(i, new Dictionary<string, string>() { });
                foreach (string j in this.columns)
                {
                    board[i][j] = "*";
                }
            }

            return board;
        }

        
    }
}
