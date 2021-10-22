using System;
using System.Collections.Generic;

namespace NimmGrupp2
{
    static class Drawer
        {

            public static void DrawGameUI(int[] board, bool aPlayer1Turn, Player player1, Player player2)
            {



                DrawBoard(board);

            }

            public static void DrawBoard(int[] board)
            {
                NewLine();
                DrawSolid();
                //For loop for vertical axis
                for (int i = 0; i <= 5; i++)
                {
                    if (board[0] != 0 || board[1] != 0 || board[2] != 0)
                    {
                        DrawBar();
                        Console.Write("█");
                        // For loop for horistonal axis
                        for (int x = 0; x < 3; x++)
                        {
                            if (board[x] > 0)
                            {
                                DrawStick();
                                board[x]--;
                            }
                            else
                            {
                                DrawBlank();
                            }
                        }

                        NewLine();
                    }
                    else { DrawBar(); DrawSolid();  }           
                }

                Console.ReadLine();
            }

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

            private static void IntroOfGame()
            {
                    Console.WriteLine("Greetings mortal!");
                    Console.WriteLine("I challenge thee to a gentlemans duel!");
                    Console.WriteLine("The rules are simple but the cost of failure are substantial...");
                    Console.WriteLine("If thee accepts my challenge, ");
            }
        }
}
