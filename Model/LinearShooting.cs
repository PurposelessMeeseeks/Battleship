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
        public LinearShooting(Grid evidenceGrid, IEnumerable<Square> squaresHit)
        {
            this.grid = grid;
            this.squaresHit = new List<Square>(squaresHit.OrderBy(s => s.row + s.column));
        }

        public Square NextTarget()
        {
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    var left = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwords);

                    if (left.Count() > 0) 
                    {
                        squares.Add(left);
                    }

                    var right = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwords);

                    if (right.Count() > 0)
                    {
                        squares.Add(right);

                    }              
                    break;
                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwords);

                    if (up.Count() > 0)
                    {
                        squares.Add(up);
                    }
                        
                    var down = grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwords);

                    if (down.Count() > 0)
                    {
                        squares.Add(down);
                    }                       
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }

            if (squares.Count > 1)
            {
                return squares[random.Next(0, 2)].First();
            }
            
            return squares[0].First();
             
            // TODO 6: select one of them optionally using random generator
        }

        private Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].row == squaresHit[1].row)
            {
                return Orientation.Horizontal;
            }

            return Orientation.Vertical;
        }

        private Grid grid;
        private List<Square> squaresHit;
        private Random random = new Random();
    }
}