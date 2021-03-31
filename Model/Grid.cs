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
            return new List<List<Square>>();
            
        }

        public Square?[,] squares;


    }
}
