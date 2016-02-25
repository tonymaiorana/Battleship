﻿using System;
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
            Console.WriteLine("Welcome to Battleshits!!"); //Remember to change to battleships
            Console.WriteLine(@".                                                                                                                 `
. ';;;;;;;;;;;;;;;;;;;;;;;;';;;;;;;;;;;;;';;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;';;;;;;;;;;;;;';;;;;;;;;;;;;;;;;;;;;;;;.`
. ;;;;:;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;;,`
. ;;;;;;;;;;';;;;;:;;;;;;';:;;;;;;;;':;;;;;;;;';:;;;;';;;;;;;;;;;;';;;;;;;;';;;;;;;;';;;;;';;;;;;';;:;;;;;;'';;;;:`
. ';'        +;;;;;     `#;'        ;'        #';   `+;;;'        #;:;     ;+;;'.   ;'    #;'    #';'       +';;;,`
.`';'         +;;',      #;+        ;+        #';   `#;;;;        #;;       ,+;'.   ;'    #;'    #';+        +';;:.
.`';'         :+;'       #;+        ;+        #';   `+;;;'        #'         `#',   ;+    #;'    #;;+         #;;:`
.`''+    @#   :+;'   .   #;+@@    @@@#@@    @@@';   `#''''    #@@@#+    @+    #'.   ;+    #;'    #''+    @    #;':.
.`''+    #+   :+'+   #   #;;'+    #;;;;+    #;;';   `#;'''    #';;;+    #'    #',   ;+    #;'    #''+    +    #;;:`
.`''+    #+   :+'+   #   +';'+    #;;''+    #;'';   `#'''+    #';';+    #+::::#',   ;+    #;'    #''+    +    #;':`
.`''+    #'   :+'+   #   :+'''    #;'''+    #''';   `#'''+    `` #;+    '''++#;',   ''    #'+    #';+    #    #;':.
..';'        :@'''   #    #''+    #''''+    #''''   `#'''+       #'+       .+';',         ,:;;;  #';+    '    #'':.
..'''        ++'',   #    #''+    #'''''    #''''   `#'''+       #'+#        +'',         #:@@@:`#';+         #'':,
.`''+         '#'    #.   #''+    #''''+    #''''   `#'''+    ::,#''+#        #',        .:'@@@,,#''+        @@'':.
.,''+    @+    #+    ;,   #''+    #''''+    #''''   `#'''+    ###+''''#@@+    #',   '#   ;#@@@@;:#''+       @#''';,
..''+    #+    #+         #';+    #''''+    #''''   `#'''+    #''''+.,,.#+    #+,   ;+   ::@@@@;,#''+    @@@#'''';,
..''+    @+    #+         '+'+    #''''+    #''+'   .#'''+    #+'''+    #+    #+,   ;+  `;;@@@@+,#+'+    #''''''':,
..+''    ++    #+         `#'+    @''''+    #''+'   .'''#+    +'''#+    +'    #+,   ;+  `,;,:@ :,#''+    #''''''':.
.`+++          #'   '@+    #'+    @'''++    #'++'       @+        #+         ,#+,   ;+   `@.::;:`#+'+    #'++'+'+:.
.`+++        `@+.   #++    #++    @+++++    #'++'       @+        #+#       ;@'+,   ;+    @+#:.` #+++    #++'++++:.
.`+++       .@'+    @++    #++    @+++++    #+'+'       #+        #++#     +@''+.   ;+    @+#    #+++    #++'++++:`
. ++#@@@@@@@@+'#@@@@@+#@@@@@+#@@@@@+++'#@@@@@+++@@@@@@@@@+@@@@@@@@#+++@@@@@@++++@@@@@#@@@@@++@@@@@++@@@@@#''+++++:`
. ++++++++++++++;''''''''''''';';''''''''''';'''''''''''''''''''''''''''''''';';''''''''''';''''''';+++++++++++++,`
. +++++++++++++'                                                                                   .+++++++++++++,`
. .,,,,,,,,,,,,,``';;,;`'.''.`';;`;'..''`;;''`;',`''`'.``.''`,';`,'':`;;,`''`;;'``;',`''`.'';`:';``,,,,,,,,,,,,,,.`
.:::::::::::::::``,'.,' +'`.;`,',.'`+'.;:`+.'`'`+;::;'```',,''`'.'`'',' '::,;`'.`.+`;;::;'`':;'`:.`.:::::::::::::::
               ,```'`,';'';:```'..''+'.`.`'`'`'`.;'';'```',`.'`','.'',';':'''`'``.+'';'';'`':;';:```               
               ,...'.:+`'+'''..',,+.++'';.'.'.''+';:'''+.''''+'':'.+':''+;;:'`'..,''+;;:;'`':;''',..               
               ,````````````````````````````````````````````````````````````````````````````````````               
               ,                                                                                                   
                ````````````````````````````````````````````````````````````````````````````````````               ");
        }

        public void displayShotBoard(Board playerBoard)
        {
            //int [,] board = new int[10,10];

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
                        Console.Write(" * ");
                    }

                }
                Console.WriteLine();
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}
