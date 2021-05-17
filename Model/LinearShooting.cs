using System;
using System.Collections.Generic;
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

    public class LinearShooting : ISelectTarget
    {
        public LinearShooting(Grid grid, IEnumerable<Square> alreadyHit, int shipLength)
        {
            this.grid = grid;
            squaresHit = new List<Square>(alreadyHit);
            this.shipLength = shipLength;
            this.orientation = GetOrientation();
        }

        private Orientation GetOrientation()
        {
            return squaresHit.First().Row == squaresHit.Last().Row ? Orientation.Horizontal : Orientation.Vertical;
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    // get squares left from the leftmost square in 'squaresHit'
                    // get squares right from the rightmost square in 'squaresHit'
                    break;
                case Orientation.Vertical:
                    // get squares up from the topmost square in 'squaresHit'
                    // get squares below the bottommost square in 'squaresHit'
                    break;
            }
            // from list 'squares' select only those which are longer than shipLength - squaresHit
            // from remaning randomly select one
            // from selected list take first square
            throw new NotImplementedException();
        }

        private Grid grid;
        private List<Square> squaresHit;
        private int shipLength;
        private Orientation orientation;
    }
}
