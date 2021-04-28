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
        Sunked

    }

    public struct Square : IEquatable<Square>
    {
        public Square(int row, int column)
        {
            Row = row;
            Column = column;
            squareState = SquareState.Default;
        }

        public readonly int Row;
        public readonly int Column;



        private SquareState squareState;

        public void SetSquareState(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    //todo
                    break;
                case HitResult.Hit:
                    break;
                case HitResult.Sunken:
                    break;
            }
            throw new NotImplementedException();
        }

        public SquareState SquareState
        {
            get { return squareState; }
        }

        public bool Equals(Square other)
        {
            return Row == other.Row && Column == other.Column;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() != GetType())
                return false;
            return Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            return Row ^ Column;
        }
    }
}
