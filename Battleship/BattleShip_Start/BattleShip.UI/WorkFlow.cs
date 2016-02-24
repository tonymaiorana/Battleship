using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        public Player PopulatePlayer(Player p, int i)
        {
            bool validInput = false;
            string nameEntry = i.ToString();
            do
            {
                Console.Write("Player {0}, Please Enter Your Name: ",i);
                nameEntry = Console.ReadLine();
                if (nameEntry == "")
                {
                    Console.WriteLine("Please enter your name to start!");
                }
                else
                {
                    validInput = true;
                }
            } while (!validInput);
            p.playerName=nameEntry;
            return p;
        }

        public Coordinate GetCoordinate()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Please enter coordinates: ");
                string playerInput = Console.ReadLine();
                int xInt = convertX(playerInput);
                string yString = playerInput.Substring(1);
                int yInt;
                bool yParse = int.TryParse(yString, out yInt);
                if (coordinateCheck(xInt, yParse))
                {
                    return new Coordinate(xInt, yInt);
                }
                Console.WriteLine("Please enter valid coordinates! (eg. E9)");
            }
            return new Coordinate(11,11);
        }

        public int convertX(string playerInput)
        {
            char xCoordinateChar = playerInput[0];
            int ascii = xCoordinateChar;
            ascii -= 64;
            return ascii;
        }

        public bool coordinateCheck(int xInt, bool yParse)
        {
            if ((xInt < 0 || xInt > 10) || !yParse)
            {
                return false;
            }
            return true;
        }

        public ShipDirection GetShipDirection()
        {
            Console.WriteLine("What direction would you like the ship to be facing?");
            string directionString = Console.ReadLine();
            if (directionString == ShipDirection.Down.ToString())
            {
                Console.WriteLine("True");
                return ShipDirection.Down;
            }
                
            return ShipDirection.Up;
        }

        public void placeShip(Player user)
        {
            PlaceShipRequest playeRequest = new PlaceShipRequest();
            PlaceShipRequest request = new PlaceShipRequest()
            {
                Coordinate = GetCoordinate(),
                Direction = GetShipDirection(),
                ShipType = ShipType.Carrier
            };
            user.playerBoard.PlaceShip(request);
        }


        /*public int coordinateConverter(string location)
        {
            char xCoordinateChar = location[0];
            int ascii = xCoordinateChar;
            ascii -= 64;
            return ascii;
        }

        public bool spotValidation(int xCord, int yCord)
        {
            return true;
        }

        public */
    }
}