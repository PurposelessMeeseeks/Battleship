using System.Collections;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    public enum SquareState
    {
        Default,
        Missed,
        Hit,
        Sunken
    }
    public struct Square : IEnumerable<Square>
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

        public SetSquareState(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Hit:
                    break;
                case HitResult.Sunken:
                    break;
                case HitResult.Missed:
                    break;
            }

            
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

        public IEnumerator<Square> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
