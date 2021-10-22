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
            Running gameOn = new Running();
            //Game Loop
            bool x = true; 
            while (x)
            {
                gameOn.RunningFunc();
            }
        }
    }
}
