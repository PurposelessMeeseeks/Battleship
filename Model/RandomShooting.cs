using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, IEnumerable<int> shipLenghts)
        {
            this.grid = grid;
            this.shipLenght = shipLenght;
        }
        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLenght);
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLenght;

    }
}
