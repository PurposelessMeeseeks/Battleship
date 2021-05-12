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
        public LinearShooting(Grid grid, IEnumerable<Square> squaresHit)
        {
            this.grid = grid;
            this.squaresHit = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Column));
        }
        public Square NextTarget()
        {
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
            // get from grid avaliable squares in continuation
            // select one of them optionally using random number generator
            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
                return Orientation.Horizontal;
            return Orientation.Vertical;
        }

        Grid grid;
        List<Square> squaresHit;
        Random random = new Random();
    }
}
