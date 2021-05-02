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
            //check if square belongs to this ship
            //if not :return hitresult.missed
            //if yes:
            //      1.check if all other squares are hit,return Hitresult.Sunken
            //      and mark all squares sunken
            //      2. else,mark the square hit and return HitResult.Hit
            throw new NotImplementedException();
        }

        private Square[] squares;
    }
}
