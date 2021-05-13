using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{

    public class SurroundingShooting : ITargetSelect
    {

        public SurroundingShooting(Grid grid, Square firstHit)
        {
            this.grid = grid;
            this.firstHit = firstHit;
        }
        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            
            squares.Add(grid.GetAvailablePlacementsInDirecion(firstHit, Direction.Upwards));
            squares.Add(grid.GetAvailablePlacementsInDirecion(firstHit, Direction.Rightwards));
            squares.Add(grid.GetAvailablePlacementsInDirecion(firstHit, Direction.Downwards));
            squares.Add(grid.GetAvailablePlacementsInDirecion(firstHit, Direction.Leftwards));

            // TODO: DZ select one of them as target
            throw new NotImplementedException();

        }

        Grid grid;
        Square firstHit;
        Random random = new Random();
    }
}
