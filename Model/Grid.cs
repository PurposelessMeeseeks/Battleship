using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public class Grid
    {
        private int rows;
        private int colums;

        private Square?[,] squares;
        private ISquareEliminator squareEliminator = new OnlyShipSquaresEliminator();


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

        public Grid(int rows, int columns, ISquareEliminator squareEliminator) : this(rows, columns)
        {
            this.squareEliminator = squareEliminator;
        }

        public IEnumerable<IEnumerable<Square>> GetAvailablePlacements(int length)
        {
            List<List<Square>> result = GetHorizontalPlacements(length);
            if (length > 1)
                result.AddRange(GetVerticalPlacements(length));
            return result;

            List<List<Square>> result_2 = GetVerticalPlacements(length);

            for (int i = 0; i < result_2.Count; ++i)
            {
                result.Add(result_2[i]);
            }

            return result;
        }

        public void Eliminate(IEnumerable<Square> selected)
        {
            var ToEliminate = squareEliminator.ToEliminate(selected);

            foreach (Square square in ToEliminate) 
            {
                squares[square.row, square.column] = null; ;
            }
        }

        private List<List<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<List<Square>>();

            for (int r = 0; r < rows; ++r) 
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                
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

                    if (gathered.Count == length)  
                    {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                    }
                }
            }

            return result;
        }

        private List<List<Square>> GetVerticalPlacements(int length)
        {
            var result = new List<List<Square>>();

            for (int c = 0; c < colums; ++c)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);

                for (int r = 0; r < rows; ++r)
                {
                    if (squares[r, c] != null)
                    {
                        gathered.Enqueue(squares[r, c].Value);

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
    }
}
