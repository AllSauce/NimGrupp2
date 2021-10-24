using System;

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
            Console.Write(" ▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓  █");
        }
        private static void DrawBlank()
        {
            Console.Write("                    █");
        }
        private static void NewLine()
        {
            Console.WriteLine();
        }
        private static void DrawBar()
        {
            Console.WriteLine("█                    █                    █                    █");
        }
        private static void DrawSolid()
        {
            Console.WriteLine("████████████████████████████████████████████████████████████████");
        }
        

    }
}