using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        Grid MyGrid;
        Square FirstHit;
        Random random = new Random();

        public SurroundingShooting(Grid grid, Square firstHit)
        {
            MyGrid = grid;
            FirstHit = firstHit;
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Upwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Downwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Leftwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Rightwards));

            // get from MyGrid available surrounding squares
            // select one of them as target
            throw new NotImplementedException();
        }
    }
}
