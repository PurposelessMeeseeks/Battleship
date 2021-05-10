using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum SquareState
    {
        Default,
        Missed,
        Hit,
        Sunken
    }

    public struct Square
    {
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
            squareState = SquareState.Default;
        }

        public void SetState(SquareState newState)
        {
            squareState = newState;
        }

        public SquareState SquareState
        {
            get { return squareState; }
        }

        public readonly int Row;
        public readonly int Column;

        private SquareState squareState;
    }
}
