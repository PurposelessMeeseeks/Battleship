using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Ship
    {
        public Ship(IEquatable<Square> squares)
        {
            this.squares = squares.ToArray();
        }

        public IEquatable<Square> Squares
        {
            get { return squares; }
        }
        private Square[] squares;
    }
}
