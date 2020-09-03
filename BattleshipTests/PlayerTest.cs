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
            BoardDimentions.GenerateDimentionsBySize(8);
            player = new Player();
            player.InitializeBoards();
            
        }

        [Fact]
        public void shouldGetPlayerName()
        {
            Assert.Equal("name", player.GetName());
        }

        [Fact]
        public void shouldGetBoatLocation()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldMoveBoatRight()
        {
            BoatLocation location = new BoatLocation("B", "1", Orientation.X);
            player.MoveBoatRight();
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldMoveBoatLeft()
        {
            BoatLocation location = new BoatLocation("F", "1", Orientation.X);
            player.MoveBoatLeft();
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldMoveBoatDown()
        {
            BoatLocation location = new BoatLocation("A", "2", Orientation.X);
            player.MoveBoatDown();
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldMoveBoatUp()
        {
            BoatLocation location = new BoatLocation("A", "8", Orientation.X);
            player.MoveBoatUp();
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldRotateBoat()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.Y);
            player.RotateBoat();
            Assert.Equal(location.GetRow(), player.GetBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldGetOpponentBoatLocation()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            Assert.Equal(location.GetRow(), player.GetOpponentBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetOpponentBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetOpponentBoatLocation().GetOrientation());
        }

        [Fact]
        public void shouldSetOpponentBoatLocation()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.Y);
            player.SetOpponentBoatLocation(location);
            Assert.Equal(location.GetRow(), player.GetOpponentBoatLocation().GetRow());
            Assert.Equal(location.GetColumn(), player.GetOpponentBoatLocation().GetColumn());
            Assert.Equal(location.GetOrientation(), player.GetOpponentBoatLocation().GetOrientation());
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
        public void shoulHaveMissileHit()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            player.SetOpponentBoatLocation(location);
            Assert.True(player.FireMissile("A", "1"));
            Assert.True(player.FireMissile("B", "1"));
            Assert.True(player.FireMissile("C", "1"));
        }

        [Fact]
        public void shouldHaveMissileMiss()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            player.SetOpponentBoatLocation(location);
            Assert.False(player.FireMissile("E", "1"));
        }

        [Fact]
        public void shouldHavePlayerLose()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.Y);
            player.SetOpponentBoatLocation(location);
            Assert.False(player.HasWon());
        }

        [Fact]
        public void shouldHavePlayerWin()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            player.SetOpponentBoatLocation(location);
            player.FireMissile("A", "1");
            player.FireMissile("B", "1");
            player.FireMissile("C", "1");
            Assert.True(player.HasWon());
        }
    }
}
