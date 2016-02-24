using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

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
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.WriteLine("_|_|_|_|_|_|_|_|_");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
