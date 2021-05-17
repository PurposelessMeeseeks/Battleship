using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model {
    public class RandomShooting : ITargetSelect {
        private readonly Grid Grid;
        private readonly int ShipLenght;
        private Grid evidenceGrid;
        private List<int> shipsToShoot;

        public RandomShooting(Grid grid, int shipLenght) {
            Grid = grid;
            ShipLenght = shipLenght;
        }

        public RandomShooting(Grid evidenceGrid, List<int> shipsToShoot) {
            this.evidenceGrid = evidenceGrid;
            this.shipsToShoot = shipsToShoot;
        }

        public Square NextTarget() {
            var allPlacements = Grid.GetAvailablePlacements(ShipLenght);
            throw new NotImplementedException();
        }
    }
}