using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, IEnumerable<int> shipLengths)
        {

        }
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }
    }
}
