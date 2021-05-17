using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingShooting : ISelectTarget
    {
        public SurroundingShooting(Grid grid,Square initiallyHit,int shipLength)
        {
            this.grid = grid;
            this.initiallyHit = initiallyHit;
            this.shipLength = shipLength;
        }
        public Square NextTarget()
        {
            List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();
            var squares = grid.GetSequence(initiallyHit, Direction.Up);
            if (squares.Count() > 0)
                result.Add(squares);

            squares = grid.GetSequence(initiallyHit, Direction.Right);
            if (squares.Count() > 0)
                result.Add(squares);

            squares = grid.GetSequence(initiallyHit, Direction.Down);
            if (squares.Count() > 0)
                result.Add(squares);

            squares = grid.GetSequence(initiallyHit, Direction.Left);
            if (squares.Count() > 0)
                result.Add(squares);

            //from list 'squares' select only those which are longer than shipLength - 1 
            //from remaining randomly select one
            //from selected list take first square

            throw new NotImplementedException();
        }

        private Grid grid;
        private Square initiallyHit;
        private int shipLength;
        private Random random = new Random();
    }
}
