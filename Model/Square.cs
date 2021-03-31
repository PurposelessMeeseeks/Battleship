using System;

namespace Vsite.Oom.Battleship.Model
{
    public struct Square
    {
        public Square(int row, int column)
        {
            Row    = row;
            Column = column;
        }

        public int Row;
        public int Column;

    }
}


