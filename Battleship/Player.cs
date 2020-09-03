using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private string name;
        private Board personalBoard;
        private Board opponentBoard;
        private (string, string, string) personalBoatLocation;
        private (string, string, string) opponentsBoatLocation;
        private int missileHits;

        public Player(string name = "name")
        {
            this.name = name;
            personalBoatLocation = ("A", "1", "x");
            opponentsBoatLocation = ("A", "1", "x");
            missileHits = 0;
        }

        public string GetName() => name;

        public (string, string, string) GetBoatLocation() => personalBoatLocation;

        public (string, string, string) GetOpponentBoatLocation() => opponentsBoatLocation;

        public Board GetPersonalBoard() => personalBoard;

        public void setName(string newName)
        {
            this.name = newName;
        }

        public void InitializeBoards()
        {
            personalBoard = new Board();
            opponentBoard = new Board();
        }

        public void MoveBoatRight()
        {
            int size = BoardDimentions.GetRows().Count;
            string lastRow = BoardDimentions.GetRows()[size - 1];
            string firstRow = BoardDimentions.GetRows()[0];
            string secondlastRow = BoardDimentions.GetRows()[size - 3];
            if (personalBoatLocation.Item1 == secondlastRow && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item1 = firstRow;
            }
            else if (personalBoatLocation.Item1 == lastRow && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item1 = firstRow;
            }
            else {
                int rowIndex = BoardDimentions.GetRows().IndexOf(personalBoatLocation.Item1);
                personalBoatLocation.Item1 = BoardDimentions.GetRows()[rowIndex + 1];
            }
        }

        public void MoveBoatLeft()
        {
            int size = BoardDimentions.GetRows().Count;
            string lastRow = BoardDimentions.GetRows()[size - 1];
            string firstRow = BoardDimentions.GetRows()[0];
            string secondlastRow = BoardDimentions.GetRows()[size - 3];
            if (personalBoatLocation.Item1 == firstRow && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item1 = secondlastRow;
            }
            else if (personalBoatLocation.Item1 == firstRow && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item1 = lastRow;
            }
            else
            {
                int rowIndex = BoardDimentions.GetRows().IndexOf(personalBoatLocation.Item1);
                personalBoatLocation.Item1 = BoardDimentions.GetRows()[rowIndex - 1];
            }
        }

        public void MoveBoatDown()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string firstColumn = BoardDimentions.GetColumns()[0];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 3];
            if (personalBoatLocation.Item2 == lastColumn && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item2 = firstColumn;
            }
            else if (personalBoatLocation.Item2 == secondlastColumn && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item2 = firstColumn;
            }
            else
            {
                int columnIndex = BoardDimentions.GetColumns().IndexOf(personalBoatLocation.Item2);
                personalBoatLocation.Item2 = BoardDimentions.GetColumns()[columnIndex + 1];
            }
        }

        public void MoveBoatUp()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string firstColumn = BoardDimentions.GetColumns()[0];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 3];
            if (personalBoatLocation.Item2 == firstColumn && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item2 = lastColumn;
            }
            else if (personalBoatLocation.Item2 == firstColumn && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item2 = secondlastColumn;
            }
            else
            {
                int columnIndex = BoardDimentions.GetColumns().IndexOf(personalBoatLocation.Item2);
                personalBoatLocation.Item2 = BoardDimentions.GetColumns()[columnIndex - 1];
            }
        }

        public void RotateBoat()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 2];
            string lastRow = BoardDimentions.GetRows()[size - 1];
            string secondlastRow = BoardDimentions.GetRows()[size - 2];
            if (personalBoatLocation.Item2 == secondlastColumn && personalBoatLocation.Item3 == "x")
            {
                this.MoveBoatUp();
            }
            if (personalBoatLocation.Item2 == lastColumn && personalBoatLocation.Item3 == "x")
            {
                this.MoveBoatUp();
                this.MoveBoatUp();
            }
            if (personalBoatLocation.Item1 == secondlastRow && personalBoatLocation.Item3 == "y")
            {
                this.MoveBoatLeft();
            }
            if (personalBoatLocation.Item1 == lastRow && personalBoatLocation.Item3 == "y")
            {
                this.MoveBoatLeft();
                this.MoveBoatLeft();
            }
            if (personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item3 = "x";
            } else
            {
                personalBoatLocation.Item3 = "y";
            }
        }

        public void MoveBoat(string move)
        {
            if(move == "w")
            {
                this.MoveBoatUp();
            }
            if (move == "a")
            {
                this.MoveBoatLeft();
            }
            if (move == "s")
            {
                this.MoveBoatDown();
            }
            if (move == "d")
            {
                this.MoveBoatRight();
            }
            if (move == "r")
            {
                this.RotateBoat();
            }
        }

        public void SetOpponentBoatLocation((string, string, string) location)
        {
            opponentsBoatLocation = location;
            opponentBoard.PlaceItem(location.Item1, location.Item2, location.Item3, "x");
        }

        public Boolean FireMissile(string row, string column)
        {
            string opponentSpot = opponentBoard.GetValueAtPosition(row, column);
            if (opponentSpot == "x")
            {
                personalBoard.PlaceMissile(row, column, "🚢");
                opponentBoard.PlaceMissile(row, column, "HIT");
                missileHits += 1;
                return true;
            }
            else
            {
                personalBoard.PlaceMissile(row, column, "⭕");
                return false;
            }
        }

        public Boolean HasWon()
        {
            if (missileHits >= 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
