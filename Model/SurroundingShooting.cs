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
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rightwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwards));
            squares.Add(grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwards));
            // get from grid available surrounding squares = rjeseno^
            // select one of them as a target
            int randBroj = random.Next(0, 4);
            return squares[randBroj].First();
        }

        Grid grid;
        Square firstHit;
        Random random = new Random();
    }
}
