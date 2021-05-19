using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        public SurroundingShooting(Grid grid, Square firstHit)
        {
            this.grid = grid;
            this.firstHit = firstHit;
        }
        public Square NextTarget()
        {
            // get from grid available surrounding squares
            // select one of them as target
            throw new NotImplementedException();
        }
        Grid grid;
        Square firstHit;
        Random random = new Random();
    }
}
