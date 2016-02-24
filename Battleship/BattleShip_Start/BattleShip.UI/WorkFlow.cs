﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int convertX(string playerInput)//Work with get coord
        {
            char xCoordinateChar = playerInput[0];
            int ascii = xCoordinateChar;
            ascii -= 64;
            return ascii;
        }

        public bool coordinateCheck(int xInt, bool yParse)//Work With get coord
        {
            if ((xInt < 0 || xInt > 10) || !yParse) //y might need to be changed
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
                return ShipDirection.Down;
            }
                
            return ShipDirection.Up;
        }

        public void placeShips(Player user)
        {
            foreach(ShipType s in Enum.GetValues(typeof(ShipType)))
            {
                Console.WriteLine("{0}, pick where you want to place your {1}?", user.playerName, s);
                PlaceShipRequest request = new PlaceShipRequest
                {
                    Coordinate = GetCoordinate(),
                    Direction = GetShipDirection(),
                    ShipType = s
                };
                coordinateShipSpotChecker(request, user);
                //Console.WriteLine("{0},{1}", request.Coordinate.XCoordinate, request.Coordinate.YCoordinate);
                user.playerBoard.PlaceShip(request);
                //Console.WriteLine(user.playerBoard.PlaceShip(request));
            }
        }

        public void coordinateShipSpotChecker(PlaceShipRequest request, Player user)
        {
            if (user.playerBoard.PlaceShip(request) == ShipPlacement.Overlap)
            {
                Console.WriteLine("{0}, You've overlapped your ships, Please start over.", user.playerName);
                placeShips(user);
            }

           /****** MIGHT NOT NEED THIS***** COORDINATE CHECK 
           else if (user.playerBoard.PlaceShip(request) == ShipPlacement.NotEnoughSpace)
            {
                Console.WriteLine("{0}, Your ships don't have enough space! Please start over.", user.playerName);
                placeShip(user);
            }*/

        }

        public bool playerTurn(Player shooter, Player defender)
        {
            Console.WriteLine("{0}, get ready to shoot!", shooter.playerName);
            Coordinate c = GetCoordinate();
            var result=defender.playerBoard.FireShot(c);
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
            return false;
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