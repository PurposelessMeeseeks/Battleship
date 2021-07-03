using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Vsite.Oom.Battleship.Model;

namespace Battleships
{
    class PlayerManager
    {
        public PlayerManager(FleetControl PCFleetControl, FleetControl HumanFleetControl)
        {
            Shipwright shipwright = new Shipwright(10, 10, new List<int> { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 });
            PCFleet = shipwright.CreateFleet();
            PlayerFleet = shipwright.CreateFleet();
            PlayerFleetControl = HumanFleetControl;
            this.PCFleetControl = PCFleetControl;

            HumanPlayerNotificationQueue = new BlockingQueue<ShipButton>(10);
            HumanPlayer = new HumanPlayerImpl(PCFleetControl, PCFleet, HumanPlayerNotificationQueue);
            PCPlayer = new PCPlayer(PlayerFleetControl, PlayerFleet);

            HumanPlayer.InvokePCPlayerTurn += 
                new EventHandler(delegate (object o, EventArgs e)
                {
                    PCPlayer.Play();
                });

            PCPlayer.InvokeHumanPlayerTurn +=
                new EventHandler(delegate (object o, EventArgs e)
                {
                    HumanPlayer.Play();
                });

            PCFleetControl.PlaceShips(PCFleet);
            PlayerFleetControl.PlaceShips(PlayerFleet);

            HumanPlayer.Play();
        }

        public void EnqueuePlayerNotification(ShipButton shipButton)
        {
            HumanPlayerNotificationQueue.Enqueue(shipButton);
        }

        private BlockingQueue<ShipButton> HumanPlayerNotificationQueue;

        private HumanPlayerImpl HumanPlayer;
        private PCPlayer PCPlayer;

        private Fleet PCFleet;
        private Fleet PlayerFleet;
        private FleetControl PCFleetControl;
        private FleetControl PlayerFleetControl;
    }
}
