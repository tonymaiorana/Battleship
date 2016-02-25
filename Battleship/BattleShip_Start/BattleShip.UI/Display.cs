using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;
using BattleShip.BLL.Responses;

namespace BattleShip.UI
{
    public class Display
    {
        public void welcomeScreen()
        {
            Console.WriteLine("Welcome to Battleshits!!");      //Remember to change to battleships
        }

        public void displayBoard(Board playerBoard)
        {
            //int [,] board = new int[10,10];

            for(int row = 1; row <= 10; row++)
            {
                if (row < 10)
                {
                    Console.Write(" {0}  ", row);
                }
                else
                {
                    Console.Write(" {0} ", row);
                }

                for (int col = 1; col <= 10; col ++)
                {
                    // ***** FIX THIS ******
                    ShotHistory sh = playerBoard.ShotHistory[new Coordinate(row, col)];
                    if (sh == ShotHistory.Hit)
                    {
                        Console.WriteLine(" H ");
                    }
                    else if (sh == ShotHistory.Miss)
                    {
                        Console.WriteLine(" M ");
                    }
                   else
                        Console.Write(" * ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
