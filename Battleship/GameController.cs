using System;
namespace Battleship
{
    public class GameController
    {
        private Player player1;
        private Player player2;

        public GameController()
        {
            player1 = new Player();
            player2 = new Player();
        }

        public Player getPlayer1() => player1;

        public Player getPlayer2() => player2;

        public void SetPlayerBoatLocation((string, string, string) player1BoatLoaction, (string, string, string) player2BoatLoaction)
        {
            player1.SetOpponentBoatLocation(player2BoatLoaction);
            player2.SetOpponentBoatLocation(player1BoatLoaction);
        }

        public void setPlayerNames(string player1Name, string player2Name)
        {
            player1.setName(player1Name);
            player2.setName(player2Name);
        }
    }
}
