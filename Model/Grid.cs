using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {
        public Grid(int rows, int colums)
        {
            this.rows = rows;
            this.colums = colums;

            squares = new Square?[rows, colums];

            for (int r = 0; r < rows; ++r) 
            {
                for (int c = 0; c < colums; ++c) 
                {
                    squares[r, c] = new Square(r, c);
                }
            }
        }

        private int rows;
        private int colums;

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int lenght)
        {
            var result = new List<List<Square>>();
            return result;
        }

        private IEnumerable<IEnumerable<Square>> GetHorizontalPlacements(int lenght)
        {
            var result = GetHorizontalPlacements(lenght);

            for (int r = 0; r < rows; ++r) 
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(lenght);
                

                for (int c = 0; c < colums; ++c) 
                {
                    if (squares[r, c] != null)
                    {
                        gathered.Enqueue(squares[r, c].Value);
                    }
                    else
                    {
                        gathered.Clear();
                    }

                    if (gathered.Count == lenght)  
                    {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                    }
                }
            }

            return result;
        }

        public Square?[,] squares;
    }
}
