using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
    public class workFlow
    {
        public void pickASpot()
        {
            string shotLocation;
            Console.WriteLine("Pick a location to shoot");
            shotLocation = Console.ReadLine();
        }

        public int coordinateConverter(string location)
        {
            char xCoordinateChar = location[0];
            int ascii = xCoordinateChar;
            ascii -= 64;
            return ascii;


        }
    }
}

