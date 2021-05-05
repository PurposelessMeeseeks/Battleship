using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LinearShooting : ITargetSelect
    {

        public LinearShooting(Grid grid, IEnumerable<int> squaresHit)
        {

        }


        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
     }
}
