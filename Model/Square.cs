using System;

namespace Vsite.Oom.Battleship.Model
{
    public struct Square
    {
        public Square(int row, int column)
        {
            this.row    = row;
            this.column = column;
        }

        public int row;
        public int column;

    }
}


