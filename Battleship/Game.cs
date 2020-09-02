using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Game
    {
        private List<string> columns;
        private List<string> rows;
        private GameController gameController;

        public Game()
        {
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
            gameController = new GameController();
        }

        public void StartGame(string player1Name, string player2Name)
        {
            gameController.setPlayerNames(player1Name, player2Name);
            (string, string, string) player1BoatLoaction = RenderPlaceBoat(gameController.getPlayer1());
            (string, string, string) player2BoatLoaction = RenderPlaceBoat(gameController.getPlayer2());
            gameController.SetPlayerBoatLocation(player1BoatLoaction, player2BoatLoaction);
            while (true)
            {
                if (RenderTurn(gameController.getPlayer1()))
                {
                    break;
                }
                if (RenderTurn(gameController.getPlayer2()))
                {
                    break;
                }
            }
        }

        public bool RenderTurn(Player player)
        {
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            Console.WriteLine(player.GetName() + " it's time to pick a location to fire! Enter your location like: 'B5'\n\n");
            string fireSpot = GetFireSpot(player);
            bool result = player.FireMissile(fireSpot[0].ToString(), fireSpot[1].ToString());
            return RenderTurnResult(player, result);

        }

        private string GetFireSpot(Player player)
        {
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

        private bool RenderTurnResult(Player player, bool result)
        {
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            if (result)
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
                return true;
            }
            return false;
        }

        public (string, string, string) RenderPlaceBoat(Player player)
        {

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
