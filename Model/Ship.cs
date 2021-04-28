using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum HitResult
    {
        Missed,
        Hit,
        Sunken
    }
    public class Ship
    {
        public Ship(IEnumerable<Square> squares)
        {
            this.squares = squares.ToArray();
        }

        public IEnumerable<Square> Squares 
        {
            get { return squares; }
        }

        private Square[] squares;

        public HitResult Hit(Square sq)
        {
            int i = Array.FindIndex(squares, s => s.Equals(sq));
            if (i != -1)
            {
                squares[i].SetSquareState(HitResult.Hit);
                if (squares.All(s => s.SquareState.Equals(SquareState.Hit)))
                {
                    for (int j=0; j < squares.Length; j++)
                        squares[j].SetSquareState(HitResult.Sunken);
                    return HitResult.Sunken;
                }
                return HitResult.Hit;
            }
            else
            {
                sq.SetSquareState(HitResult.Missed);
                return HitResult.Missed;
            }
        }
    }
}
