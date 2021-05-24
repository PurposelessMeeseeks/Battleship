using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vsite.Oom.Battleship.Model
{
    public enum ShootingTactics
    {
        Random,
        Surrounding,
        Linear
    }

    public class Gunnery
    {
        public Gunnery(int rows, int columns, IEnumerable<int> shipLengths)
        {
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToSink = new List<int>(sorted);
            evidenceGrid = new Grid(rows, columns);
            selectTarget = new RandomShooting(evidenceGrid, shipsToSink[0]);
        }

        public Square NextTarget()
        {
            lastTarget = selectTarget.NextTarget();
            return lastTarget;
        }

        public void ProcessShootingResult(HitResult result)
        {
            // Mark the result in evidence grid
            switch (result)
            {
                case HitResult.Missed:
                    evidenceGrid.MarkSquare(lastTarget, SquareState.Missed);
                    break;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    break;
                case HitResult.Sunken:
                    squaresHit.Add(lastTarget);
                    var eliminator = new SurroundingSquareEliminator(evidenceGrid.Rows, evidenceGrid.Columns);
                    var surroundingSquares = eliminator.ToEliminate(squaresHit);
                    foreach (var square in surroundingSquares)
                        evidenceGrid.MarkSquare(square, SquareState.Missed);
                    foreach (var square in squaresHit)
                        evidenceGrid.MarkSquare(square, SquareState.Sunken);
                    squaresHit.Clear();
                    break;
            }
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            switch (result)
            {
                case HitResult.Missed:
                    return;
                case HitResult.Hit:
                    if (currentTactics == ShootingTactics.Random)
                    {
                        selectTarget = new SurroundingShooting(evidenceGrid, squaresHit[0], shipsToSink[0]);
                        currentTactics = ShootingTactics.Surrounding;
                        return;
                    }
                    if (currentTactics == ShootingTactics.Surrounding)
                    {
                        selectTarget = new LinearShooting(evidenceGrid, squaresHit, shipsToSink[0]);
                        currentTactics = ShootingTactics.Linear;
                        return;
                    }
                    break;
                case HitResult.Sunken:
                    selectTarget = new RandomShooting(evidenceGrid, shipsToSink[0]);
                    currentTactics = ShootingTactics.Random;
                    break;
            }
        }

        public ShootingTactics CurrentTactics
        {
            get { return currentTactics; }
        }

        private Grid evidenceGrid;
        private List<int> shipsToSink;
        private ISelectTarget selectTarget;
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;
    }
}
