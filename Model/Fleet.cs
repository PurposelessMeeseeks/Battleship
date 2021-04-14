using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Vsite.Oom.Battleship.Model
{
    public class Fleet
    {
        public void CreateShip(IEnumerable<Square> squares)
        {
            Ships ship = new Ships(squares);
            ships.Add(ship);
        }

        public IEnumerable<Ship> Ships
        {
            get { return ships; }
        }

        List<Ship> ships = new List<Ship>();
    }
}