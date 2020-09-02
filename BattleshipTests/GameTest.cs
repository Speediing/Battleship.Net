using System;
using System.Collections.Generic;
using Battleship;
using Xunit;
using System.Linq;

namespace BattleshipTests
{
    public class GameTest
    {
        private Game game;
        private Board board;

        public GameTest()
        {
            game = new Game();
            board = new Board();
        }

        [Fact]
        public void shouldRenderEmptyGame()
        {
            string renderedBoard = @"
   |   A   |   B   |   C   |   D   |   E   |   F   |   G   |   H   |
-
1      *       *       *       *       *       *       *       *   
-
            
-
2      *       *       *       *       *       *       *       *   
-
            
-
3      *       *       *       *       *       *       *       *   
-
            
-
4      *       *       *       *       *       *       *       *   
-
            
-
5      *       *       *       *       *       *       *       *   
-
            
-
6      *       *       *       *       *       *       *       *   
-
            
-
7      *       *       *       *       *       *       *       *   
-
            
-
8      *       *       *       *       *       *       *       *   
-
            
";
            string gameRenderedBoard = game.RenderBoard(board);
            string sanitizedRenderedBoard = string.Concat(renderedBoard.Where(c => !char.IsWhiteSpace(c)));
            string sanitizedGameRenderedBoard = string.Concat(gameRenderedBoard.Where(c => !char.IsWhiteSpace(c)));
            Assert.Equal(sanitizedRenderedBoard, sanitizedGameRenderedBoard);
        }
    }
}
