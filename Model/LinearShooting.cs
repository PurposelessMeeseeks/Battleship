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
        public LinearShooting(Grid grid, List<Square> squaresHit,int shipLenght)
        {
            this.grid = grid;
            this.squaresHit = squaresHit;
            this.shipLenght = shipLenght;
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
                    var left = grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Leftwardes);
                    if (left.Count() > 0)
                        squares.Add(left);
                    var right = grid.GetAvailablePlacementsInDirection(sorted.Last(), Direction.Rightwardes);
                    if (right.Count() > 0)
                        squares.Add(right);
                    break;
                case Orientation.Vertical:
                    var up = grid.GetAvailablePlacementsInDirection(sorted[0], Direction.Upwardes);
                    if (up.Count() > 0)
                    squares.Add(up);
                    var down = grid.GetAvailablePlacementsInDirection(sorted[1], Direction.Downwareds);
                    if (down.Count() > 0)
                        squares.Add(down);
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            if (squares.Count > 1)
                return squares[random.Next(0, 2)].First();
            return squares[0].First();
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
        private int shipLenght;
    }
}
