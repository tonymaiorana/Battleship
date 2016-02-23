using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;

namespace BattleShip.UI
{
   public class Program
    {
        static void Main(string[] args)
        {
            Player p1 = new Player();
            Player p2 = new Player();

            bool validInput = true;
            string shipPlacementLocation;
            do
            {
                Console.WriteLine("Welcome To BattleShips!");
                Console.Write("Player 1, Please Enter Your Name: ");
                p1.playerName = Console.ReadLine();
                Console.Write("Player 2, Please Enter Your Name: ");
                p2.playerName = Console.ReadLine();
                if (p1.playerName == "" || p2.playerName == "")
                {
                    Console.WriteLine("Please enter your name to start!");
                    validInput = false;
                }
            } while (!validInput);

            Console.Write("{0}, enter the location of your Destroyer: ",p1.playerName);
            shipPlacementLocation=Console.ReadLine();
            p1.playerBoard=new Board();
            char xCoordinateChar = shipPlacementLocation[0];
            Console.WriteLine(xCoordinateChar);
            //Console.WriteLine(p1.playerName);
            Console.ReadLine();

        }
    }
}
