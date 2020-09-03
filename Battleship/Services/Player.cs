using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private string name;
        private Board personalBoard;
        private Board opponentBoard;
        private BoatLocation personalBoatLocation;
        private BoatLocation opponentsBoatLocation;
        private int missileHits;

        public Player(string name = "name")
        {
            this.name = name;
            personalBoatLocation = new BoatLocation("A", "1", Orientation.X);
            opponentsBoatLocation = new BoatLocation("A", "1", Orientation.X);
            missileHits = 0;
        }

        public string GetName() => name;

        public BoatLocation GetBoatLocation() => personalBoatLocation;

        public BoatLocation GetOpponentBoatLocation() => opponentsBoatLocation;

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
            if (personalBoatLocation.GetRow() == secondlastRow && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                personalBoatLocation.SetRow(firstRow);
            }
            else if (personalBoatLocation.GetRow() == lastRow && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                personalBoatLocation.SetRow(firstRow);
            }
            else {
                int rowIndex = BoardDimentions.GetRows().IndexOf(personalBoatLocation.GetRow());
                personalBoatLocation.SetRow(BoardDimentions.GetRows()[rowIndex + 1]);
            }
        }

        public void MoveBoatLeft()
        {
            int size = BoardDimentions.GetRows().Count;
            string lastRow = BoardDimentions.GetRows()[size - 1];
            string firstRow = BoardDimentions.GetRows()[0];
            string secondlastRow = BoardDimentions.GetRows()[size - 3];
            if (personalBoatLocation.GetRow() == firstRow && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                personalBoatLocation.SetRow(secondlastRow);
            }
            else if (personalBoatLocation.GetRow() == firstRow && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                personalBoatLocation.SetRow(lastRow);
            }
            else
            {
                int rowIndex = BoardDimentions.GetRows().IndexOf(personalBoatLocation.GetRow());
                personalBoatLocation.SetRow(BoardDimentions.GetRows()[rowIndex - 1]);
            }
        }

        public void MoveBoatDown()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string firstColumn = BoardDimentions.GetColumns()[0];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 3];
            if (personalBoatLocation.GetColumn() == lastColumn && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                personalBoatLocation.SetColumn(firstColumn);
            }
            else if (personalBoatLocation.GetColumn() == secondlastColumn && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                personalBoatLocation.SetColumn(firstColumn);
            }
            else
            {
                int columnIndex = BoardDimentions.GetColumns().IndexOf(personalBoatLocation.GetColumn());
                personalBoatLocation.SetColumn(BoardDimentions.GetColumns()[columnIndex + 1]);
            }
        }

        public void MoveBoatUp()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string firstColumn = BoardDimentions.GetColumns()[0];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 3];
            if (personalBoatLocation.GetColumn() == firstColumn && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                personalBoatLocation.SetColumn(lastColumn);
            }
            else if (personalBoatLocation.GetColumn() == firstColumn && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                personalBoatLocation.SetColumn(secondlastColumn);
            }
            else
            {
                int columnIndex = BoardDimentions.GetColumns().IndexOf(personalBoatLocation.GetColumn());
                personalBoatLocation.SetColumn(BoardDimentions.GetColumns()[columnIndex - 1]);
            }
        }

        public void RotateBoat()
        {
            int size = BoardDimentions.GetColumns().Count;
            string lastColumn = BoardDimentions.GetColumns()[size - 1];
            string secondlastColumn = BoardDimentions.GetColumns()[size - 2];
            string lastRow = BoardDimentions.GetRows()[size - 1];
            string secondlastRow = BoardDimentions.GetRows()[size - 2];
            if (personalBoatLocation.GetColumn() == secondlastColumn && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                this.MoveBoatUp();
            }
            if (personalBoatLocation.GetColumn() == lastColumn && personalBoatLocation.GetOrientation() == Orientation.X)
            {
                this.MoveBoatUp();
                this.MoveBoatUp();
            }
            if (personalBoatLocation.GetRow() == secondlastRow && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                this.MoveBoatLeft();
            }
            if (personalBoatLocation.GetRow() == lastRow && personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                this.MoveBoatLeft();
                this.MoveBoatLeft();
            }
            if (personalBoatLocation.GetOrientation() == Orientation.Y)
            {
                personalBoatLocation.SetOrientation(Orientation.X);
            } else
            {
                personalBoatLocation.SetOrientation(Orientation.Y);
            }
        }

        public void SetOpponentBoatLocation(BoatLocation location)
        {
            opponentsBoatLocation = location;
            opponentBoard.PlaceItem(location, "x");
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

        public bool HasWon()
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
