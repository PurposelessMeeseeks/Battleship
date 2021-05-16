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
        private Random random = new Random();

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
            // TODO 1: select one of squares using random:
            // TODO 2: calculate how many times each square appears in AllPlacements (IEnumerable<IEnumerable<Squares>>)
            // TODO 3: find squares which appear most often
            // TODO 4: from these squares  select randomly one as target
            throw new NotImplementedException();
        }
    }
}
