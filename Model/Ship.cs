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

        public HitResult Hit(Square target)
        {
            // if target is not in squares collection then return Missed
            // if target is one of squares then mark that square as Hit
            // check if all squares are marked Hit:
            //   if all squares are hit, then mark all squares sunken and return Sunken
            //   else return Hit
            throw new NotImplementedException();
        }

        private Square[] squares = null;
    }
}
