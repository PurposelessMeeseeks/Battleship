using System;

namespace Vsite.Oom.Battleship.Model
{
    public struct Square
    {
        public Square(int row, int column)
        {
            _row = row;
            _column = column;
        }

        public int _row;
        public int _column;

    }
}


