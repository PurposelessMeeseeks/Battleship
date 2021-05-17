using System;
using System.Collections.Generic;

namespace Vsite.Oom.Battleship.Model {
    public class SurroundingShooting : ITargetSelect {
        public SurroundingShooting(Grid grid, Square FirstHit) {
        }

        public SurroundingShooting(Grid evidenceGrid, List<int> shipsToShoot) {
        }

        public Square NextTarget() {
            throw new NotImplementedException();
        }
    }
}