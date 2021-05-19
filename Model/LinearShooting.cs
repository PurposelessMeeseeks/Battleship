using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Vsite.Oom.Battleship.Model
{
    public enum Orientiation
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
            random = new Random();
        }

        public Square NextTarget()
        {
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientiation.Horizontal:
                {
                    var left = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwards);
                    var right = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwards);

                    if (left.Count() > 0)
                        squares.Add(left);

                    if (right.Count() > 0)
                        squares.Add(right);

                    break;
                }
                case Orientiation.Vertical:
                {
                    var up = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwards);
                    var down = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwards);

                    if (up.Count() > 0)
                        squares.Add(up);

                    if (down.Count() > 0)
                        squares.Add(down);
                    break;
                }
                default:
                    Debug.Assert(false);
                    break;
            }

            if (squares.Count > 1)
            {
                return squares[random.Next(0, 2)].First();
            }

            return squares[0].First();
        }

        Orientiation GetHitSquaresOrientation()
        {

            return (squaresHit[0].Row == squaresHit[1].Row) ? Orientiation.Horizontal 
                                                         : Orientiation.Vertical;
        }

        Grid grid;
        List<Square> squaresHit;
        Random random;
    }
}
