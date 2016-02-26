using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class WorkFlow
    {
        public Player PopulatePlayer(Player p, int i)
        {
            bool validInput = false;
            string nameEntry;
            do
            {
                Console.Write("Admiral {0}, Please Enter Your Name: ", i);
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
            p.playerName = nameEntry;
            return p;
        }

        public Coordinate GetCoordinate()
        {
            bool validInput = false;
            while (!validInput)
            {
                Console.Write("Please enter coordinates: ");
                string playerInput = Console.ReadLine().ToUpper();
                if (playerInput != "")
                {
                    int xInt = convertX(playerInput);
                    string yString = playerInput.Substring(1);
                    int yInt;
                    bool yParse = int.TryParse(yString, out yInt);

                    if (coordinateCheck(xInt, yInt, yParse))
                    {
                        return new Coordinate(xInt, yInt);
                    }

                }
                Console.WriteLine("Please enter valid coordinates! (eg. E9)");
            }
            return new Coordinate(11, 11);
        }

        public int convertX(string playerInput) //Work with get coord
        {
            char xCoordinateChar = playerInput[0];
            int ascii = xCoordinateChar;
            ascii -= 64;
            return ascii;
        }

        public bool coordinateCheck(int xInt, int yInt, bool yParse) //Work With get coord
        {
            if (xInt <= 0 || xInt > 10 || !yParse || yInt > 10 || yInt <= 0) //y might need to be changed
            {
                return false;
            }
            return true;
        }

        public ShipDirection GetShipDirection(Player user)
        {
            Console.WriteLine(
                "Admiral {0}, What direction would you like the ship to be facing? use (up, down, left or right)",
                user.playerName);
            string directionString = Console.ReadLine().ToUpper();
            switch (directionString)
            {
                case "DOWN":
                    return ShipDirection.Down;
                case "UP":
                    return ShipDirection.Up;
                case "LEFT":
                    return ShipDirection.Left;
                case "RIGHT":
                    return ShipDirection.Right;
                default:
                    return GetShipDirection(user);
            }
        }

        public void placeShips(Player user)
        {
            ShipType[] shipTypeArray =
            {
                ShipType.Destroyer, ShipType.Submarine, ShipType.Cruiser, ShipType.Battleship,
                ShipType.Carrier,
            };
            int index = 0;
            user.playerBoard= new Board();

            /*foreach (ShipType s in Enum.GetValues(typeof (ShipType)))
            {*/
            for (int i = 0; i<5; i++)
            {
                //display.shipBoard();
                Console.WriteLine("Admiral {0}, pick where you want to place your {1}?", user.playerName, shipTypeArray[i]);
                Coordinate shipCoordinate = GetCoordinate();
                ShipDirection shipDirection = GetShipDirection(user);
                PlaceShipRequest request = new PlaceShipRequest
                {
                    Coordinate = shipCoordinate,
                    Direction = shipDirection,
                    ShipType = shipTypeArray[i]
                };
                i= coordinateShipSpotChecker(request, user, i);
                //Display.ShipBoard(user.playerBoard, index);
                index++;
            }
            //}
        }

        public int coordinateShipSpotChecker(PlaceShipRequest request, Player user, int i)
        {
            Board tempBoard=user.playerBoard;
            ShipPlacement s = tempBoard.PlaceShip(request);
            if (s == ShipPlacement.Overlap)
            {
                Console.WriteLine("{0}, You've overlapped your ships, Please start over.", user.playerName);
                return i - 1;
            }
            if (s == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("{0}, Your ships don't have enough space! Please start over.", user.playerName);
                return i - 1;
            }
            return i;
        }

        public bool playerTurn(Player shooter, Player defender)
        {
            Console.WriteLine("{0}, get ready to shoot!", shooter.playerName);
            Coordinate c = GetCoordinate();
            var result = defender.playerBoard.FireShot(c);
            if (result.ShotStatus == ShotStatus.Duplicate || result.ShotStatus == ShotStatus.Invalid)
            {
                Console.WriteLine("Coordinates aren't on board or you already fired here!");
            }
            else if (result.ShotStatus == ShotStatus.Miss)
            {
                Console.WriteLine("You missed");
            }
            else if (result.ShotStatus == ShotStatus.Hit)
            {
                Console.WriteLine("You hit");
            }
            else if (result.ShotStatus == ShotStatus.HitAndSunk)
            {
                Console.WriteLine("Sunk");
            }
            else if (result.ShotStatus == ShotStatus.Victory)
            {
                //Ask Victor why is static needed?
                Display.VictoryMessage(shooter);
                return true;
            }
            return false;
        }
    }
}