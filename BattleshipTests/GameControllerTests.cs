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
            gameController.setPlayerNames("Jerry", "John");
            Assert.Equal("Jerry", gameController.getPlayer1().GetName());
            Assert.Equal("John", gameController.getPlayer2().GetName());
        }

        [Fact]
        public void shouldSetBoatLocations()
        {
            gameController.SetPlayerBoatLocation(("A", "1", "r"), ("A", "1", "r"));
            Assert.Equal(("A", "1", "r"), gameController.getPlayer1().GetOpponentBoatLocation());
            Assert.Equal(("A", "1", "r"), gameController.getPlayer2().GetOpponentBoatLocation());
        }
    }
}
