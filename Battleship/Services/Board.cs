using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Board
    {
        private Dictionary<string, Dictionary<string, string>> boardValue;

        public Board()
        {
            boardValue = InitializeBoard();
        }

        public Dictionary<string, Dictionary<string, string>> ReturnBoard => this.boardValue;

        public void PlaceItem(BoatLocation location, string item)
        {
            string row = location.GetRow();
            string column = location.GetColumn();
            Orientation orientation = location.GetOrientation();
            int rowIndex = BoardDimentions.GetRows().IndexOf(row);
            int columnIndex = BoardDimentions.GetColumns().IndexOf(column);
            if (orientation == Orientation.X)
            {
                this.boardValue[row][column] = item;
                this.boardValue[BoardDimentions.GetRows()[rowIndex + 1]][column] = item;
                this.boardValue[BoardDimentions.GetRows()[rowIndex + 2]][column] = item;
            }
            if (orientation == Orientation.Y)
            {
                this.boardValue[row][column] = item;
                this.boardValue[row][BoardDimentions.GetColumns()[columnIndex + 1]] = item;
                this.boardValue[row][BoardDimentions.GetColumns()[columnIndex + 2]] = item;
            }

        }

        public void PlaceMissile(string row, string column, string item)
        {
            this.boardValue[row][column] = item;
        }


        public string GetValueAtPosition(string row, string column)
        {
            return this.boardValue[row][column];
        }

        public Dictionary<string, Dictionary<string, string>> InitializeBoard()
        {
            var board = new Dictionary<string, Dictionary<string, string>>() { };
            foreach (string i in BoardDimentions.GetRows())
            {
                board.Add(i, new Dictionary<string, string>() { });
                foreach (string j in BoardDimentions.GetColumns())
                {
                    board[i][j] = "*";
                }
            }
            return board;
        }

       
    }
}
