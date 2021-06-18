using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingSquaresEliminator : ISquareEliminator
    {
        private readonly int rows, columns;

        public SurroundingSquaresEliminator(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> shipSquares)
        {
            int left = shipSquares.First().column;
            int right = shipSquares.Last().column + 1;

            int top = shipSquares.First().row;
            int bottom = shipSquares.Last().row + 1;

            if (left > 0)
            {
                --left;
            }

            if (right < columns)
            {
                ++right;
            }

            if (top > 0)
            {
                --top;
            }

            if (bottom < rows)
            {
                ++bottom;
            }

            List<Square> elim = new List<Square>();

            for (int i = top; i < bottom; i++)
            {
                for (int j = left; j < right; j++)
                {
                    elim.Add(new Square(i, j));
                }
            }
            return elim;
        }
    }
}