using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        private Grid Grid;
        private int ShipLength;

        public RandomShooting(Grid evidenceGrid, int shipLength)
        {
            Grid = evidenceGrid;
            ShipLength = shipLength;
        }

        public Square NextTarget()
        {

            var allPlacements = Grid.GetAvailablePlacements(ShipLength);
            
            //select one of the squares using random
            // calculate how many times each square appears in allPlacements - from IEnumerable<IEnumerable<Square>>
            allPlacements.Count();

            throw new NotImplementedException();
        }
    }
}
