using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum Orientation
    {
        Horizontal,
        Vertical
    }

    public class LinearShooting : ITargetSelect
    {
        public LinearShooting(Grid grid, List<Square> squaresHit, int shipLength)
        {
            this.grid = grid;
            this.squaresHit = squaresHit;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            var sorted = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Column));
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            switch (orientation)
            {
                case Orientation.Horizontal:
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwards));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwards));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            // TODO: do it in similar way as for SurroundingShooting
            /*
             var sorted = squares.OrderByDescending(seq => seq.Count());
            int maxLength = sorted.ElementAt(0).Count();
            if (maxLength > shipLength - 1)
                maxLength = shipLength - 1;
            var longest = sorted.Where(seq => seq.Count() >= maxLength);
            if (longest.Count() == 1)
                return longest.ElementAt(0).First();
            int index = random.Next(longest.Count());
            return longest.ElementAt(index).First();
             */
            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
                return Orientation.Horizontal;
            
            return Orientation.Vertical;
        }

        private Grid grid;
        private List<Square> squaresHit;
        private Random random = new Random();
        private int shipLength;
     }
}
