using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {
        private readonly int Rows;
        private readonly int Columns;

        private Square?[,] squares;

        public Grid(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;

            squares = new Square?[rows, columns];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < columns; ++c)
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }


        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            List<List<Square>> result = GetHorizontalPlacements(length);
            // add vertical placements
            return result;
        }

        public List<List<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<List<Square>>();
            for (int r = 0; r < Rows; ++r)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);

                for (int c = 0; c < Columns; ++c)
                {
                    if (squares[r, c] == null)
                        gathered.Enqueue(squares[r, c].Value);
                    else
                        gathered.Clear();                    
                    if (gathered.Count == length) {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                        //add previous length squares to result
                    }
                }
            }

            return result;
        }

    }
}
