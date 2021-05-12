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
            // TODO: select one of squares using random:
            // 1. calculate how many times each square appears in allPlacements (IEnumerable<IEnumerable<Square>>)
            // 2. find squares whic appear most often
            // 3. from these squares select randomly one as target
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
        private Random random = new Random();
    }
}
