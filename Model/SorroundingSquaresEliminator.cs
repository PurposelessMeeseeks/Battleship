using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class SurroundingSquareEliminator : ISquareEliminator
    {
        public SurroundingSquareEliminator(int rows, int columns)
        {
            this.rows    = rows;
            this.columns = columns;
        }

        public IEnumerable<Square> ToEliminate(IEnumerable<Square> squares)
        {
            var mostLeftShip  = squares.First();
            var mostRightShip = squares.Last();

            // get the sorrounding squares dimension on the most left ship
            int left = mostLeftShip.Column > 0 ? mostLeftShip.Column - 1 : mostLeftShip.Column;
            int top = mostLeftShip.Row > 0 ? mostLeftShip.Row - 1 : mostLeftShip.Row;

            // get the sorrounding squares dimension on the most right ship
            int right = mostRightShip.Column + 1;
            right = (right < columns) ? ++right : right;

            int bottom = mostRightShip.Row + 1;
            bottom = (bottom < rows) ? ++bottom : bottom;

            var toEliminate = new List<Square>();

            for (int r = top; r < bottom; ++r)
            {
                for (int c = left; c <right; ++c)
                {
                    toEliminate.Add(new Square(r, c));
                }
            }

            return toEliminate;
        }

        private readonly int rows;
        private readonly int columns;
    }
}
