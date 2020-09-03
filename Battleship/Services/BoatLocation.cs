using System;
namespace Battleship
{
    public class BoatLocation
    {
        private string row;
        private string column;
        private Orientation orientation;

        public BoatLocation(string row, string column, Orientation orientation)
        {
            this.row = row;
            this.column = column;
            this.orientation = orientation;
        }

        public string GetRow() => row;
        public string GetColumn() => column;
        public Orientation GetOrientation() => orientation;

        public void SetRow(string row)
        {
            this.row = row;
        }

        public void SetColumn(string column)
        {
            this.column = column;
        }

        public void SetOrientation(Orientation orientation)
        {
            this.orientation = orientation;
        }
    }
}
