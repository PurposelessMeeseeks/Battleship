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
        public HitResult Hit(Square square)
        {
            // check if square belong to this ship
            //if not: retunr Hitresult.Missed
            //if yes: 
            //      1.  if all other squares are hit, return HitResult.Sunken
            //          and mark all squares sunken 
            //      2.  else, mark the square hti and return HitResult.Hit

            bool outsideShip = true;


            for(int i = 0; i < squares.Length; i++)
            {
                if (squares[i].Equals(square))
                {
                    outsideShip = false;
                    squares[i].SetSquareState(HitResult.Hit);
                    square.SetSquareState(HitResult.Hit);
                }
            }

            bool sunken = true;
            foreach (Square s in squares)
                if (s.SquareState != SquareState.Hit)
                {
                    sunken = false;
                }

            if(sunken)
            {
                for(int i = 0; i < squares.Length; i++)
                    squares[i].SetSquareState(HitResult.Sunken);
                return HitResult.Sunken;
            }


            if (outsideShip) return HitResult.Missed;

            return HitResult.Hit;

            //throw new NotImplementedException();

        }

        private Square[] squares;
    }
}
