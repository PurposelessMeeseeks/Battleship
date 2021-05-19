using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ITargetSelect
    {
        private Grid MyGrid;
        private Square FirstHit;
        private int ShipLength;
        private Random random;

        public SurroundingShooting(Grid grid, Square firstHit, int shipLength)
        {
            MyGrid = grid;
            FirstHit = firstHit;
            ShipLength = shipLength;
        }

        public Square NextTarget()
        {
            List<IEnumerable<Square>> squares = new List<IEnumerable<Square>>();
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Upwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Downwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Leftwards));
            squares.Add(MyGrid.GetAvailablePlacementsInDirection(FirstHit, Direction.Rightwards));

            var sorted = squares.OrderByDescending(item => item.Count());
            int maxLength = sorted.ElementAt(0).Count();
            if (maxLength > ShipLength - 1) 
            {
                maxLength = ShipLength - 1;
            }
            var longest = sorted.Where(item => item.Count() >= maxLength);

            if (longest.Count() == 1)
            {
                return longest.ElementAt(0).First();
            }

            int index = random.Next(longest.Count());

            return longest.ElementAt(index).First();
            

            // get from MyGrid available surrounding squares
            // select one of them as target
            throw new NotImplementedException();
        }
    }
}
