using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BattleShip.BLL.GameLogic;
using BattleShip.BLL.Requests;

namespace BattleShip.UI
{
   public class Program
    {
        static void Main(string[] args)
        {
            
            Player p1 = new Player();
            Player p2 = new Player();
            WorkFlow game = new WorkFlow();
            Display display = new Display();
            
            display.welcomeScreen();
            game.PopulatePlayer(p1, 1);
            game.PopulatePlayer(p2, 2);
            game.placeShips(p1);
            //Coordinate c1 = game.GetCoordinate();
            //Console.WriteLine("{0},{1}",c1.XCoordinate,c1.YCoordinate);

            Console.ReadLine();

        }
    }
}
