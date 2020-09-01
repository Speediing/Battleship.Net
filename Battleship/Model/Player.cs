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

        public string GetName()
        {
            return name;
        }
    }
}
