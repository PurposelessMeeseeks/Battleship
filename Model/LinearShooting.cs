using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LinearShooting : ISelectTarget
    {
        public LinearShooting(Grid grid,IEnumerable<Square> alreadyHit,int shipLength)
        {
            this.grid = grid;
            squaresHit = new List<Square>(alreadyHit);
            this.shipLength = shipLength;
        }
        Square ISelectTarget.NextTarget()
        {
            throw new NotImplementedException();
        }

        private Grid grid;
        private List<Square> squaresHit;
        private int shipLength;
    }
}
