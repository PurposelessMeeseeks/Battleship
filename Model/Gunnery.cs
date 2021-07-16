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
        public Gunnery (int rows,int columns,IEnumerable<int> shipLengths)
        {
            var sorted = shipLengths.OrderByDescending(s => s);
            shipsToSink = new List<int>(sorted);
            evidanceGrid = new Grid(rows, columns);
            selectTarget = new RandomShooting(evidanceGrid, shipsToSink[0]);
        }

        public Square NextTarget()
        {
            lastTarget = selectTarget.NextTarget();
            return lastTarget;
        }

        public void ProcessShootingResult(HitResult result)
        {
       
            switch (result)
            {
                case HitResult.Missed:
                    evidanceGrid.MarkSquare(lastTarget, SquareState.Missed);
                    break;
                case HitResult.Hit:
                    squaresHit.Add(lastTarget);
                    break;
                case HitResult.Sunken:
                    var elimintor = new SurroundingSquareEliminator(evidanceGrid.Rows, evidanceGrid.Columns);
                    var surroundingSquares = elimintor.ToEliminate(squaresHit);
                    foreach (var square in surroundingSquares)
                        evidanceGrid.MarkSquare(square, SquareState.Missed);
                    foreach (var square in squaresHit)
                        evidanceGrid.MarkSquare(square, SquareState.Missed);
                    squaresHit.Clear();
                    break;
            }
            ChangeTactics(result);
        }

        private void ChangeTactics(HitResult result)
        {
            //if result is Missed, don't change the tactics
            //if result is Hit:
            //     - if current tactic is random, change it to  Surrounding 
            //     - if current tactic is Surrounding, change it to Lienar
            //     - else keep it Linear
            //  if result is Sunken, change to Random

            if (result == HitResult.Missed) 
            {
                return;
            }
            else if (result == HitResult.Hit) 
            {
                if (currentTactics == ShootingTactics.Random)
                {
                    selectTarget = new SurroundingShooting(evidanceGrid, squaresHit[0],shipsToSink[0]);
                    currentTactics = ShootingTactics.Surrounding;
                    
                }
                else if (currentTactics == ShootingTactics.Surrounding) 
                {
                    selectTarget = new LinearShooting(evidanceGrid, squaresHit, shipsToSink[0]);
                    currentTactics = ShootingTactics.Linear;
                    
                }
               else 
                {
                    currentTactics = ShootingTactics.Linear;
                  
                }
            }
            else if (result == HitResult.Sunken)
            {
                selectTarget = new RandomShooting(evidanceGrid, shipsToSink[0]);
                currentTactics = ShootingTactics.Random;

            }

        }

        public ShootingTactics CurrentTactics
        {
            get { return currentTactics; }
        }

        private Grid evidanceGrid;
        private List<int> shipsToSink;
        private ISelectTarget selectTarget;
        private ShootingTactics currentTactics = ShootingTactics.Random;
        private List<Square> squaresHit = new List<Square>();
        private Square lastTarget;
    }
}
