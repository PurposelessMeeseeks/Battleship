using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vsite.Oom.Battleship.Model;

namespace Boards
{
    class game
    {

        enum CurrentPlayer
        { 
            Computer,
            Player
        }

        const int rows = 10;
        const int columns = 10;
        readonly IEnumerable<int> shipLengths = new List<int>() {
            5,4,4,3,3,3,2,2,2,2
        };
        Gunnery gunnery;

        readonly Fleet fleet;

        Grid recordGrid = new Grid(rows, columns);
        CurrentPlayer currentPlayer;
        bool gameisOver {
            get {return fleet.isSunken(); 

                //Include check for our fleet
            
            
            }

            
        }

        


        public game()
        {
            Shipwright shipwright = new Shipwright(rows, columns, shipLengths);
            fleet = shipwright.CreateFleet();
            gunnery = new Gunnery(rows,columns,shipLengths);
        }

        public void playGame()
        {
            currentPlayer =  initialPlayer();


          
            


        }

        private CurrentPlayer initialPlayer()
        {
            Random rnd = new Random();
            int num = rnd.Next(0, 2);

            return (CurrentPlayer)num;

        }


    }
}
