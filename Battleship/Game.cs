using System;
using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Game
    {
        private List<string> columns;
        private List<string> rows;

        public Game()
        {
            rows = new List<string>() { "A", "B", "C", "D", "E", "F", "G", "H" };
            columns = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8" };
        }

        public void StartGame(string player1Name, string player2Name)
        {
            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            (string, string, string) player1BoatLoaction = PlaceBoat(player1);
            (string, string, string) player2BoatLoaction = PlaceBoat(player2);
            player1.SetOpponentBoatLocation(player2BoatLoaction);
            player1.SetOpponentBoatLocation(player1BoatLoaction);
            while (true)
            {
                if (TakeTurn(player1))
                {
                    break;
                }
                if (TakeTurn(player2))
                {
                    break;
                }
            }
        }

        public Boolean TakeTurn(Player player)
        {
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            Console.WriteLine(player.GetName() + " it's time to pick a location to fire! Enter your location like: 'B5'\n\n");
            string fireSpot = Console.ReadLine();
            while (true)
            {
                if(ValidateMissileInput(fireSpot) == true)
                {
                    break;
                }
                else
                {
                    Console.WriteLine(player.GetName() + " your location was incorrectly formatted! Enter your location like: 'B5'\n\n");
                    fireSpot = Console.ReadLine();
                }
            }
            Boolean result = player.FireMissile(fireSpot[0].ToString(), fireSpot[1].ToString());
            Console.Clear();
            Console.WriteLine(RenderBoard(player.GetPersonalBoard()));
            if (result)
            {
                Console.WriteLine("You hit their ship, nice job! Press enter to end your turn");
                Console.ReadLine();
            }else{
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

        public (string,string,string) PlaceBoat(Player player)
        {
            Console.Clear();
            string playerString = player.GetName() + " it's time to pick your ship's location! \nUse w to go up, \ns to go down, \na to go left, \nd to go right, \nand r to rotate your ship 90 degrees. \nPress e when you have made your decision!\n\n";
            Console.WriteLine(playerString);
            (string, string, string) boatLocation = player.GetBoatLocation();
            Console.WriteLine(RenderBoardWithBoat(boatLocation.Item1, boatLocation.Item2, boatLocation.Item3));
            while (true)
            {
                string move = Console.ReadLine();
                Console.Clear();
                Console.WriteLine(playerString);
                player.MoveBoat(move);
                boatLocation = player.GetBoatLocation();
                Console.WriteLine(RenderBoardWithBoat(boatLocation.Item1, boatLocation.Item2, boatLocation.Item3));
                if(move == "e")
                {
                    break;
                }
            }
            return player.GetBoatLocation();
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
    }
}
