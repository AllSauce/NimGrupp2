using System;

namespace NimmGrupp2
{
    class Program
    {
        //Main method
        static void Main(string[] args)
        {
            bool x = true;
            bool player1Turn;
            int[] test = { 4, 5, 3 };
            Drawer.DrawBoard(test);

            //Game loop  
            while (x)
            {

                x = false;
            }

        }

    }
    
    //Sets the logic for the game
    public class GameLogic
    {
        //Sets board:
        //Index represents the stack
        //Number on index is the amount of sticks in respective stack
        int[] board = {5, 5, 5};

        public void RemoveSticks(Tuple<int, int> input)
        {
            //Chosen stack (-1 since it will be an index number)
            int stack = input.Item1 -1;
            //Chosen amount of sticks to remove
            int amount = input.Item2;

            //Replaces old value with new value
            board[stack] = board[stack] - amount;
        }

        public void GameOver()
        {
            /*if(player1turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
            {
                player2Score++:
            }
            else if(player2turn && board[0] == 0 && board[1] == 0 && board[2] == 0)
            {
                player1Score++;
            }*/
        }
    }

    public abstract class Player
    {
        int score;

        public abstract Tuple<int, int> play(int[] board);

    }

    //Human class, for more players
    public class Human : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            throw new NotImplementedException();
        }


    }

    public class EasyAI : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            throw new NotImplementedException();
        }


    }

    public class GamerModeAI : Player
    {
        //tillfällig metod
        public override Tuple<int, int> play(int[] board)
        {
            throw new NotImplementedException();
        }

    }

    public static class Drawer
    {
        /// <summary>
        /// Cointains logic for calcluating what to draw. Contacted to initilize drawing process
        /// </summary>
        /// <param name="board"></param>
        /// <param name="aPlayer1Turn"></param>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        public static void DrawGameUI(int[] board, bool aPlayer1Turn, Player player1, Player player2)
        {

            

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
            for (int i = 0; i <= 5; i++)
            {

                if (board[0] != 0 || board[1] != 0 || board[2] != 0)
                {
                    DrawBar();
                    Console.Write("█");
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

    }

}
