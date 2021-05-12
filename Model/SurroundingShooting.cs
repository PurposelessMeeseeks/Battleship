using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var up = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwards);
            if (up.Count() > 0)
                squares.Add(up);
            var right = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rigthwards);
            if (right.Count() > 0)
                squares.Add(right);
            var down = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwards);
            if (down.Count() > 0)
                squares.Add(down);
            var left = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwards);
            if (left.Count() > 0)
                squares.Add(left);
            // TODO: select one of them as target
            throw new NotImplementedException();
        }

        Grid grid;
        Square firstHit;
        Random random = new Random();
    }
}
