using System;

namespace Battleship
{
    class Program
    {
        static void Main(string[] args)
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
            Game game = new Game();
            Board board = new Board();
            Console.WriteLine(game.RenderBoard(board));
            string player2Name2 = Console.ReadLine();
        }
    }
}
