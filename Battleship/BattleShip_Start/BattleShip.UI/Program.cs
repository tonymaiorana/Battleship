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
            //game.placeShips(p1);
            game.placeShips(p2);
            display.displayBoard(p1.playerBoard);
            game.playerTurn(p1, p2);
            Console.ReadLine();

        }
    }
}
