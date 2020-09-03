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

        public Player GetPlayer1() => player1;

        public Player GetPlayer2() => player2;

        public Stage GetCurrentStage() => stage;

        public Player GetCurrentPlayer()
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

        public Player GetOpponentPlayer()
        {
            switch (turn)
            {
                case Turn.player1:
                    {
                        return player2;
                    }
                case Turn.player2:
                    {
                        return player1;
                    }
                default:
                    {
                        return player1;
                    }
            }
        }

        public void NextTurn()
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

        public string GetCurrentPlayerName()
        {
            return GetCurrentPlayer().GetName();

        }

        public void SetPlayerBoatLocation((string, string, string) playerBoatLoaction)
        {
            GetOpponentPlayer().SetOpponentBoatLocation(playerBoatLoaction);
            if(turn == Turn.player2)
            {
                stage = Stage.fireMissile;
            }
            NextTurn();
        }

        public void SetBoardDimentions(int size)
        {
            BoardDimentions.GenerateDimentionsBySize(size);
            player1.InitializeBoards();
            player2.InitializeBoards();
            stage = Stage.setBoats;
        }

        public void SetPlayerNames(string player1Name, string player2Name)
        {
            player1.setName(player1Name);
            player2.setName(player2Name);
            stage = Stage.setDimentions;
        }

        public bool FireMissile(string row, string column)
        {
            bool didHit = GetCurrentPlayer().FireMissile(row, column);
            if (GetCurrentPlayer().HasWon())
            {
                stage = Stage.gameOver;
            }
            NextTurn();
            return didHit;
        }
    }
}
