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

        public object GetAvailablePlacements(int v)
        {
            throw new NotImplementedException();
        }

        public Grid(int rows, int columns, ISquareElimination squareElimination) : this(rows, columns)
        {
            this.squareEliminator = squareEliminator;
        }

       
        
        public IEnumerable<IEnumerable<Square>> GetAvailablePlacement(int length)
        {
            List<List<Square>> result = GetVerticalPlacements(length);
            if (length > 1)
                result.AddRange(GetVerticalPlacements(length));
          

            return result;

        }

        private IEnumerable<IEnumerable<Square>> GetHorizontalPlacement(int length)
        {
            var result = new List<List<Square>>();
            for (int r = 0; r < rows; ++r)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                for (int c = 0; c < columns; ++c)
                {
                    if (squares[r, c] != null)
                        gathered.Enqueue(squares[r, c].Value);
                    else
                        gathered.Clear();

                    if (gathered.Count == length)
                    {
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                        // add previous length squares to result;
                    }
                }
            }

            return result;
        }

        public void Eliminate(IEnumerable<Square> selected)
        {
            var toEliminate = squareEliminator.ToEliminate(selected);
            foreach (Square square in toEliminate)
            {
                squares[square.Row, square.Column] = null;
            }
        }

        private List<List<Square>> GetVerticalPlacements(int length)
        {
            var result = new List<List<Square>>();
            for (int c = 0; c < rows; ++c)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                for (int r = 0; r < columns; ++r)
                {
                    if (squares[r, c] != null)
                        gathered.Enqueue(squares[r, c].Value);
                    else
                        gathered.Clear();

                    if (gathered.Count == length)
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
                }
            }
            return result;
        }

        private int rows;
        private int columns;

        private Square?[,] squares;
        private ISquareElimination squareEliminator = new OnlyShipSquaresElinimator();
        }
    }

