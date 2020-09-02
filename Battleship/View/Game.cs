using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Game
    {
        private List<string> columns;
        private List<string> rows;

        public Game()
        {
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
        }

        public string RenderBoard(Board board)
        {
            string board_string = @"
   |   A   |   B   |   C   |   D   |   E   |   F   |   G   |   H   |
";
            foreach (string column in columns)
            {
                board_string += @"-
";
                board_string += column;
                board_string += "  ";
                foreach (string row in rows)
                {
                    board_string += "    ";
                    board_string += board.ReturnBoard[row][column];
                    board_string += "   ";
                }
                board_string += @"
-

";
            }
            return board_string;
        }

        public string RenderBoardWithBoat(string row, string column, string orientation)
        {
            Board dummyBoard = new Board();
            dummyBoard.PlaceItem(row, column, orientation, "🚢");
            return this.RenderBoard(dummyBoard);
        }
    }
}
