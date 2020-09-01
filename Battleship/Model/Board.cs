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
            columns = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            rows = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            boardValue = this.InitializeDictionary();
        }

        private Dictionary<string, Dictionary<string, string>> InitializeDictionary()
        {
            var board = new Dictionary<string, Dictionary<string, string>>() { };
            foreach (string i in this.columns)
            {
                board.Add(i, new Dictionary<string, string>() { });
                foreach (string j in this.rows)
                {
                    board[i][j] = "*";
                }
            }

            return board;
        }

        public Dictionary<string, Dictionary<string, string>> ReturnBoard => this.boardValue;
    }
}
