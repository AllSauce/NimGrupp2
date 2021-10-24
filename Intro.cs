using System;

namespace NimmGrupp2
{
    public class Intro
    {
        
        public Tuple<Player, Player>  firstOfAll()
        {
            

            Console.WriteLine("Welcome to a game of Nim!");
            Console.WriteLine("What is your name?");
            Player player1 = new Human(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("To play against another person type: 'Human'.");
            Console.WriteLine("Otherwise there are 2 AI modes: 'Easy' and 'Hard'");
            Console.WriteLine("Now please type which mode you would like to play against.");
            
            Player player2 = null;

            while (true)
            {
                string data = Console.ReadLine();
                Console.Clear();
                if (data != "Human"  && data != "Easy"  && data != "Hard")
                {
                    Console.WriteLine("Please type: 'Human', 'Easy' or 'Hard'.");
                    
                }
                else if (data == "Human")
                {
                    
                    Console.WriteLine("Human, tell me your name!");
                    player2 = new Human(Console.ReadLine());
                    break;
                    
                }
                else if (data == "Easy")
                {
                    player2 = new EasyAI();
                    break;
                }
                else if (data == "Hard")
                {

                    player2 = new GamerModeAI();
                    break;
                    
                }
                
                
            }
            
            var t1 = Tuple.Create(player1, player2);
            return t1;
        }
    }
}