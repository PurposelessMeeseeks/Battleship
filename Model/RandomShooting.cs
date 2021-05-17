using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ISelectTarget
    {
        public RandomShooting(Grid grid,int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
    }
}
