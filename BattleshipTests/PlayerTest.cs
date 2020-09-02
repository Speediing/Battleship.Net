using System;
using System.Collections.Generic;
using Battleship;
using Xunit;

namespace BattleshipTests
{
    public class PlayerTest
    {
        private Player player;

        public PlayerTest()
        {
            player = new Player();
        }

        [Fact]
        public void shouldGetPlayerName()
        {
            Assert.Equal("name", player.GetName());
        }

        [Fact]
        public void shouldGetBoatLocation()
        {
            Assert.Equal(("A", "1", "x"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldMoveBoatRight()
        {
            player.MoveBoatRight();
            Assert.Equal(("B", "1", "x"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldMoveBoatLeft()
        {
            player.MoveBoatLeft();
            Assert.Equal(("F", "1", "x"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldMoveBoatDown()
        {
            player.MoveBoatDown();
            Assert.Equal(("A", "7", "x"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldMoveBoatUp()
        {
            player.MoveBoatUp();
            Assert.Equal(("A", "2", "x"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldRotateBoat()
        {
            player.RotateBoat();
            Assert.Equal(("A", "1", "y"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldGetOpponentBoatLocation()
        {
            Assert.Equal(("A", "1", "x"), player.GetOpponentBoatLocation());
        }

        [Fact]
        public void shouldMoveBoat()
        {
            player.MoveBoat("w");
            player.MoveBoat("a");
            player.MoveBoat("s");
            player.MoveBoat("d");
            player.MoveBoat("r");
            Assert.Equal(("A", "1", "y"), player.GetBoatLocation());
        }

        [Fact]
        public void shouldSetOpponentBoatLocation()
        {
            player.SetOpponentBoatLocation(("A", "1", "y"));
            Assert.Equal(("A", "1", "y"), player.GetOpponentBoatLocation());
        }

        [Fact]
        public void shouldGetBoard()
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
            Assert.Equal(player.GetPersonalBoard().ReturnBoard, testBoard);
        }

        [Fact]
        public void shoulHavedMissileHit()
        {
            player.SetOpponentBoatLocation(("A", "1", "x"));
            Assert.True(player.FireMissile("A", "1"));
            Assert.True(player.FireMissile("B", "1"));
            Assert.True(player.FireMissile("C", "1"));
        }

        [Fact]
        public void shouldHaveMissileMiss()
        {
            player.SetOpponentBoatLocation(("A", "1", "x"));
            Assert.False(player.FireMissile("E", "1"));
        }

        [Fact]
        public void shouldHavePlayerLost()
        {
            player.SetOpponentBoatLocation(("A", "1", "x"));
            Assert.Equal(false, player.HasWon());
        }

        [Fact]
        public void shouldHavePlayerWin()
        {
            player.SetOpponentBoatLocation(("A", "1", "x"));
            player.FireMissile("A", "1");
            player.FireMissile("B", "1");
            player.FireMissile("C", "1");
            Assert.Equal(true, player.HasWon());
        }
    }
}
