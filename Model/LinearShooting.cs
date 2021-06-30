using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

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
            random = new Random();
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
                {
                    var left = grid.GetAvailablePlacementsInDirection(sorted.First(), Direction.Leftwards);
                    var right = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Rightwards);

                    if (left.Count() > 0)
                    {
                        squares.Add(left);
                    }


                    if (right.Count() > 0)
                    {
                        squares.Add(right);
                    }
                    break;
                }
                case Orientation.Vertical:
                {
                    var up = grid.GetAvailablePlacementsInDirection(sorted.First(), Direction.Upwards);
                    var down = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Downwards);

                    if (up.Count() > 0)
                    {
                        squares.Add(up);
                    }

                    if (down.Count() > 0)
                    {
                        squares.Add(down);
                    }
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

        private Orientation GetHitSquaresOrientation()
        {
            return (squaresHit[0].Row == squaresHit[1].Row) ? Orientation.Horizontal
                                                            : Orientation.Vertical;
        }

        Grid grid;
        List<Square> squaresHit;
        Random random;
        private readonly int shipLength;
    }
}