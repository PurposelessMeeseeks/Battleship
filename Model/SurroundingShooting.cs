using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        public SurroundingShooting(Grid grid, Square FirstHit)
        {
            this.grid = grid;
            this.firstHit = firstHit;
        }

        public SurroundingShooting(Grid evidenceGrid, List<int> shipsToShoot)
        {
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwords));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rightwords));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwords));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwords));

            // select one of the as target
            throw new NotImplementedException();
        }

       

        Grid grid;
        Square firstHit;
        Random random = new Random();
    }
}