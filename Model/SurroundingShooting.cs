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

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Grid.Direction.Upwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Grid.Direction.Rightwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Grid.Direction.Downwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Grid.Direction.Leftwards));

            // TODO 5: select one of the as target
            throw new NotImplementedException();
        }

        private Grid grid;
        private Square firstHit;
        private Random random = new Random();
    }
}
