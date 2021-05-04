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
            List<Square> result = new List<Square>();
            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < columns; c++)
                {
                    foreach (var s in shipSquares)
                    {
                        if(r <= s.Row+1 && r>= s.Row-1 && c<=s.Column+1 && c>=s.Column-1 && !result.Contains(new Square(r, c)))
                        {
                            result.Add(new Square(r, c));
                        }
                    }
                }
            }
            return result;
        }

        private readonly int rows;
        private readonly int columns;
    }
}
