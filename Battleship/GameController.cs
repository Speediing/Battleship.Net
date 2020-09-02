using System;
namespace Battleship
{
    public class GameController
    {
        private Player player1;
        private Player player2;
        
        private Turn turn;
        private Stage stage;

        public GameController()
        {
            player1 = new Player();
            player2 = new Player();
            turn = Turn.player1;
            stage = Stage.setNames;
        }

        public Player getPlayer1() => player1;

        public Player getPlayer2() => player2;

        public Stage getCurrentStage() => stage;

        public Player getCurrentPlayer()
        {
            switch (turn)
            {
                case Turn.player1:
                    {
                        return player1;
                    }
                case Turn.player2:
                    {
                        return player2;
                    }
                default:
                    {
                        return player1;
                    }
            }
        }

        public void nextTurn()
        {
            switch (turn)
            {
                case Turn.player1:
                    {
                        turn = Turn.player2;
                        break;
                    }
                case Turn.player2:
                    {
                        turn = Turn.player1;
                        break;
                    }
            }
        }

        public void SetPlayerBoatLocation((string, string, string) player1BoatLoaction, (string, string, string) player2BoatLoaction)
        {
            player1.SetOpponentBoatLocation(player2BoatLoaction);
            player2.SetOpponentBoatLocation(player1BoatLoaction);
            stage = Stage.fireMissile;
        }

        public void setPlayerNames(string player1Name, string player2Name)
        {
            player1.setName(player1Name);
            player2.setName(player2Name);
            stage = Stage.setBoats;
        }

        public void setGameOver()
        {
            stage = Stage.gameOver;
        }
    }
}
