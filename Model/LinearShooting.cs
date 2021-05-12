using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{

    public enum Orientation
    {
        Vertical,
        Horizontal
    }

    public class LinearShooting : ITargetSelect
    {
        Grid MyGrid;
        List<Square> squaresHit;
        Random random = new Random();

        public LinearShooting(Grid grid, IEnumerable<Square> squaresHit)
        {
            MyGrid = grid;
            squaresHit = new List<Square>(squaresHit.OrderBy(square => square.Row + square.Column));
        }

        public Square NextTarget()
        {

            Orientation orientation = GetHitSquaresOrientation();
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();

            if (orientation == Orientation.Horizontal)
            {
                squares.Add(MyGrid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Leftwards));
                squares.Add(MyGrid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Rightwards));
            }
            else
            {
                squares.Add(MyGrid.GetAvailablePlacementsInDirection(squaresHit[0], Direction.Upwards));
                squares.Add(MyGrid.GetAvailablePlacementsInDirection(squaresHit[1], Direction.Downwards));
            }

            // get from MyGrid available squares in continuation (u slijedu?????)
            // find squares in continuation of squares hit
            // select one of them optinally using random number generator
            throw new NotImplementedException();
        }

        public Orientation GetHitSquaresOrientation()
        {
            if(squaresHit[0].Row == squaresHit[1].Row)            
                return Orientation.Horizontal;            
            return Orientation.Vertical;
        }

     }
}
