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
            gameController = new GameController();
        }

        public void StartGame()
        {
            bool gameInProgress = true;
            while (gameInProgress)
            {
                switch (gameController.GetCurrentStage())
                {
                    case Stage.setNames:
                        {
                            (string, string) names = RenderGetPlayerNames();
                            gameController.SetPlayerNames(names.Item1, names.Item2);
                            break;
                        }
                    case Stage.setDimentions:
                        {
                            RenderGetDimentions();
                            break;
                        }
                    case Stage.setBoats:
                        {
                            (string, string, string) playerBoatLocation = RenderPlaceBoat();
                            gameController.SetPlayerBoatLocation(playerBoatLocation);
                            break;
                        }
                    case Stage.fireMissile:
                        {
                            RenderMissileTurn();
                            break;
                        }
                    case Stage.gameOver:
                        {
                            RenderGameOver();
                            gameInProgress = false;
                            break;
                        }
                }
            }

        }

        public (string, string) RenderGetPlayerNames()
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
            return (player1Name, player2Name);
        }
        public void RenderGetDimentions()
        {
            Console.WriteLine("What is the size of the board you would like");
            string size = Console.ReadLine();
            while (true)
            {
                if (ValidateDimentionInput(size))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try Again. Make sure you input a number between 5 and 20!\n\n");
                    size = Console.ReadLine();
                }
            }
            gameController.SetBoardDimentions(int.Parse(size));
        }
        public void RenderMissileTurn()
        {
            string fireSpot = RenderGetFireSpot();
            bool didHit = gameController.FireMissile(fireSpot[0].ToString(), fireSpot[1].ToString());
            RenderTurnResult(didHit);
        }

        public string RenderGetFireSpot()
        {
            Console.Clear();
            RenderCurrentPlayerBoard();
            Console.WriteLine(gameController.GetCurrentPlayerName() + " it's time to pick a location to fire! Enter your location like: 'B5'\n\n");
            string fireSpot = Console.ReadLine();
            while (true)
            {
                if (ValidateMissileInput(fireSpot))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(gameController.GetCurrentPlayerName() + " your location was incorrectly formatted! Enter your location like: 'B5'\n\n");
                    fireSpot = Console.ReadLine();
                }
            }

            return fireSpot;
        }

        public void RenderTurnResult(bool didHit)
        {
            Console.Clear();
            RenderOtherPlayersBoard();
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
        }

        public void RenderGameOver()
        {
            Console.WriteLine(gameController.GetCurrentPlayerName() + " has sunk the battle ship and won!");
        }

        public (string, string, string) RenderPlaceBoat()
        {
            Player player = gameController.GetCurrentPlayer();
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
            return player.GetBoatLocation();
        }

        public (string, string, string) RenderCurrentBoats(Player player, string playerString, string move)
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

        public void RenderOtherPlayersBoard()
        {
            Console.WriteLine(RenderBoard(gameController.GetOpponentPlayer().GetPersonalBoard()));
        }
        public void RenderCurrentPlayerBoard()
        {
            Console.WriteLine(RenderBoard(gameController.GetCurrentPlayer().GetPersonalBoard()));
        }

        public string RenderBoard(Board board)
        {
            string board_string = @"
";
            foreach (string firstRow in BoardDimentions.GetRows())
            {
                board_string += "   |   ";
                board_string += firstRow;

            }
            board_string += @"   |
";
            foreach (string column in BoardDimentions.GetColumns())
            {
                board_string += @"-
";
                board_string += column;
                board_string += "  ";
                foreach (string row in BoardDimentions.GetRows())
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

        public bool ValidateMissileInput(string input)
        {
            return (BoardDimentions.GetRows().Contains(input[0].ToString()) && BoardDimentions.GetColumns().Contains(input[1].ToString()));
        }

        public bool ValidateDimentionInput(string input)
        {
            int size;
            bool validInt = int.TryParse(input, out size);
            return validInt && size > 4 && size < 21;
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
