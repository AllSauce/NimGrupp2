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


            while (true)
            {
                string data = Console.ReadLine();

                if (data != "Human"  || data != "Easy"  || data != "Hard")
                {
                    Console.WriteLine("Please type: 'Human', 'Easy' or 'Hard'.");
                }
                else if (data == "Human")
                {
                    Console.WriteLine("Human, tell me your name!");
                    Human hooman = new Human(Console.ReadLine());
                    return hooman;
                }
                else if (data == "Easy")
                {
                    return ez;
                }
                else if (data == "Hard")
                {
                    GamerModeAI gg = new GamerModeAI();
                    return gg;
                }
                
                else { break; }
            }

            return ez;
        }
    }
}