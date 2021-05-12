using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        public RandomShooting(Grid grid, int shipLenght)
        {
            this.grid = grid;
            this.shipLenght = shipLenght;
        }

        public Square NextTarget()
        {
            var allPlacements = grid.GetAvailablePlacements(shipLenght);
            // select one of squares using random
            // calculate how many times IEnumerable<IEnumerable<Square>> calculate how many times
            //
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLenght;
        private Random random = new Random();
    }
}
