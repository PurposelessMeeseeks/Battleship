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
            this.rows    = rows;
            this.columns = columns;

            squares = new Square?[rows, columns];

            for(int r = 0;  r < rows; ++r)
            {
                for (int c = 0; c < columns; ++c)
                {
                    squares[r,c] = new Square(r, c);
                }
            }
        }


        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            var result = new List<List<Square>>();
            
            
            return result;
        }

        private int rows;
        private int columns;

        private Square?[,] squares;
    }
}
