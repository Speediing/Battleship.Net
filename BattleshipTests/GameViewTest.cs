using System;
using System.Collections.Generic;
using Battleship;
using Xunit;
using System.Linq;

namespace BattleshipTests
{
    public class GameViewTest
    {
        private GameView gameView;
        private Board board;
        private Player player;

        public GameViewTest()
        {
            gameView = new GameView();
            board = new Board();
            player = new Player();
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
            string gameRenderedBoard = gameView.RenderBoard(board);
            string sanitizedRenderedBoard = string.Concat(renderedBoard.Where(c => !char.IsWhiteSpace(c)));
            string sanitizedGameRenderedBoard = string.Concat(gameRenderedBoard.Where(c => !char.IsWhiteSpace(c)));
            Assert.Equal(sanitizedRenderedBoard, sanitizedGameRenderedBoard);
        }

        [Fact]
        public void shouldRenderGameWithBoat()
        {
            string renderedBoard = @"
   |   A   |   B   |   C   |   D   |   E   |   F   |   G   |   H   |
-
1      🚢       🚢       🚢       *       *       *       *       *   
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
            string gameRenderedBoard = gameView.RenderBoardWithBoat("A", "1", "x");
            string sanitizedRenderedBoard = string.Concat(renderedBoard.Where(c => !char.IsWhiteSpace(c)));
            string sanitizedGameRenderedBoard = string.Concat(gameRenderedBoard.Where(c => !char.IsWhiteSpace(c)));
            Assert.Equal(sanitizedRenderedBoard, sanitizedGameRenderedBoard);
        }

        [Fact]
        public void shouldRenderGameWithYAxisBoat()
        {
            string renderedBoard = @"
   |   A   |   B   |   C   |   D   |   E   |   F   |   G   |   H   |
-
1      🚢       *       *       *       *       *       *       *   
-
            
-
2      🚢       *       *       *       *       *       *       *   
-
            
-
3      🚢       *       *       *       *       *       *       *   
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
            string gameRenderedBoard = gameView.RenderBoardWithBoat("A", "1", "y");
            string sanitizedRenderedBoard = string.Concat(renderedBoard.Where(c => !char.IsWhiteSpace(c)));
            string sanitizedGameRenderedBoard = string.Concat(gameRenderedBoard.Where(c => !char.IsWhiteSpace(c)));
            Assert.Equal(sanitizedRenderedBoard, sanitizedGameRenderedBoard);
        }

        [Fact]
        public void shouldValidateMissileInputIsTrue()
        {
            Assert.True(gameView.ValidateMissileInput("A1"));
        }

        [Fact]
        public void shouldValidateMissileInputIsFalse()
        {
            Assert.False(gameView.ValidateMissileInput("Bad"));
        }

        [Fact]
        public void shouldMoveBoat()
        {
            gameView.MoveBoat(player, "w");
            gameView.MoveBoat(player,"a");
            gameView.MoveBoat(player,"s");
            gameView.MoveBoat(player,"d");
            gameView.MoveBoat(player, "r");
            Assert.Equal(("A", "1", "y"), player.GetBoatLocation());
        }
    }
}
