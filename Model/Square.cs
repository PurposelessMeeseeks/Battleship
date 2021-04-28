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
    public struct Square : IEquatable<Square>
    {
        public Square(int Row, int Column)
        {
            row = Row;
            column = Column;
            squareState = SquareState.Default;

        }

        public readonly int row;
        public readonly int column;

        private SquareState squareState;

        public void SetSquareState(HitResult hitResult)
        {
            switch (hitResult)
            {
                case HitResult.Missed:
                    break;
                case HitResult.Hit:
                    break;
                case HitResult.Sunken:
                    break;
                default:
                    break;
            }
        }

        public SquareState SquareState
        {
            get { return squareState; }
        }

        public bool Equals(Square other)
        {
            return row == other.row && column == other.column;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType()!=GetType())
            {
                return false;
            }

            return Equals((Square)obj);
        }

        public override int GetHashCode()
        {
            return row ^ column;
        }
    }
}
