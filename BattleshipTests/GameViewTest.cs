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
            BoardDimentions.GenerateDimentionsBySize(8);
            gameView = new GameView();
            board = new Board();
            player = new Player();
            player.InitializeBoards();

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
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
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
            string gameRenderedBoard = gameView.RenderBoardWithBoat(location);
            string sanitizedRenderedBoard = string.Concat(renderedBoard.Where(c => !char.IsWhiteSpace(c)));
            string sanitizedGameRenderedBoard = string.Concat(gameRenderedBoard.Where(c => !char.IsWhiteSpace(c)));
            Assert.Equal(sanitizedRenderedBoard, sanitizedGameRenderedBoard);
        }

        [Fact]
        public void shouldRenderGameWithYAxisBoat()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
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
            string gameRenderedBoard = gameView.RenderBoardWithBoat(location);
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
        public void shouldValidateDimentionInputIsTrue()
        {
            Assert.True(gameView.ValidateDimentionInput("6"));
        }

        [Fact]
        public void shouldValidateDimentionInputIsFalse()
        {
            Assert.False(gameView.ValidateDimentionInput("Bad"));
        }

        [Fact]
        public void shouldMoveBoat()
        {
            BoatLocation location = new BoatLocation("A", "1", Orientation.X);
            gameView.MoveBoat(player, "w");
            gameView.MoveBoat(player,"a");
            gameView.MoveBoat(player,"s");
            gameView.MoveBoat(player,"d");
            gameView.MoveBoat(player, "r");
            Assert.Equal(location, player.GetBoatLocation());
        }
    }
}
