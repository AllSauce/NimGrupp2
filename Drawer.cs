using System;
using System.Threading;

namespace NimmGrupp2
{
    public static class Drawer
    {
        /// <summary>
        /// Cointains logic for calcluating what to draw. Contacted to initilize drawing process. Cointains an optional message, enter null to leave emtpy
        /// </summary>
        /// <param name="board"></param>
        /// <param name="aPlayer1Turn"></param>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <param name="message"></param>
        public static void DrawGameUI(int[] board, bool aPlayer1Turn, Player player1, Player player2, string message)
        {
            Console.Clear();
            DrawLogo();
            
            Console.WriteLine(player1.name + " " + player1.score + " : " + player2.score + " " + player2.name);
            Console.WriteLine();
            if (message != null)
            {
                Console.WriteLine(message);
                Console.WriteLine();
            }
            if (aPlayer1Turn)
            {
                Console.WriteLine("Your turn " + player1.name + "!");
            }
            else
            {
                Console.WriteLine("Your turn " + player2.name + "!");
            }
            DrawBoard(board);
        }
        /// <summary>
        /// Draws A board from int[] 
        /// </summary>
        /// <param name="board"></param>
        public static void DrawBoard(int[] board)
        {
            NewLine();
            DrawSolid();
            // Creates a new local temparray to disconnect from gamelogic.board
            int[] tempArray = new int[3];            
            Array.Copy(board, tempArray, 3);
            // Loop for vertical animation movement
            for (int i = 0; i <= 5; i++)
            {
                //Checks so that there are actually sticks to draw
                if (tempArray[0] != 0 || tempArray[1] != 0 || tempArray[2] != 0)
                {
                    //Spacing
                    DrawBar();
                    //End Block
                    Console.Write("█");
                    for (int x = 0; x < 3; x++)
                    {
                        //Checks if space should have a stick or not
                        if (tempArray[x] > 0)
                        {
                            DrawStick();
                            //Notes that stick has been drawn at stack
                            tempArray[x]--;
                        }
                        else
                        {
                            DrawBlank();
                        }
                    }
                    NewLine();
                }
                // makes sure it dosn't write solids too early and writes bars if no sticks are present
                else if (i <= 4)
                {
                    DrawBar();
                    DrawBar();     
                }
                //writes a solid at the bottom
                else { DrawBar(); DrawSolid();  }                
            }            
        }
        // Really these are understandable without comment        
        private static void DrawStick()
        {
            Console.Write("  ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  █");
        }
        private static void DrawBlank()
        {
            Console.Write("                     █");
        }
        private static void NewLine()
        {
            Console.WriteLine();
        }
        private static void DrawBar()
        {
            Console.WriteLine("█                     █                     █                     █");
        }
        private static void DrawSolid()
        {
            Console.WriteLine("███████████████████████████████████████████████████████████████████");
        }
        public static void DrawLogo()
        {
            Console.WriteLine(@" _   _  _____  __  __ ");
            Console.WriteLine(@"| \ | ||_   _||  \/  |");
            Console.WriteLine(@"|  \| |  | |  | \  / |");
            Console.WriteLine(@"| . ` |  | |  | |\/| |");
            Console.WriteLine(@"| |\  | _| |_ | |  | |");
            Console.WriteLine(@"|_| \_||_____||_|  |_|");
            Console.WriteLine();

        }
        public static void DrawWelcome()
        {
            Console.WriteLine(@"__          __    _                                 _            _   _  _____  __  __ ");
            Console.WriteLine(@"\ \        / /   | |                               | |          | \ | ||_   _||  \/  |");
            Console.WriteLine(@" \ \  /\  / /___ | |  ___  ___   _ __ ___    ___   | |_  ___    |  \| |  | |  | \  / |");
            Console.WriteLine(@"  \ \/  \/ // _ \| | / __|/ _ \ | '_ ` _ \  / _ \  | __|/ _ \   | . ` |  | |  | |\/| |");
            Console.WriteLine(@"   \  /\  /|  __/| || (__| (_) || | | | | ||  __/  | |_| (_) |  | |\  | _| |_ | |  | |");
            Console.WriteLine(@"    \/  \/  \___||_| \___|\___/ |_| |_| |_| \___|   \__|\___/   |_| \_||_____||_|  |_|");
            Console.WriteLine(@"");
        }
        public static void DrawMonkey1()
        {
            Console.WriteLine(@"       .---.      ");
            Console.WriteLine(@"     _/_-.-_\_    ");
            Console.WriteLine(@"    / __} {__ \   ");
            Console.WriteLine(@"   / //  '  \\ \  ");
            Console.WriteLine(@"  / / \'---'/ \ \ ");
            Console.WriteLine(@"  \ \_/`'''`\_/ / ");
            Console.WriteLine(@"   \           /  ");
            

        }
        public static void DrawBonkey2()
        {
            Console.WriteLine(@"      .-'-.     ");
            Console.WriteLine(@"    _/.-.-.\_   ");
            Console.WriteLine(@"   /|( o o )|\  ");
            Console.WriteLine(@"  | //  '  \\ | ");
            Console.WriteLine(@" / / \'---'/ \ \");
            Console.WriteLine(@" \ \_/`'''`\_/ /");
            Console.WriteLine(@"  \           / ");
            
        }
        
        public static void DrawGameOver()
        {
            Console.WriteLine(@"  _____          __  __ ______    ______      ________ _____  ");
            Console.WriteLine(@" / ____|   /\   |  \/  |  ____|  / __ \ \    / /  ____|  __ \ ");
            Console.WriteLine(@"| |  __   /  \  | \  / | |__    | |  | \ \  / /| |__  | |__) |");
            Console.WriteLine(@"| | |_ | / /\ \ | |\/| |  __|   | |  | |\ \/ / |  __| |  _  / ");
            Console.WriteLine(@"| |__| |/ ____ \| |  | | |____  | |__| | \  /  | |____| | \ \ ");
            Console.WriteLine(@" \_____/_/    \_\_|  |_|______|  \____/   \/   |______|_|  \_\");
            Console.WriteLine();
        }

        public static void GameOver(bool aPlayer1Turn, Player player1, Player player2)
        {
            bool state1 = true;
            while (Console.ReadKey().Key != ConsoleKey.Enter) 
            {
                //Probably goona be used, who knows. lmao
                Console.Clear();
                DrawGameOver();
                Console.WriteLine(player1.name + " " + player1.score + " : " + player2.score + " " + player2.name);
                Console.WriteLine();
                if(aPlayer1Turn)
                {
                Console.WriteLine(player2.name +" Wins! Thanks for playing! Tap enter to play again or press esc to exit");
                    if(player2.name == "Harambe. Eater of bananas")
                    {
                        if(state1){DrawMonkey1();}
                        else{DrawBonkey2();}
                    }
                }
                else
                {
                    Console.WriteLine(player1.name +" Wins! Thanks for playing! Tap enter to play again or press esc to exit");
                }
                    Console.WriteLine();
                if (Console.ReadKey().Key != ConsoleKey.Escape)
                {
                    Console.Clear();
                    Console.WriteLine("");
                    Console.WriteLine("I am ever in debt to you for playing human.");
                    Console.WriteLine("I thank you and I wish to play again sometime.");
                    Console.WriteLine("So long, human...");
                    Console.WriteLine("Till' next time!");
                    Console.WriteLine("");
                    Environment.Exit(0);        
                }
                Thread.Sleep(100);             

            }
            
            


            
            
        }




    }
}