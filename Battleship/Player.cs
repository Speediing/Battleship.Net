using System;
using System.Collections.Generic;

namespace Battleship
{
    public class Player
    {
        private string name;
        private Board personalBoard;
        private Board opponentBoard;
        private List<string> columns;
        private List<string> rows;
        private (string, string, string) personalBoatLocation;
        private (string, string, string) opponentsBoatLocation;
        private int missileHits;

        public Player(string name = "name")
        {
            this.name = name;
            personalBoard = new Board();
            opponentBoard = new Board();
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
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

        public void MoveBoatRight()
        {
            if (personalBoatLocation.Item1 == "F" && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item1 = "A";
            }
            else if (personalBoatLocation.Item1 == "H" && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item1 = "A";
            }
            else {
                int rowIndex = rows.IndexOf(personalBoatLocation.Item1);
                personalBoatLocation.Item1 = rows[rowIndex + 1];
            }
        }

        public void MoveBoatLeft()
        {
            if (personalBoatLocation.Item1 == "A" && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item1 = "F";
            }
            else if (personalBoatLocation.Item1 == "A" && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item1 = "H";
            }
            else
            {
                int rowIndex = rows.IndexOf(personalBoatLocation.Item1);
                personalBoatLocation.Item1 = rows[rowIndex - 1];
            }
        }

        public void MoveBoatDown()
        {
            if (personalBoatLocation.Item2 == "8" && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item2 = "1";
            }
            else if (personalBoatLocation.Item2 == "6" && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item2 = "1";
            }
            else
            {
                int columnIndex = columns.IndexOf(personalBoatLocation.Item2);
                personalBoatLocation.Item2 = columns[columnIndex + 1];
            }
        }

        public void MoveBoatUp()
        {
            if (personalBoatLocation.Item2 == "1" && personalBoatLocation.Item3 == "x")
            {
                personalBoatLocation.Item2 = "8";
            }
            else if (personalBoatLocation.Item2 == "1" && personalBoatLocation.Item3 == "y")
            {
                personalBoatLocation.Item2 = "6";
            }
            else
            {
                int columnIndex = columns.IndexOf(personalBoatLocation.Item2);
                personalBoatLocation.Item2 = columns[columnIndex - 1];
            }
        }

        public void RotateBoat()
        {
            if (personalBoatLocation.Item2 == "7" && personalBoatLocation.Item3 == "x")
            {
                this.MoveBoatUp();
            }
            if (personalBoatLocation.Item2 == "8" && personalBoatLocation.Item3 == "x")
            {
                this.MoveBoatUp();
                this.MoveBoatUp();
            }
            if (personalBoatLocation.Item1 == "G" && personalBoatLocation.Item3 == "y")
            {
                this.MoveBoatLeft();
            }
            if (personalBoatLocation.Item1 == "H" && personalBoatLocation.Item3 == "y")
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
