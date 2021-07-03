using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Oom.Battleship.Model;
using System.Threading;

namespace Battleships
{
    public abstract class Player : IPlayer, IRunnable
    {
        public Player()
        {
            ShouldStop = false;
            PlayerState = PlayerState.Idle;
            HittedSquare = new BlockingQueue<ShipButton>(10);
            Thread = new Thread(Run);
            Thread.Start();
        }

        public void Run()
        {
            while (!ShouldStop)
            {
                if (PlayerState != PlayerState.Playing)
                {
                    continue;
                }

                if (TurnLogic() == true) // hit happened
                {
                    // maybe do something
                }

                Wait();
            }
        }

        public void Wait()
        {
            PlayerState = PlayerState.Waiting;
        }

        public void Play()
        {
            PlayerState = PlayerState.Playing;
        }

        public void Stop()
        {
            ShouldStop = true;
            Thread.Abort();
        }

        protected abstract bool TurnLogic();


        private PlayerState PlayerState { get; set; }
        private bool ShouldStop;
        BlockingQueue<ShipButton> HittedSquare;
        Thread Thread;
    }
}
