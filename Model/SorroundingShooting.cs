using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SorroundingShooting : ITargetSelect
    {
        public SorroundingShooting(Grid grid, Square firstHit, int shipLength)
        {
            this.grid = grid;
            this.firstHit = firstHit;
            this.shipLength = shipLength;
            random = new Random();
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            var right = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Rightwards);
            var down  = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Downwards);
            var left  = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Leftwards);
            var up    = grid.GetAvailablePlacementsInDirection(firstHit, Direction.Upwards);


            if (right.Count() > 0)
            {
                squares.Add(right);
            }

            if (down.Count() > 0)
            {
                squares.Add(down);
            }

            if (left.Count() > 0)
            {
                squares.Add(left);
            }

            if (up.Count() > 0)
            {
                squares.Add(up);
            }

            var sorted = squares.OrderBy(seq => seq.Count());
            int maxLength = sorted.ElementAt(0).Count();

            if (maxLength > shipLength - 1)
            {
                maxLength = shipLength - 1; 
            }

            var longest = sorted.Where(seq => seq.Count() >= maxLength);

            if (longest.Count() == 1)
            {
                return longest.ElementAt(0).First();
            }

            int index = random.Next(longest.Count());
            return longest.ElementAt(index).First();
        }

        Grid grid;
        Square firstHit;
        Random random;

        int shipLength;
    }
}
