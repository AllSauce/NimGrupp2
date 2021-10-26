using System;

namespace NimmGrupp2
{
    public class Intro
    {        
        public Tuple<Player, Player>  firstOfAll()
        {
            Console.Clear();
            Drawer.DrawWelcome();
            Console.WriteLine();
            Console.WriteLine("To see the rules type 'Rules' otherwise press enter.");
            
            //Displays the rules if requested
            string rul = Console.ReadLine();
            if (rul == "Rules" || rul == "rules")
            {
                Console.Clear();
                Drawer.DrawLogo();
                Console.WriteLine("Two players take turns taking 1-5 sticks from one of the stacks on the board.");
                Console.WriteLine();
                Console.WriteLine("Whoever picks the last stick wins! The board looks like this:");
                Console.WriteLine();
                int[] temparray = {5, 5, 5};
                Drawer.DrawBoard(temparray);
                Console.WriteLine();
                Console.WriteLine("Press enter to continue!");
                Console.ReadLine();
            }
            Console.Clear();
            Drawer.DrawLogo();
            Console.WriteLine("Let's play!");            
            Console.WriteLine("What is your name?");
            Player player1 = new Human(Console.ReadLine());
            Console.Clear();
            Drawer.DrawLogo();
            Console.WriteLine("To play against another person type: 'Human'.");
            Console.WriteLine("Otherwise there are 2 AI modes: 'Easy' and 'Hard'.");
            Console.WriteLine("Now please type which mode you would like to play against.");            
            Player player2 = null;

            while (true)
            {
                string data = Console.ReadLine();
                Console.Clear();
                if (data != "Human"  && data != "Easy"  && data != "Hard")
                {
                    Drawer.DrawLogo();
                    Console.WriteLine("Please type: 'Human', 'Easy' or 'Hard'.");                    
                }
                else if (data == "Human")
                {                    
                    Drawer.DrawLogo();
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
            return Tuple.Create(player1, player2);
        }
    }
}