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
            this.squaresHit = new List<Square>(squaresHit.OrderBy(s => s.Row + s.Column));
            this.shipLength = shipLength;
        }

        public LinearShooting(Grid grid1, List<Square> squares)
        {
            this.grid1 = grid1;
            this.squares = squares;
        }

        public Square NextTarget()
        {
            var orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            switch (orientation)
            {
                case Orientation.Horitontal:
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rigrhwards));
                    break;
                case Orientation.Vertical:
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwards));
                    squares.Add(grid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwards));                
                    break;
                default:
                    Debug.Assert(false);
                    break;
            }
            // find squares in countinuation of sqaures hit
            // selecet one of them 
            throw new NotImplementedException();
        }

        Orientation GetHitSquaresOrientation()
        {
            if (squaresHit[0].Row == squaresHit[1].Row)
                return Orientation.Horitontal;
            return Orientation.Vertical;
        }

        Grid grid;
        List<Square> squaresHit;
        private Shipwright shipLength;
        Random random = new Random();
        private Grid grid1;
        private List<Square> squares;
    }
}
