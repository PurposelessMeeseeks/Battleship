using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    public class RandomShooting : ITargetSelect
    {
        private readonly Grid Grid;
        private readonly int ShipLenght;
        private Grid evidenceGrid;
        private List<int> shipsToShoot;

        public RandomShooting(Grid grid, int shipLenght)
        {
            Grid = grid;
            ShipLenght = shipLenght;
        }

        public RandomShooting(Grid evidenceGrid, List<int> shipsToShoot)
        {
            this.evidenceGrid = evidenceGrid;
            this.shipsToShoot = shipsToShoot;
        }

        public Square NextTarget()
        {
            var allPlacements = Grid.GetAvailablePlacements(ShipLenght);
            // select one of squares using random:
            // 1. calculate how many times each square appears in AllPlacements (IEnumerable<IEnumerable<Squares>>)
            // 2. find squares which appear most often 
            // 3. from these squares  select randomly one as target 
            throw new NotImplementedException();
        }
    }
}