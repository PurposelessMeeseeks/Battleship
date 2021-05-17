using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ISelectTarget
    {
        public SurroundingShooting(Grid grid, Square initiallyHit, int shipLength)
        {
            this.grid = grid;
            this.initiallyHit = initiallyHit;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }

        private Grid grid;
        private Square initiallyHit;
        private int shipLength;
    }
}
