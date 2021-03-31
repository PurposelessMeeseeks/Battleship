using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {
        public Grid(int rows, int columns)
        {
            this.Rows = rows;
            this.Columns = columns;

            Squares = new Square?[rows, columns];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < columns; ++c)
                {
                    Squares[r, c] = new Square(r, c);
                }
            }
        }

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            List<List<Square>> result = GetHorizontalPlacements(length);
            // add GetVerticalPlacements(length)

            return result;
        }

        private List<List<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<List<Square>>();

            for (int r = 0; r < Rows; ++r)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                for (int c = 0; c < Columns; ++c)
                {
                    if (Squares[r, c] != null)
                    {
                        gathered.Enqueue(Squares[r, c].Value);
                    }
                    else
                    {
                        gathered.Clear();
                    }

                    if (gathered.Count == length)
                    {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                    }
                }
            }

            return result;
        }

        private int Rows;
        private int Columns;
        private Square?[,] Squares;
    }
}
