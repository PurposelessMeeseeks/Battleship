using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LinearShooting : ITargetSelect
    {
        public LinearShooting(Grid grid, IEnumerable<Square> squaresHit)
        {
            this.grid = grid;
            this.squaresHit = new List<Square>(squaresHit);
        }
        public Square NextTarget()
        {
            // find squares in countinuation of sqaures hit
            // selecet one of them 
            throw new NotImplementedException();
        }

        Grid grid;
        List<Square> squaresHit;
        Random random = new Random();
    }
}
