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
            Console.WriteLine();
            
            //Displays the rules if requested
            string rul = Console.ReadLine();
            if (rul == "Rules" || rul == "rules")
            {
                Console.Clear();
                Drawer.DrawLogo();
                Console.WriteLine("Two players take turns taking 1-5 sticks from one of the stacks on the board.");
                Console.WriteLine();
                Console.WriteLine("Input is provided by first stating what stack and then the amount seperated by a space. For example: (1 3) ");
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
            
                        
            return Tuple.Create(Addplayer(1), Addplayer(2));
        }
        public Player Addplayer(int playerid)
        {
            
            Console.Clear();
            Drawer.DrawLogo();
            Console.WriteLine("To make Player " + playerid + " a human type : 'Human'.");
            Console.WriteLine();
            Console.WriteLine("Otherwise there are 2 AI modes: 'Easy' and 'Hard'.");
            Console.WriteLine();
            Console.WriteLine("Now please type which type you would like player " + playerid + " to be.");       
            Console.WriteLine();     
            Player player = null;
            //Loops till valid input is provided
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
                    //Creates human but needs name as input
                    Console.WriteLine("Human, tell me your name!");
                    Console.WriteLine();
                    player = new Human(Console.ReadLine());
                    break;                    
                }
                else if (data == "Easy")
                {
                    player = new EasyAI();
                    break;
                }
                else if (data == "Hard")
                {
                    player = new GamerModeAI();
                    break;                    
                }                            
            }
            return player;
        }
    }
}