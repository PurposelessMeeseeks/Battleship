﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Vsite.Oom.Battleship.Model
{
    public enum Direction
    {
        Upwords,
        Rightwords,
        Downwords,
        Leftwords
    }

    public class Grid
    {
        private readonly int rows;
        private readonly int colums;

        private readonly Square?[,] squares;
        private readonly ISquareEliminator squareEliminator = new OnlyShipSquaresEliminator();

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

        public void RecordResult(Square square, HitResult result)
        {
            squares[square.row, square.column].Value.SetSquareState(result);
        }

        internal IEnumerable<Square> GetAvailablePlacementsInDirection(Square square)
        {
            throw new NotImplementedException();
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

        public IEnumerable<Square> GetAvailablePlacementsInDirection(Square from, Direction direction)
        {
            int deltaRow = 0;
            int deltaColumn = 0;
            int count = 0;
            switch (direction)
            {
                case Direction.Upwords:
                    deltaRow = -1;
                    count = from.row;
                    break;

                case Direction.Rightwords:
                    deltaColumn = +1;
                    count = colums - from.column;
                    break;

                case Direction.Downwords:
                    deltaRow = +1;
                    count = rows - from.row;
                    break;

                case Direction.Leftwords:
                    deltaColumn = -1;
                    count = from.column;
                    break;
            }

            List<Square> result = new List<Square>();
            int row = from.row + deltaRow;
            int column = from.column + deltaColumn;
            for (int i = 1; i < count; ++i)
            {
                if (squares[row, column].Value.SquareState != SquareState.Default)
                    break;
                result.Add(squares[row, column].Value);
                row += deltaRow;
                column += deltaColumn;
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
                    if (squares[r, c] != null && squares[r, c].Value.SquareState == SquareState.Default)
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
                    if (squares[r, c] != null && squares[r, c].Value.SquareState == SquareState.Default)
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