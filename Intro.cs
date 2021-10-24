using System;

namespace NimmGrupp2
{
    public class Intro
    {
        
        public Player firstOfAll()
        {
            EasyAI ez = new EasyAI();

            Console.WriteLine("Welcome to a game of Nim!");
            Console.WriteLine("To play against another person type: 'Human'.");
            Console.WriteLine("Otherwise there are 2 AI modes: 'Easy' and 'Hard'");
            Console.WriteLine("Now please type which mode you would like to play against.");
            
            string data = Console.ReadLine();

            if(data == "Human")
            {
                Human hooman = new Human();
                return hooman;
            }
            else if(data == "Easy")
            {
                return ez;
            }
            else if(data == "Hard")
            {
                GamerModeAI gg = new GamerModeAI();
                return gg;
            }

            return ez;
        }
    }
}