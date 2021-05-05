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
        }
        public void RecordResult(Square square, HitResult result)
        {
            squares[square.Row, square.Column].Value.SetSquareState(result);
        }
        private List<List<Square>> GetHorizontalPlacements(int length)
        {
            var result = new List<List<Square>>();
            for (int r = 0; r < rows; ++r)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                for (int c = 0; c < columns; ++c)
                {
                    if (squares[r, c] != null && squares[r, c].Value.SquareState == SquareState.Default)
                            gathered.Enqueue(squares[r, c].Value);
                    else
                        gathered.Clear();

                    if (gathered.Count == length)
                        result.Add(new List<Square>(gathered.ToArray<Square>()));
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
            for (int c = 0; c < columns; ++c)
            {
                LimitedQueue<Square> gathered = new LimitedQueue<Square>(length);
                for (int r = 0; r < rows; ++r)
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
        private ISquareEliminator squareEliminator = new OnlyShipSquaresEliminator();
    }
}
