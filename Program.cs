using System;
using System.Collections;
using System.Collections.Generic;

namespace NimmGrupp2
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            Intro f = new Intro();
            Human player1 = new Human();
            Running roon = new Running();
            bool x = true;
            Console.ForegroundColor = ConsoleColor.Green;
            
            
            


            Player player2 = f.firstOfAll();

            //Game loop  
            while (x)
            {
                roon.RunningFunc(player1, player2);
            }
        }
    }
}