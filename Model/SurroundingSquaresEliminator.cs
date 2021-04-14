using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingSquaresEliminator : ISquareEliminator
    {
        public SurroundingSquaresEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }
        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            throw new NotImplementedException();
        }

        private readonly int rows;
        private readonly int columns;
    }
}
