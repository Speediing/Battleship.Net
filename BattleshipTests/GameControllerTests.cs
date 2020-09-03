using System;
using Battleship;
using Xunit;

namespace BattleshipTests
{
    public class GameControllerTests
    {
        public GameController gameController;

        public GameControllerTests()
        {
            gameController = new GameController();
            gameController.SetBoardDimentions(8);
        }

        [Fact]
        public void shouldShowCurrentPlayerName()
        {
            gameController.SetPlayerNames("Jerry", "John");
            Assert.Equal("Jerry", gameController.GetCurrentPlayerName());
        }

        [Fact]
        public void shouldSetUserNames()
        {
            gameController.SetPlayerNames("Jerry", "John");
            Assert.Equal("Jerry", gameController.GetPlayer1().GetName());
            Assert.Equal("John", gameController.GetPlayer2().GetName());
        }

        [Fact]
        public void shouldBeOnDimentionsSelectionAfterNameSelection()
        {
            gameController.SetPlayerNames("Jerry", "John");
            
            Assert.Equal(Stage.setDimentions, gameController.GetCurrentStage());
        }

        [Fact]
        public void shouldBeOnBoatSelectionAfterDimentionSelection()
        {
            gameController.SetBoardDimentions(8);
            Assert.Equal(Stage.setBoats, gameController.GetCurrentStage());
        }

        [Fact]
        public void shouldBeOnPlayer2AfterFirstBoatSelection()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            gameController.SetPlayerBoatLocation(location);

            Assert.Equal(gameController.GetPlayer2(), gameController.GetCurrentPlayer());
        }

        [Fact]
        public void shouldBeOnFireMissileAfterBoatSelection()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            gameController.SetPlayerBoatLocation(location);
            gameController.SetPlayerBoatLocation(location);
            Assert.Equal(Stage.fireMissile, gameController.GetCurrentStage());
        }

        [Fact]
        public void shouldBeOnPlayer2AfterFireMissile()
        {
            gameController.FireMissile("A", "1");
            Assert.Equal(gameController.GetPlayer2(), gameController.GetCurrentPlayer());
        }

        [Fact]
        public void shouldSetBoatLocations()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            gameController.SetPlayerBoatLocation(location);
            Assert.Equal(location, gameController.GetPlayer2().GetOpponentBoatLocation());
        }

        [Fact]
        public void shouldGetCurrentPlayer1()
        {
            Assert.Equal(gameController.GetCurrentPlayer(), gameController.GetPlayer1());
        }

        [Fact]
        public void shouldGetNextPlayer()
        {
            gameController.NextTurn();
            Assert.Equal(gameController.GetCurrentPlayer(), gameController.GetPlayer2());
        }
    }
}
