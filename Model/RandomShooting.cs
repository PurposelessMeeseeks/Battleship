using System;

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
            // vraća nizove nizova
            var allPlacements = grid.GetAvailablePlacements(shipLength);
            throw new NotImplementedException();
        }

        private Grid grid;
        private int shipLength;
    }
}
