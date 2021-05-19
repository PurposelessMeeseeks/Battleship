using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
                    squares.Add(grid.GetAvailablePlacementsInDirecion(squaresHit[0], Direction.Leftwards));
                    squares.Add(grid.GetAvailablePlacementsInDirecion(squaresHit[1], Direction.Rightwards));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirecion(squaresHit[0], Direction.Upwards));
                    squares.Add(grid.GetAvailablePlacementsInDirecion(squaresHit[1], Direction.Downwards));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            // TODO: DZ select one of them optionally using random number generator
            // do it in similar way as for surrounding shooting
            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
                return Orientation.Horizontal;
            return Orientation.Vertical;
        }
        Grid grid;
        int shipLength;
        List<Square> squaresHit;
    }
}
