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
        }

        [Fact]
        public void shouldSetUserNames()
        {
            gameController.SetPlayerNames("Jerry", "John");
            Assert.Equal("Jerry", gameController.GetPlayer1().GetName());
            Assert.Equal("John", gameController.GetPlayer2().GetName());
        }

        [Fact]
        public void shouldBeOnBoatSelectionAfterNameSelection()
        {
            gameController.SetPlayerNames("Jerry", "John");
            
            Assert.Equal(Stage.setBoats, gameController.GetCurrentStage());
        }

        [Fact]
        public void shouldBeOnFireMissileAfterBoatSelection()
        {
            gameController.SetPlayerBoatLocation(("A", "1", "r"));
            Assert.Equal(Stage.fireMissile, gameController.GetCurrentStage());
        }

        [Fact]
        public void shouldSetBoatLocations()
        {
            gameController.SetPlayerBoatLocation(("A", "1", "r"));
            Assert.Equal(("A", "1", "r"), gameController.GetPlayer2().GetOpponentBoatLocation());
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
