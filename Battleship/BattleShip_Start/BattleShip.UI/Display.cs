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
            Console.WriteLine("\n            ATTACK BOARD       \n");
            Console.WriteLine("     A  B  C  D  E  F  G  H  I  J\n");
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

                for (int row = 1; row <= 10; row ++)
                {
                    if (playerBoard.ShotHistory.ContainsKey(new Coordinate(row, col)))
                    {
                        ShotHistory sh = playerBoard.ShotHistory[new Coordinate(row, col)];
                        if (sh == ShotHistory.Hit)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(" H ");
                        }
                        else if (sh == ShotHistory.Miss)
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(" M ");
                        }
                        else
                        {
                            Console.Write(" ^ ");
                        }
                    }
                    else
                    {   
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" * ");
                    }

                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine();
        }

        public static void ShipBoard(Board playerBoard, int index)
        {
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
                    Coordinate testCoordinate = new Coordinate(row,col);
                    Coordinate shipCoordinate = playerBoard._ships[index].BoardPositions[0];
                    if (testCoordinate.Equals(shipCoordinate))
                    {
                        if (playerBoard._ships[index].ShipType == ShipType.Destroyer)
                        {
                            Console.Write(" D ");
                        }
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" * ");
                    }                    
                }
                Console.WriteLine();
            }

            Console.Write("Please Press Enter to Continue");
            Console.ReadLine();
            Console.Clear();
        }

        public static void VictoryMessage(Player user)
        {
            Console.Write("YOU WIN, Admiral {0}", user.playerName);
            Console.ReadLine();
            Console.Clear();
            AsciiArt.VictoryScreen();
            Console.ReadLine();
        }
    }
}
