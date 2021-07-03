using System;
using Vsite.Oom.Battleship.Model;

namespace Battleships
{
    public class HumanPlayerImpl : Player
    {
        public event EventHandler InvokePCPlayerTurn;

        public HumanPlayerImpl(FleetControl guiFleet, Fleet fleet, BlockingQueue<ShipButton> queue)
        {
            GuiFleet = guiFleet;
            Fleet = fleet;
            NotificationQueue = queue;
        }

        protected override bool TurnLogic()
        {
            ShipButton button = NotificationQueue.Dequeue();

            var row = button.Row;
            var col = button.Column;

            bool isHitted = false;
            foreach (var ships in Fleet.Ships)
            {
                var hitResult = ships.Hit(new Square(row, col));
                if (hitResult == HitResult.Hit)
                {
                    GuiFleet.Hit(new Square(row, col));
                    isHitted = true;
                    break;
                }

                if (hitResult == HitResult.Sunken)
                {
                    GuiFleet.Hit(new Square(row, col));
                    GuiFleet.SunkShip(ships.Squares);
                    isHitted = true;
                }
            }

            InvokePCPlayerTurn(this, EventArgs.Empty);

            return isHitted;
        }

        private FleetControl GuiFleet;
        private Fleet Fleet;
        private BlockingQueue<ShipButton> NotificationQueue;
    }
}
