using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SorroundingShooting : ITargetSelect
    {
        public SorroundingShooting(Grid grid, Square firstHit)
        {
            this.grid = grid;
            this.firstHit = firstHit;
            random = new Random();
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rightwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwards));
            // get from grid available sorrounding squares
            // select one of them as target
            throw new NotImplementedException();
        }

        Grid grid;
        Square firstHit;
        Random random;
    }
}
