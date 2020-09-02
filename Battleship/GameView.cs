using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class GameView
    {
        private List<string> columns;
        private List<string> rows;
        private GameController gameController;

        public GameView()
        {
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            gameController = new GameController();
        }

        public void StartGame()
        {
            bool gameInProgress = true;
            while (gameInProgress)
            {
                switch (gameController.getCurrentStage())
                {
                    case Stage.setNames:
                        {
                            (string, string) names = GetPlayerNames();
                            gameController.setPlayerNames(names.Item1, names.Item2);
                            break;
                        }
                    case Stage.setBoats:
                        {
                            (string, string, string) player1BoatLoaction = RenderPlaceBoat();
                            (string, string, string) player2BoatLoaction = RenderPlaceBoat();
                            gameController.SetPlayerBoatLocation(player1BoatLoaction, player2BoatLoaction);
                            break;
                        }
                    case Stage.fireMissile:
                        {
                            RenderTurn();
                            break;
                        }
                    case Stage.gameOver:
                        {
                            gameInProgress = false;
                            break;
                        }
                }
            }

        }

        public (string, string) GetPlayerNames()
        {
            Console.WriteLine(@"WELCOME TO JASON'S BATTLESHIP
                 __ / ___
          _____ / ______ |
  _______ / _____\_______\_____     
  \              < < <       |
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("What is the first players name?");
            string player1Name = Console.ReadLine();
            Console.WriteLine("What is the second players name?");
            string player2Name = Console.ReadLine();
            Console.Clear();
            return (player1Name, player2Name);
        }

        public void RenderTurn()
        {
            Player player = gameController.getCurrentPlayer();
            string fireSpot = GetFireSpot(player);
            bool didHit = player.FireMissile(fireSpot[0].ToString(), fireSpot[1].ToString());
            gameController.nextTurn();
            RenderTurnResult(player, didHit);
        }

        private string GetFireSpot(Player player)
        {
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            Console.WriteLine(player.GetName() + " it's time to pick a location to fire! Enter your location like: 'B5'\n\n");
            string fireSpot = Console.ReadLine();
            while (true)
            {
                if (ValidateMissileInput(fireSpot) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(player.GetName() + " your location was incorrectly formatted! Enter your location like: 'B5'\n\n");
                    fireSpot = Console.ReadLine();
                }
            }

            return fireSpot;
        }

        private void RenderTurnResult(Player player, bool didHit)
        {
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            if (didHit)
            {
                Console.WriteLine("You hit their ship, nice job! Press enter to end your turn");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You missed :( Press enter to end your turn");
                Console.ReadLine();
            }
            if (player.HasWon())
            {
                Console.WriteLine(player.GetName() + " has sunk the battle ship and won!");
                gameController.setGameOver();
            }
        }

        public (string, string, string) RenderPlaceBoat()
        {
            Player player = gameController.getCurrentPlayer();
            string playerString = player.GetName() + " it's time to pick your ship's location! \nUse w to go up, \ns to go down, \na to go left, \nd to go right, \nand r to rotate your ship 90 degrees. \nPress e when you have made your decision!\n\n";
            RenderCurrentBoats(player, playerString, "");
            while (true)
            {
                string move = Console.ReadLine();
                RenderCurrentBoats(player, playerString, move);
                if (move == "e")
                {
                    break;
                }
            }
            gameController.nextTurn();
            return player.GetBoatLocation();
        }

        private (string, string, string) RenderCurrentBoats(Player player, string playerString, string move)
        {
            Console.Clear();
            Console.WriteLine(playerString);
            if (move != "")
            {
                this.MoveBoat(player, move);
            }
            (string, string, string) boatLocation = player.GetBoatLocation();
            Console.WriteLine(RenderBoardWithBoat(boatLocation.Item1, boatLocation.Item2, boatLocation.Item3));
            return boatLocation;
        }

        public string RenderBoard(Board board)
        {
            string board_string = @"
   |   A   |   B   |   C   |   D   |   E   |   F   |   G   |   H   |
";
            foreach (string column in columns)
            {
                board_string += @"-
";
                board_string += column;
                board_string += "  ";
                foreach (string row in rows)
                {
                    board_string += "    ";
                    board_string += board.ReturnBoard[row][column];
                    board_string += "   ";
                }
                board_string += @"
-

";
            }
            return board_string;
        }

        public string RenderBoardWithBoat(string row, string column, string orientation)
        {
            Board dummyBoard = new Board();
            dummyBoard.PlaceItem(row, column, orientation, "🚢");
            return this.RenderBoard(dummyBoard);
        }

        public Boolean ValidateMissileInput(string input)
        {
            if (rows.Contains(input[0].ToString()) && columns.Contains(input[1].ToString())){
                return true;
            }
            else
            {
                return false;
            }
        }

        public void MoveBoat(Player player, string move)
        {
            if (move == "w")
            {
                player.MoveBoatUp();
            }
            if (move == "a")
            {
                player.MoveBoatLeft();
            }
            if (move == "s")
            {
                player.MoveBoatDown();
            }
            if (move == "d")
            {
                player.MoveBoatRight();
            }
            if (move == "r")
            {
                player.RotateBoat();
            }
        }
    }
}
