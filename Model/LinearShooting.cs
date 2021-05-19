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
            //squaresHit.Sort(s => s.Row + s.Column);
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    squares.Add(grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Leftwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Rightwards));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Upwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Downwards));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
            {
                return Orientation.Horizontal;
            }
            else
            {
                return Orientation.Vertical;
            }
        }

        private Grid grid;
        private List<Square> squaresHit;
        private readonly int shipLength;
        private Random random = new Random();
     }
}
