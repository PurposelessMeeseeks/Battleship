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
        Horitontal,
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
            var sorted = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Row + s.Column));
            var orientation= GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horitontal:
                    var left = grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Leftwards);
                    if (left.Count() > 0)
                        squares.Add(left);
                    var right = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Rigrhwards);
                    if (right.Count() > 0)
                        squares.Add(right);
                    break;
                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Upwards);
                    if (up.Count() > 0)
                        squares.Add(up);
                    var down = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Downwards);
                    if (down.Count() > 0)
                        squares.Add(down);
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
                return Orientation.Horitontal;
            return Orientation.Vertical;
        }

        private Grid grid;
        private List<Square> squaresHit;
        private int shipLength;
        private Random random = new Random();
    }
}
