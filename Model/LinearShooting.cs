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
            this.sqaresHit = new List<Square>(squaresHit.OrderBy(s => s.row + s.column));
        }

        public Square NextTarget()
        {
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            switch (orientation)
            {
                case Orientation.Horizontal:
                    squares.Add(grid.GetAvailablePlacementsInDirection(sqaresHit[0]), Direction.Leftwords));
                    squares.Add(grid.GetAvailablePlacementsInDirection(sqaresHit[1]), Direction.Rightwords));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirection(sqaresHit[0]),Direction.Upwords));
                    squares.Add(grid.GetAvailablePlacementsInDirection(sqaresHit[0]), Direction.Downwords));
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            // TODO: get from grid available squares continuation 
            // TODO: find squares in continuation of squares hit 
            // TODO: select one of them optionally using random generator 

            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (sqaresHit[0].row==sqaresHit[1].row)
            {
                return Orientation.Horizontal;
            }

            return Orientation.Vertical;
        }

        Grid grid;
        List<Square> sqaresHit;
        Random random = new Random();

    }
}