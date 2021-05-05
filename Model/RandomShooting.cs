using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, int shipLength)
        {
            this.grid = grid;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLength);


            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
    }
}
