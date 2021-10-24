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
            
            
            Running roon = new Running();
            bool x = true;
            Console.ForegroundColor = ConsoleColor.Green;
            
            
            


            var players = f.firstOfAll();


            //Game loop  
            while (x)
            {
                roon.RunningFunc(players.Item1, players.Item2);
            }
        }
    }
}