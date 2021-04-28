using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingSquaresEliminator : ISquareEliminator
    {
        public SurroundingSquaresEliminator(int rows, int colums)
        {
            this.rows = rows;
            this.columns = columns;
        }

        private readonly int rows;
        private readonly int columns;

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            int minRow = Math.Max(shipSquares.Min(s => s.Row) - 1, 0);
            int maxRow = Math.Max(shipSquares.Max(s => s.Row) + 1, rows - 1);
            int minColumn = Math.Max(shipSquares.Min(s => s.Column) - 1, 0);
            int maxColumn = Math.Min(shipSquares.Max(s => s.Column) + 1, columns - 1);
            List<Square> squares = new List<Square>();
            for (int r = minRow; r <= maxRow; ++r)
            {
                for (int c = minColumn; c <= maxColumn; ++c)
                    squares.Add(new Square(r, c)); 
            }
            return squares;
        }
    }
}
