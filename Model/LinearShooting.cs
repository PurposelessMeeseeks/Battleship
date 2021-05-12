using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class LinearShooting : ITargetSelect
    {
        public enum Orientation
        {
            Horizontal,
            Vertical
        }
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
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwardes));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwardes));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwardes));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwareds));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            //select one of them optionally using random number generator
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
