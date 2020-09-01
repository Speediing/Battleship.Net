using System;
using System.Collections.Generic;
using Battleship;
using Xunit;

namespace BattleshipTests
{
    public class BoardTest
    {

        private Board board;

        public BoardTest()
        {
            board = new Board();
        }

        [Fact]
        public void shouldCreateNewBoard()
        {
            Dictionary<string, Dictionary<string, string>> testBoard = new Dictionary<string, Dictionary<string, string>>() {
                { "A", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "B", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "C", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "D", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "E", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "F", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "G", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "H", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } }
            };
            Assert.Equal(this.board.ReturnBoard, testBoard);
        }

        [Fact]
        public void shouldPlaceBoat()
        {
            Dictionary<string, Dictionary<string, string>> testBoard = new Dictionary<string, Dictionary<string, string>>() {
                { "A", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "B", new Dictionary<string, string>() { { "1", "*" }, { "3", "🚢" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "C", new Dictionary<string, string>() { { "1", "*" }, { "3", "🚢" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "D", new Dictionary<string, string>() { { "1", "*" }, { "3", "🚢" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "E", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "F", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "G", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "H", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } }
            };
            Console.WriteLine(this.board.ReturnBoard["B"]);
            
            this.board.PlaceItem("B", "3", "x", "🚢");
            Assert.Equal(this.board.ReturnBoard, testBoard);
        }

        [Fact]
        public void shouldPlaceMissile()
        {
            Dictionary<string, Dictionary<string, string>> testBoard = new Dictionary<string, Dictionary<string, string>>() {
                { "A", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "B", new Dictionary<string, string>() { { "1", "*" }, { "3", "⭕" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "C", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "D", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "E", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "F", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "G", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } },
                { "H", new Dictionary<string, string>() { { "1", "*" }, { "3", "*" }, { "2", "*" }, { "5", "*" }, { "4", "*" }, { "7", "*" }, { "6", "*" }, { "8", "*" } } }
            };
            Console.WriteLine(this.board.ReturnBoard["B"]);

            this.board.PlaceMissile("B", "3", "⭕");
            Assert.Equal(this.board.ReturnBoard, testBoard);
        }

        [Fact]
        public void shouldGetPosition()
        {
            Assert.Equal("*", this.board.GetValueAtPosition("B", "3"));
        }
    }
}
