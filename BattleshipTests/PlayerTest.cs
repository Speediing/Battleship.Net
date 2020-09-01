using System;
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
        public void shouldGetName()
        {
            Assert.Equal(player.GetName(), "name");
        }
    }
}
