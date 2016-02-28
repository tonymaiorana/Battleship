using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;
using BattleShip.BLL.Ships;

namespace BattleShip.UI
{
    public class Display
    {
        public void welcomeScreen()
        {
            AsciiArt.WelcomeScreen();
            Console.ReadLine();
            Console.Clear();
        }

        public static void displayShotBoard(Board playerBoard, Player user)
        {
            Console.WriteLine("\n                  ATTACK BOARD                      \n");
            Console.WriteLine("        A    B    C    D    E    F    G    H    I    J\n");

            for (int col = 1; col <= 10; col++)
            {
                if (col < 10)
                {
                    Console.Write("| {0}  |", col);
                }
                else
                {
                    Console.Write("| {0} |", col);
                }

                for (int row = 1; row <= 10; row ++)
                {
                    if (playerBoard.ShotHistory.ContainsKey(new Coordinate(row, col)))
                    {
                        ShotHistory sh = playerBoard.ShotHistory[new Coordinate(row, col)];
                        if (sh == ShotHistory.Hit)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkRed;
                            Console.Write("| H |");
                        }
                        else if (sh == ShotHistory.Miss)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkYellow;
                            Console.Write("| M |");
                        }
                        else
                        {
                            Console.Write("| ^ |");
                        }
                    }
                    else
                    {   
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("| * |");
                    }

                }
                Console.WriteLine();
                Console.BackgroundColor = ConsoleColor.Black;
            }
            Console.WriteLine();
        }

        public static void ShipBoard(Board playerBoard, int shipsPlaced)
        {
            Dictionary<Coordinate,ShipType> shipDictionary = new Dictionary<Coordinate,ShipType>();

            for (int i = 0; i < shipsPlaced; i++)
            {
                foreach (Coordinate c in playerBoard._ships[i].BoardPositions)
                {
                    shipDictionary.Add(c, playerBoard._ships[i].ShipType);
                }
            }


            Console.WriteLine("\n                    SHIP PLACEMENT                      \n");
            Console.WriteLine("      A    B    C    D    E    F    G    H    I    J\n");
            for (int col = 1; col <= 10; col++)
            {
                if (col < 10)
                {
                    Console.Write(" {0}  ", col);
                }
                else
                {
                    Console.Write(" {0} ", col);
                }

                for (int row = 1; row <= 10; row++)
                {
                    if (shipDictionary.ContainsKey(new Coordinate(row, col)))
                    {
                        ShipType ship = shipDictionary[new Coordinate(row,col)];
                        if (ship == ShipType.Destroyer)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("| D |");
                        }
                        else if (ship == ShipType.Submarine)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("| S |");
                        }
                        else if (ship == ShipType.Cruiser)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("| R |");
                        }
                        else if (ship == ShipType.Battleship)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("| B |");
                        }
                        else if (ship == ShipType.Carrier)
                        {
                            Console.BackgroundColor = ConsoleColor.DarkGreen;
                            Console.Write("| C |");
                        }
                        else
                        {
                            Console.Write("| ^ |");
                        }
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.Write("| * |");
                    }
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                Console.WriteLine();
            }

        }

        public static void VictoryMessage(Player user)
        {
            
            Console.Write("YOU WIN, Admiral {0}!", user.playerName);
            Console.ReadLine();
            Console.Clear();
            AsciiArt.VictoryScreen();
            Console.ReadLine();
        }
    }
}
