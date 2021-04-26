using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {

        public Grid(int rows, int columns) {
            Rows = rows;
            Columns = columns;

            squares = new Square?[rows, columns];

            for (int r = 0; r < rows; ++r) {
                for (int c = 0; c < columns; ++c) {
                    squares[r, c] = new Square(r, c);
                }
            }
        }
        public IEnumerable<IEnumerable<Square>> GetSequences(int length)
        {

            var result = GetHorizontalSequences(length);

            return result;

        }

        public void RemoveSquares(IEnumerable<Square> squaresToEliminate)
        {
            foreach (Square square in squaresToEliminate) { 
                squares[square.Row,square.Column] = null;
            }
        }

        private List<IEnumerable<Square>> GetHorizontalSequences(int length) {

            List<IEnumerable<Square>> result = new List<IEnumerable<Square>>();
            for (int r = 0; r < Rows; ++r) {

                var queue = new LimitedQueue<Square>(length);
                for (int c = 0; c < Columns; ++c) {

                    if (squares[r, c] != null) {

                        queue.Enqueue(squares[r, c].Value);
                        if (queue.Count >= length)
                        {

                            result.Add(queue.ToArray());
                          
                        }
                        
                    }
                    else
                    {
                        queue.Clear();
                    }

                }

            
            }

            return result;

        }



        private readonly Square?[,] squares;

        public readonly int Rows;
        public readonly int Columns;
    }
}
