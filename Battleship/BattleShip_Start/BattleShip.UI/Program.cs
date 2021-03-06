﻿using System;
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
            Console.SetWindowSize(175, 56);
            bool playAgain;
            do
            {
                Console.Clear();
                Player p1 = new Player();
                Player p2 = new Player();
                WorkFlow game = new WorkFlow();
                Display display = new Display();
                bool victory = false;
                int playerTurn = 1;
                playAgain = true;

                display.welcomeScreen();
                game.PopulatePlayer(p1, 1);
                Console.Clear();
                game.PopulatePlayer(p2, 2);
                Console.Clear();
                game.placeShips(p1);
                Console.Clear();
                game.placeShips(p2);
                Console.Clear();

                while (!victory)
                {
                    if (playerTurn == 1)
                    {
                        victory = game.playerTurn(p1, p2);
                        Console.WriteLine();
                        Display.displayShotBoard(p2.playerBoard, p1);
                        playerTurn++;
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                    else if (playerTurn == 2)
                    {
                        victory = game.playerTurn(p2, p1);
                        Console.WriteLine();
                        Display.displayShotBoard(p1.playerBoard, p2);
                        playerTurn--;
                        Console.WriteLine("Press Enter to Continue");
                        Console.ReadLine();
                        Console.Clear();
                    }
                }

                Console.Write("Do you want to play again? (Y/N) ");
                string yesNo = Console.ReadLine().ToUpper();
                if (yesNo == "N")
                {
                    Console.Clear();
                    playAgain = false;
                }

            } while (playAgain); // finish play again loop

        }
    }
}