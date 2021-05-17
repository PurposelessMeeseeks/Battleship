using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model {
    public class LinearShooting : ITargetSelect {
        public LinearShooting(Grid grid, IEnumerable<SquareState> SquaresHit) {
        }

        public LinearShooting(Grid evidenceGrid, List<int> shipsToShoot) {
        }

        public Square NextTarget() {
            throw new NotImplementedException();
        }
    }
}