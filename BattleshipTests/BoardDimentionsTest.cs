using System;
using System.Collections.Generic;
using Battleship;
using Xunit;

namespace BattleshipTests
{
    public class BoardDimentionsTest
    {

        public BoardDimentions boardDimentions;
        public BoardDimentionsTest()
        {
            boardDimentions = new BoardDimentions();
        }

        [Fact]
        public void shouldSetBoardRows()
        {
            List<string> testRows= new List<string>() { "A", "B", "C" };
            BoardDimentions.GenerateDimentionsBySize(3);
            Assert.Equal(testRows, BoardDimentions.GetRows());
        }


        [Fact]
        public void shouldSetBoardColumns()
        {
            List<string> testColumns = new List<string>() { "1", "2", "3" };
            BoardDimentions.GenerateDimentionsBySize(3);
            Assert.Equal(testColumns, BoardDimentions.GetColumns());
        }
    }
}
