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
            this.rows = rows;
            this.columns = columns;

            squares = new Square?[rows, columns];
            for (int r = 0; r < rows; ++r)
            {
                for (int c = 0; c < columns; ++c)
                    squares[r, c] = new Square(r, c);
            }

        }

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int lenght)
        {
            List<List<Square>> result = GetHorizontalPlacements(lenght);
            //result.Add()
            return result;
        }

        private List<List<Square>> GetHorizontalPlacements(int lenght)
        {
            var result = new List<List<Square>>();
            for (int r = 0; r < rows; ++r)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(lenght);
                for (int c = 0; c < columns; ++c)
                {
                    if (squares[r, c] != null)
                        gathered.Enqueue(squares[r, c].Value);
                    else
                        gathered.Clear();

                    if (gathered.Count == lenght)
                    {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                        //add previous lenght squares to result;
                    }
                }
            }
            
            
            return result;
        }

        internal void Eliminate(IEnumerable<Square> selected)
        {
            throw new NotImplementedException();
        }

        private int rows;
        private int columns;

        private Square?[,] squares;
    }
}
