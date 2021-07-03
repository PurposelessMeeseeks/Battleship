using Vsite.Oom.Battleship.Model;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Battleships
{
    public class PCPlayer : Player
    {
        public event EventHandler InvokeHumanPlayerTurn;

        public PCPlayer(FleetControl guiFleet, Fleet fleet)
        {
            GuiFleet = guiFleet;
            Fleet = fleet;
            Gunnery = new Gunnery(10, 10, new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
        }

        protected override bool TurnLogic()
        {
            var target = Gunnery.NextTarget();
            var hitResult = Fleet.Hit(target);
            Gunnery.RecordShootingResult(hitResult);

            if (hitResult == HitResult.Missed)
            {
                GuiFleet.Miss(target);
            }

            if (hitResult == HitResult.Hit)
            {
                GuiFleet.Hit(target);
            }

            if (hitResult == HitResult.Sunken)
            {
                foreach (var ships in Fleet.Ships)
                {
                    int index = Array.FindIndex(ships.Squares.ToArray(), item => item.Equals(target));
                    if (index != -1)
                    {
                        GuiFleet.Hit(target);
                        GuiFleet.SunkShip(ships.Squares);
                        break;
                    }
                }
            }                          

            InvokeHumanPlayerTurn(this, EventArgs.Empty);
            return true;
        }

        private FleetControl GuiFleet;
        private Fleet Fleet;
        Gunnery Gunnery;
    }
}
